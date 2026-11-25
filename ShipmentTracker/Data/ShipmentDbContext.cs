using Microsoft.EntityFrameworkCore;
using ShipmentTracker.Models;

namespace ShipmentTracker.Data;

public class ShipmentDbContext : DbContext
{
    public ShipmentDbContext(DbContextOptions<ShipmentDbContext> options) : base(options)
    {
    }
    
    public DbSet<Shipment> Shipments => Set<Shipment>();
    
    public DbSet<ShipmentStatusHistory> ShipmentStatusHistories => Set<ShipmentStatusHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var shipment = modelBuilder.Entity<Shipment>();
        
        shipment.HasKey(s => s.Id);
        
        shipment.Property(s => s.Reference)
            .HasMaxLength(50)
            .IsRequired();
        
        // Unique reference index : Reject duplicate shipment references
        shipment.HasIndex(s => s.Reference)
            .IsUnique();
        
        // String enum conversion : Store readable statuses rather than enum numbers
        // Status concurrency token : Detect competing updates to the same shipment status
        shipment.Property(s => s.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsConcurrencyToken();
        
        var history = modelBuilder.Entity<ShipmentStatusHistory>();
        
        history.HasKey(s => s.Id);
        
        history.Property(h => h.PreviousStatus)
            .HasConversion<string>()
            .HasMaxLength(20);
        
        history.Property(h => h.NewStatus)
            .HasConversion<string>()
            .HasMaxLength(20);
        
        // Foreign key : Prevent history from referencing a nonexistent shipment
        history.HasOne<Shipment>()
            .WithMany()
            .HasForeignKey(h => h.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // History index : Support looking up a shipment’s history
        history.HasIndex(s => new { s.ShipmentId, s.ChangeStatusUtc });
    }
}
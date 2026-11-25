namespace ShipmentTracker.Models;

public class Shipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Reference { get; set; } = string.Empty;
    
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Created;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
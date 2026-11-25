//or this version, history records represent status changes only. Creating a shipment does not create a history row.

namespace ShipmentTracker.Models;

public class ShipmentStatusHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid ShipmentId { get; set; }
    
    public ShipmentStatus PreviousStatus { get; set; }
    
    public ShipmentStatus NewStatus { get; set; }
    
    public DateTime ChangeStatusUtc { get; set; } = DateTime.UtcNow;
}
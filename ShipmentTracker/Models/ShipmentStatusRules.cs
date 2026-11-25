namespace ShipmentTracker.Models;

public static class ShipmentStatusRules
{
    public static bool CanTranstion(
        ShipmentStatus current,
        ShipmentStatus next)
    {
        return (current, next) switch
        {
            (ShipmentStatus.Created, ShipmentStatus.InTransit) => true,
            (ShipmentStatus.InTransit, ShipmentStatus.Delivered) => true,
            _ => false
        };
    }
}
using System.ComponentModel.DataAnnotations;
using ShipmentTracker.Models;

namespace ShipmentTracker.DTOs.ShipmentDTOs;

public class UpdateShipmentStatusRequest
{
    [Required]
    [EnumDataType(typeof(ShipmentStatus))]
    public ShipmentStatus? Status { get; init; }
}
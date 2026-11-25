using System.ComponentModel.DataAnnotations;

namespace ShipmentTracker.DTOs.ShipmentDTOs;

public sealed record CreateShipmentRequest
{
    [Required]
    [StringLength(50)]
    public string Reference { get; init; } = string.Empty;
}
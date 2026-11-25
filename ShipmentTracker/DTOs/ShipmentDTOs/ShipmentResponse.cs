using ShipmentTracker.Models;

namespace ShipmentTracker.DTOs.ShipmentDTOs;

public record ShipmentResponse(
    Guid Id,
    string Reference,
    ShipmentStatus Status,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
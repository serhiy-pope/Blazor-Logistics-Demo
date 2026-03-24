using System.ComponentModel.DataAnnotations;

namespace Blazor_Logistics_Demo.Models;

public class CreateShipmentRequest
{
    [Required]
    [StringLength(30, MinimumLength = 5)]
    public string TrackingNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Origin { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Destination { get; set; } = string.Empty;

    [Range(0.1, 100000)]
    public decimal WeightKg { get; set; }

    [Required]
    [StringLength(50)]
    public string Carrier { get; set; } = string.Empty;

    [Required]
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
}
namespace Logistics.Core.Models;

public class Shipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TrackingNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
    public decimal WeightKg { get; set; }
    public string Carrier { get; set; } = string.Empty;
}

using Blazor_Logistics_Demo.Models;

namespace Blazor_Logistics_Demo.Services;

public class ShipmentService : IShipmentService
{
    private readonly List<Shipment> _shipments =
    [
        new()
        {
            TrackingNumber = "SL-10001",
            CustomerName = "Acme Retail",
            Origin = "Cape Town",
            Destination = "Johannesburg",
            WeightKg = 120.5m,
            Carrier = "ShipLogic",
            Status = ShipmentStatus.InTransit,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-2)
        },
        new()
        {
            TrackingNumber = "SL-10002",
            CustomerName = "Nova Parts",
            Origin = "Durban",
            Destination = "Pretoria",
            WeightKg = 48.2m,
            Carrier = "ShipLogic",
            Status = ShipmentStatus.Pending,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-1)
        },
        new()
        {
            TrackingNumber = "SL-10003",
            CustomerName = "Green Foods",
            Origin = "Port Elizabeth",
            Destination = "Johannesburg",
            WeightKg = 310.0m,
            Carrier = "FastFreight",
            Status = ShipmentStatus.Delivered,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-4)
        }
    ];

    public Task<IReadOnlyList<Shipment>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Shipment> result = _shipments
            .OrderByDescending(x => x.CreatedAtUtc)
            .ToList();

        return Task.FromResult(result);
    }

    public Task<Shipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var shipment = _shipments.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(shipment);
    }

    public Task CreateAsync(CreateShipmentRequest request, CancellationToken cancellationToken = default)
    {
        var shipment = new Shipment
        {
            Id = Guid.NewGuid(),
            TrackingNumber = request.TrackingNumber,
            CustomerName = request.CustomerName,
            Origin = request.Origin,
            Destination = request.Destination,
            WeightKg = request.WeightKg,
            Carrier = request.Carrier,
            Status = request.Status,
            CreatedAtUtc = DateTime.UtcNow
        };

        _shipments.Add(shipment);

        return Task.CompletedTask;
    }
}
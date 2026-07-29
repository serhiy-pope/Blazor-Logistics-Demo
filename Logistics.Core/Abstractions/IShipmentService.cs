using Logistics.Core.Models;

namespace Logistics.Core.Abstractions;

public interface IShipmentService
{
    Task<IReadOnlyList<Shipment>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Shipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateShipmentRequest request, CancellationToken cancellationToken = default);
}
using Blazor_Logistics_Demo.Models;

namespace Blazor_Logistics_Demo.Services;

public interface IShipmentService
{
    Task<IReadOnlyList<Shipment>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Shipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateShipmentRequest request, CancellationToken cancellationToken = default);
}
using System.Threading.Tasks;
using VehicleIncidentTracker.SharedKernel;

namespace VehicleIncidentTracker.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}
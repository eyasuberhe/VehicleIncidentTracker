using System.Threading.Tasks;
using VehicleIncidentTracker.SharedKernel;

namespace VehicleIncidentTracker.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
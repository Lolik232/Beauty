using Beauty.Core.DTOs;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    public interface IServiceManager
    {
        Task<IEnumerable<ServiceDTO>> GetEnrollmentServicesAsync(int enrollmentId);
        Task<EnrollmentWorkerService> GetEnrollmentWorkerServiceAsync(int enrollmentWorkerServiceId);
        Task<EnrollmentWorkerService> AddEnrollmentWorkerServiceAsync(EnrollmentWorkerService enrollmentWorkerService);
        Task<IEnumerable<EnrollmentWorkerService>> AddEnrollmentWorkerServicesAsync(IEnumerable<EnrollmentWorkerService> enrollmentWorkerServices);
        Task EditEnrollmentWorkerServiceAsync(EnrollmentWorkerService enrollmentWorkerService);
        Task RemoveAllEnrollmentWorkerServicesAsync(int enrollmentId);
        Task RemoveEnrollmentWorkerServiceAsync(int enrollmentWorkerServiceId);
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service> GetServiceAsync(int serviceId);
    }
}

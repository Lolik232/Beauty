using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWorkerService workerService;

        public ServiceManager(IUnitOfWork unitOfWork, IWorkerService workerService)
        {
            this.unitOfWork = unitOfWork;
            this.workerService = workerService;
        }

        private async Task<IEnumerable<ServiceDTO>> ToDTOsAsync(IEnumerable<EnrollmentWorkerService> enrollmentServices)
        {
            var serviceDTOs = enrollmentServices.Select(EnrollmentService => new ServiceDTO()
            {
                Id = EnrollmentService.ServiceId,
                EnrollmentWorkerServiceId = EnrollmentService.Id,
                Title = EnrollmentService.Service.Title,
                WorkerId = EnrollmentService.WorkerId
            }).ToList();

            foreach (var serviceDTO in serviceDTOs)
            {
                serviceDTO.WorkerShortname = await workerService.GetWorkerShortnameAsync(serviceDTO.WorkerId);
            }

            return serviceDTOs;
        }

        public async Task<IEnumerable<ServiceDTO>> GetEnrollmentServicesAsync(int enrollmentId)
        {
            var enrollmentWorkerServices = await unitOfWork.EnrollmentWorkerServices.FindEnrollmentWorkerServicesAsync(enrollmentId);

            return await ToDTOsAsync(enrollmentWorkerServices);
        }

        public async Task<EnrollmentWorkerService> GetEnrollmentWorkerServiceAsync(int enrollmentWorkerServiceId)
        {
            return await unitOfWork.EnrollmentWorkerServices.FindAsync(enrollmentWorkerServiceId);
        }

        public async Task<EnrollmentWorkerService> AddEnrollmentWorkerServiceAsync(EnrollmentWorkerService enrollmentWorkerService)
        {
            var addedEnrollmentWorkerService = unitOfWork.EnrollmentWorkerServices.Add(enrollmentWorkerService);
            await unitOfWork.SaveAsync();

            return addedEnrollmentWorkerService;
        }

        public async Task<IEnumerable<EnrollmentWorkerService>> AddEnrollmentWorkerServicesAsync(IEnumerable<EnrollmentWorkerService> enrollmentWorkerServices)
        {
            var addedEnrollmentWorkerServices = unitOfWork.EnrollmentWorkerServices.AddRange(enrollmentWorkerServices);
            await unitOfWork.SaveAsync();

            return addedEnrollmentWorkerServices;
        }

        public async Task EditEnrollmentWorkerServiceAsync(EnrollmentWorkerService enrollmentWorkerService)
        {
            await unitOfWork.UpdateAsync(enrollmentWorkerService);
            await unitOfWork.SaveAsync();
        }

        public async Task RemoveAllEnrollmentWorkerServicesAsync(int enrollmentId)
        {
            var enrollmentWorkerServices = await unitOfWork.EnrollmentWorkerServices.FindEnrollmentWorkerServicesAsync(enrollmentId);
            unitOfWork.EnrollmentWorkerServices.RemoveRange(enrollmentWorkerServices);
            await unitOfWork.SaveAsync();
        }

        public async Task RemoveEnrollmentWorkerServiceAsync(int enrollmentWorkerServiceId)
        {
            await unitOfWork.EnrollmentWorkerServices.RemoveAsync(enrollmentWorkerServiceId);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await unitOfWork.Services.FindAllAsync();
        }

        public async Task<Service> GetServiceAsync(int serviceId)
        {
            return await unitOfWork.Services.FindAsync(serviceId);
        }
    }
}

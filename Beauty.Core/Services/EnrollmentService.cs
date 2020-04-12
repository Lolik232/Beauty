using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetRelevantEnrollmentsAsync()
        {
            var enrollments = await unitOfWork.Enrollments.FindRelevantEnrollmentsAsync();

            var enrollmentDTOs = enrollments.Select(Enrollment => new EnrollmentDTO()
            {
                Id = Enrollment.Id,
                ClientFirstname = Enrollment.ClientFirstname,
                ClientPhoneNumber = Enrollment.ClientPhoneNumber,
                DateTime = Enrollment.DateTime,
                CreationDateTime = Enrollment.DateTime,
                EditDateTime = Enrollment.EditDateTime
            }).ToList();

            foreach (var enrollmentDTO in enrollmentDTOs)
            {
                var workerServices = await unitOfWork.EnrollmentWorkerServices.FindEnrollmentWorkerServicesAsync(enrollmentDTO.Id);

                var services = new List<string>();

                foreach (var workerService in workerServices)
                {
                    var workerShortname = await unitOfWork.Workers.FindWorkerShortnameAsync(workerService.WorkerId);
                    services.Add($"{workerService.Service.Title} ({workerShortname})");
                }

                enrollmentDTO.Services = services;
            }

            return enrollmentDTOs;
        }
    }
}

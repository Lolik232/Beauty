using Beauty.Core.DTOs;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceManager serviceManager;

        public EnrollmentService(IUnitOfWork unitOfWork, IServiceManager serviceManager)
        {
            this.unitOfWork = unitOfWork;
            this.serviceManager = serviceManager;
        }

        private async Task<IEnumerable<EnrollmentDTO>> ToDTOsAsync(IEnumerable<Enrollment> enrollments)
        {
            var enrollmentDTOs = enrollments.Select(Enrollment => new EnrollmentDTO()
            {
                Id = Enrollment.Id,
                ClientFirstname = Enrollment.ClientFirstname,
                ClientPhoneNumber = Enrollment.ClientPhoneNumber,
                Description = Enrollment.Description,
                DateTime = Enrollment.DateTime,
                CreationDateTime = Enrollment.CreationDateTime,
                EditDateTime = Enrollment.EditDateTime
            }).ToList();

            foreach (var enrollmentDTO in enrollmentDTOs)
            {
                enrollmentDTO.Services = await serviceManager.GetEnrollmentServicesAsync(enrollmentDTO.Id);
            }

            return enrollmentDTOs;
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsAsync()
        {
            var enrollments = await unitOfWork.Enrollments.FindAllAsync();

            return await ToDTOsAsync(enrollments);
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetRelevantEnrollmentsAsync()
        {
            var enrollments = await unitOfWork.Enrollments.FindRelevantEnrollmentsAsync();

            return await ToDTOsAsync(enrollments);
        }

        public async Task<Enrollment> GetEnrollmentAsync(int enrollmentId)
        {
            return await unitOfWork.Enrollments.FindAsync(enrollmentId);
        }

        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            var addedEnrollment = unitOfWork.Enrollments.Add(enrollment);
            await unitOfWork.SaveAsync();

            return addedEnrollment;
        }

        public async Task EditEnrollmentAsync(Enrollment enrollment)
        {
            await unitOfWork.UpdateAsync(enrollment);
        }

        public async Task RemoveEnrollmentAsync(int enrollmentId)
        {
            await unitOfWork.Enrollments.RemoveAsync(enrollmentId);
            await unitOfWork.SaveAsync();
        }
    }
}

using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Enrollment>> GetRelevantEnrollmentsAsync()
        {
            return await unitOfWork.Enrollments.FindRelevantEnrollmentsAsync();
        }
    }
}

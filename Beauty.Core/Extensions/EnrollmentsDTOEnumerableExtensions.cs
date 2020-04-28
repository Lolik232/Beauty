using Beauty.Core.DTOs;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Beauty.Core.Extensions
{
    public static class EnrollmentsDTOEnumerableExtensions
    {
        public static IEnumerable<EnrollmentDTO> FilterBy(this IEnumerable<EnrollmentDTO> enrollments, string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return enrollments;
            }

            var filteredEnrollments = new List<EnrollmentDTO>();

            var enrollmentsFilteredByClientFirstname = enrollments.Where(Enrollment => Enrollment.ClientFirstname.Contains(filterText));
            filteredEnrollments.AddRange(enrollmentsFilteredByClientFirstname);

            var enrollmentsFilteredByPhoneNumber = enrollments.Where(Enrollment => Enrollment.ClientPhoneNumber.Contains(filterText));
            filteredEnrollments.AddRange(enrollmentsFilteredByPhoneNumber);

            var enrollmentsFilteredByTime = enrollments.Where(Enrollment => Enrollment.DateTime.ToString("HH:mm").Contains(filterText));
            filteredEnrollments.AddRange(enrollmentsFilteredByTime);

            return filteredEnrollments.Distinct();
        }
    }
}

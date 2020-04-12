using Beauty.Data.Models;
using System;
using System.Collections.Generic;

namespace Beauty.Core.DTOs
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public string ClientFirstname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? EditDateTime { get; set; }
        public IEnumerable<string> Services { get; set; }
    }
}

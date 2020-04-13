using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int WorkerId { get; set; }
        public string WorkerShortname { get; set; }
    }
}

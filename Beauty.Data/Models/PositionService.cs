using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Models
{
    public class PositionService
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}

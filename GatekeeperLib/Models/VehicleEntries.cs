using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatekeeperLib.Models
{
    public class VehicleEntries
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int PersonId { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}

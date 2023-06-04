using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatekeeperLib.Models
{
    public class VehicleEntriesFullModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}

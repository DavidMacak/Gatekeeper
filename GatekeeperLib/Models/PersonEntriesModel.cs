using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatekeeperLib.Models
{
    public class PersonEntriesModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}

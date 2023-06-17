using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gatekeeper.Web.Pages
{
    public class VehicleEntriesPageModel : PageModel
    {
        private IDatabaseData _db;
        public List<VehicleEntriesFullModel> VehicleEntries{ get; set; }

        public VehicleEntriesPageModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            VehicleEntries = _db.LoadVehicleEntries();
        }
    }
}

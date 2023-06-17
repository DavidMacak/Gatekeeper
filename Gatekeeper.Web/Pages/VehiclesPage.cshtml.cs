using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gatekeeper.Web.Pages
{
    public class VehiclesPageModel : PageModel
    {
        private IDatabaseData _db;
        public List<VehicleModel> Vehicles { get; set; }

        public VehiclesPageModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Vehicles = _db.LoadVehicles();
        }
    }
}

using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gatekeeper.Web.Pages
{
    public class PersonEntriesPageModel : PageModel
    {
        private readonly IDatabaseData _db;
        public List<PersonEntriesFullModel> PersonEntries { get; set; }

        public PersonEntriesPageModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            PersonEntries = _db.LoadPersonEntries();
        }
    }
}

using GatekeeperLib.Data;
using GatekeeperLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gatekeeper.Web.Pages
{
    public class PersonsPageModel : PageModel
    {
        private readonly IDatabaseData _db;
        public List<PersonModel> Persons { get; set; }

        public PersonsPageModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Persons = _db.LoadPersons();
        }
    }
}

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

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }

        public PersonsPageModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            LoadPersons();
        }

        public void OnPost()
        {
            _db.CreatePerson(FirstName, LastName);
            LoadPersons();
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        private void LoadPersons()
        {
            Persons = _db.LoadPersons();
        }
    }
}

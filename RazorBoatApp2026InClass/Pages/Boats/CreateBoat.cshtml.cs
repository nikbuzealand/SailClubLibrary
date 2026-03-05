using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Exceptions;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private IBoatRepository _repo;

        [BindProperty]
        public Boat NewBoat { get; set; }

        public CreateBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }

        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _repo.AddBoat(NewBoat);
            }

            catch(BoatSailnumberExistsException bsnex)
            {
                ViewData["ErrorMessage"] = bsnex.Message;
                return Page();
            }
            catch(Exception x)
            {
                ViewData["ErrorMessage"] = x.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}

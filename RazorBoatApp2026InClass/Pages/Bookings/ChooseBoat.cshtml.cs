using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBoatApp2026InClass.Pages.Boats;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private IBoatRepository bRepo;

        public List<Boat> Boats { get; set; }

        public ChooseBoatModel(IBoatRepository boatRepository)
        {
            bRepo = boatRepository;
        }

        public void OnGet()
        {
            Boats = bRepo.GetAllBoats();
        }
    }
}

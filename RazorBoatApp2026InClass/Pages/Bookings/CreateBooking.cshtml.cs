using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepository btRepo;
        private IBookingRepository bkRepo;
        private IMemberRepository mRepo;

        public List<Boat> Boats { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Member> Members { get; set; }
        public Boat BookingBoat { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Destination { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }

        public CreateBookingModel(IBoatRepository boatRepository, IBookingRepository bookingRepository, IMemberRepository memberRepository)
        {
            btRepo = boatRepository;
            bkRepo = bookingRepository;
            mRepo = memberRepository;
        }

        public IActionResult OnGet(string sailNumber)
        {
            Boats = btRepo.GetAllBoats();
            Bookings = bkRepo.GetAllBookings();
            Members = mRepo.GetAllMembers();
            BookingBoat = btRepo.SearchBoat(sailNumber);
            return Page();
        }

        public IActionResult OnPost(string submitSailNumber)
        {
            Booking NewBooking = new Booking(Id, StartDate, EndDate, Destination, (mRepo.SearchMember(PhoneNumber)), (btRepo.SearchBoat(submitSailNumber)));
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                bkRepo.AddBooking(NewBooking);
            }
            catch (Exception x)
            {
                ViewData["ErrorMessage"] = x.Message;
                return RedirectToPage("ChooseBoat");
            }
            return RedirectToPage("Index");
        }
    }
}

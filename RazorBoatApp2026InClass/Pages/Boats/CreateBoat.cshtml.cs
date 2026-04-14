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
        private IWebHostEnvironment _webHostenviroment;

        [BindProperty]
        public Boat NewBoat { get; set; }

        public CreateBoatModel(IBoatRepository boatRepository, IWebHostEnvironment webHost)
        {
            _repo = boatRepository;
            _webHostenviroment = webHost;
        }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            //if (NewBoat.NewBoat != null)
            //{
            //    string filepath = Path.Combine(_webHostenviroment.WebRootPath, "/Images/BoatImages", NewMember.MemberImage);
            //    System.IO.File.Delete(filepath);
            //}
            //NewMember.MemberImage = ProcessUploadedFile();
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
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

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Exceptions;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private IMemberRepository _repo;
        private IWebHostEnvironment _webHostenviroment;

        [BindProperty]
        public Member NewMember { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public CreateMemberModel(IMemberRepository memberRepository, IWebHostEnvironment webHost)
        {
            _repo = memberRepository;
            _webHostenviroment = webHost;
        }

        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if(Photo != null)
            {
                //sletter nuværne billed 
                if(NewMember.MemberImage != null)
                {
                    string filepath = Path.Combine(_webHostenviroment.WebRootPath, "/Images/MemberImages", NewMember.MemberImage);
                    System.IO.File.Delete(filepath);
                }
                NewMember.MemberImage = ProcessUploadedFile(); 
            }

            if(!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _repo.AddMember(NewMember);
            }

            //catch(BoatSailnumberExistsException bsnex)
            //{
            //    ViewData["ErrorMessage"] = bsnex.Message;
            //    return Page();
            //}
            catch(Exception x)
            {
                ViewData["ErrorMessage"] = x.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
        private string ProcessUploadedFile()
        {
            string uniquefilename = null;
            if(Photo!= null)
            {
                string uploadfolder = Path.Combine(_webHostenviroment.WebRootPath, "Images/MemberImages");
                uniquefilename = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filepath = Path.Combine(uploadfolder, uniquefilename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    Photo.CopyTo(filestream);
                }
            }
            return uniquefilename;
        }
    }
}

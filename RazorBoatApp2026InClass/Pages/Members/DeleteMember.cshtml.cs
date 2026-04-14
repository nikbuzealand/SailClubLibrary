using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Shared.Members
{
    public class DeleteMemberModel : PageModel
    {
        private IMemberRepositoryAsync _repo;
        [BindProperty]
        public Member DeleteMember { get; set; }

        public DeleteMemberModel(IMemberRepositoryAsync memberRepositoryAsync)
        {
            _repo = memberRepositoryAsync;
        }

        public IActionResult OnGet(string phoneNumber)
        {
            DeleteMember = _repo.SearchMemberAsync(phoneNumber).Result;
            return Page();
        }

        public IActionResult OnPostDelete(string phoneNumber)
        {
            _repo.RemoveMemberAsync(phoneNumber);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

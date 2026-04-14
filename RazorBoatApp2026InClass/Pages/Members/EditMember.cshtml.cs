using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class EditMemberModel : PageModel
    {
        private IMemberRepositoryAsync _repo;
        [BindProperty]

        public Member MemberToUpdate { get; set; }

        public EditMemberModel(IMemberRepositoryAsync memberRepositoryAsync)
        {
            _repo = memberRepositoryAsync;
        }

        public void OnGet(string phoneNumber)
        {
            MemberToUpdate = _repo.SearchMemberAsync(phoneNumber).Result;
        }

        public IActionResult OnPostEdit()
        {
            _repo.UpdateMemberAsync(MemberToUpdate);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

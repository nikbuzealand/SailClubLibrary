using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepository mRepo;

        public List<Member> Members { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        [BindProperty(SupportsGet = true)]
        public MemberType SelectedMemberType { get; set; }

        public IndexModel(IMemberRepository memberRepository)
        {
            mRepo = memberRepository;
        }

        public void OnGet()
        {
            if(!string.IsNullOrEmpty(FilterCriteria))
            {
                Members = mRepo.FilterMembers(FilterCriteria, SortBy);
            }
            else
            {
                Members = mRepo.GetAllMembers();
            }
            SortMembers();
            if (SelectedMemberType == MemberType.Junior)
            {
                Members = Members.FindAll(i => i.TheMemberType == MemberType.Junior);
            }
            else if (SelectedMemberType == MemberType.Senior)
            {
                Members = Members.FindAll(i => i.TheMemberType == MemberType.Senior);
            }
            else if (SelectedMemberType == MemberType.Adult)
            {
                Members = Members.FindAll(i => i.TheMemberType == MemberType.Adult);
            }
            else
            {
                Members = Members;
            }
        }

        private void SortMembers()
        {
            if (SortBy == "FirstName")
            {
                MemberCompareByFirstName sortFirstName = new MemberCompareByFirstName();
                Members.Sort(sortFirstName);
            }
            if (SortBy == "SurName")
            {
                MemberCompareBySurName sortSurName = new MemberCompareBySurName();
                Members.Sort(sortSurName);
            }
            if (SortBy == "PhoneNumber")
            {
                MemberCompareByPhoneNumber sortPhoneNumber = new MemberCompareByPhoneNumber();
                Members.Sort(sortPhoneNumber);
            }
        }
    }
}

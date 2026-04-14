using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Filter;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepositoryAsync mRepo;

        public List<Member> Members { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterBy { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        [BindProperty(SupportsGet = true)]
        public MemberType? SelectedMemberType { get; set; }

        public IndexModel(IMemberRepositoryAsync memberRepositoryAsync)
        {
            mRepo = memberRepositoryAsync;
        }

        //public void OnGet()
        //{
        //    if(!string.IsNullOrEmpty(FilterCriteria))
        //    {
        //        Members = mRepo.FilterMembers(FilterCriteria, FilterBy);
        //    }
        //    else
        //    {
        //        Members = mRepo.GetAllMembers();
        //    }
        //    SortMembers();
        //    if (SelectedMemberType == MemberType.Junior)
        //    {
        //        Members = Members.FindAll(i => i.TheMemberType == MemberType.Junior);
        //    }
        //    else if (SelectedMemberType == MemberType.Senior)
        //    {
        //        Members = Members.FindAll(i => i.TheMemberType == MemberType.Senior);
        //    }
        //    else if (SelectedMemberType == MemberType.Adult)
        //    {
        //        Members = Members.FindAll(i => i.TheMemberType == MemberType.Adult);
        //    }
        //    else
        //    {
        //        Members = Members;
        //    }
        //}

        public void OnGet()
        {
            Members = MemberFilter(mRepo.GetAllMembersAsync().Result);
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

        private List<Member> MemberFilter(List<Member> members)
        {
            List<Predicate<Member>> predicates = new List<Predicate<Member>>();
            if(SelectedMemberType.HasValue)
            {
                predicates.Add(b => b.TheMemberType == SelectedMemberType.Value);
            }
            if(!string.IsNullOrWhiteSpace(FilterCriteria))
            {
                switch(FilterBy)
                {
                    case "All":
                        predicates.Add(b => b.FilterAll().Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "FirstName":
                        predicates.Add(b => !string.IsNullOrEmpty(b.FirstName) && b.FirstName.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "SurName":
                        predicates.Add(b => !string.IsNullOrEmpty(b.SurName) && b.SurName.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "PhoneNumber":
                        predicates.Add(b => !string.IsNullOrEmpty(b.PhoneNumber) && b.PhoneNumber.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Mail":
                        predicates.Add(b => !string.IsNullOrEmpty(b.Mail) && b.Mail.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "City":
                        predicates.Add(b => !string.IsNullOrEmpty(b.City) && b.City.Contains(FilterCriteria, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            return FilterFunctions<Member>.Filter(members, predicates);
        }
    }
}

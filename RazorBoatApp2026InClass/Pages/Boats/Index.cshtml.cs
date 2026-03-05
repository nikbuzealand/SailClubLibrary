using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository bRepo;

        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IndexModel(IBoatRepository boatRepository)
        {
            bRepo = boatRepository;
        }

        public void OnGet()
        {
            if(!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = bRepo.FilterBoats(FilterCriteria);
            }
            else
            {
                Boats = bRepo.GetAllBoats();
            }
            SortBoats();
        }

        private void SortBoats()
        {
            if(SortBy == "Id")
            {
                Boats.Sort();
            }
            if (SortBy == "SailNumber")
            {
                BoatCompareBySailNumber sortSailNumber = new BoatCompareBySailNumber();
                Boats.Sort(sortSailNumber);
            }
            if (SortBy == "YearOfConstruction")
            {
                BoatCompareByYear sortYear = new BoatCompareByYear();
                Boats.Sort(sortYear);
            }
        }
    }
}

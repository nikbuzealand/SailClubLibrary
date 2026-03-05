using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null) return 1;

            if (Convert.ToInt64(x.YearOfConstruction) < Convert.ToInt64(y.YearOfConstruction)) return -1;
            if (Convert.ToInt64(x.YearOfConstruction) > Convert.ToInt64(y.YearOfConstruction)) return 1;

            return 0;
        }
    }
}

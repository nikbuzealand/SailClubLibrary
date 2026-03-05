using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareBySailNumber : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null) return 1;

            if (x.SailNumber.CompareTo(y.SailNumber) < 0) return -1;
            if (x.SailNumber.CompareTo(y.SailNumber) > 0) return 1;

            return 0;
        }
    }
}

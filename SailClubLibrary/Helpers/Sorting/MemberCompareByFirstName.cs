using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class MemberCompareByFirstName : IComparer<Member>
    {
        public int Compare(Member? x, Member? y)
        {
            if (x == null) return 1;

            if (x.FirstName.CompareTo(y.FirstName) < 0) return -1;
            if (x.FirstName.CompareTo(y.FirstName) > 0) return 1;

            return 0;
        }
    }
}

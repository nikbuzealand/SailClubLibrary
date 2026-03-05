using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class MemberCompareBySurName : IComparer<Member>
    {
        public int Compare(Member? x, Member? y)
        {
            if (x == null) return 1;

            if (x.SurName.CompareTo(y.SurName) < 0) return -1;
            if (x.SurName.CompareTo(y.SurName) > 0) return 1;

            return 0;
        }
    }
}

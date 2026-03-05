using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class MemberCompareByPhoneNumber : IComparer<Member>
    {
        public int Compare(Member? x, Member? y)
        {
            if (x == null) return 1;

            if (Convert.ToInt64(x.PhoneNumber) < Convert.ToInt64(y.PhoneNumber)) return -1;
            if (Convert.ToInt64(x.PhoneNumber) > Convert.ToInt64(y.PhoneNumber)) return 1;

            return 0;
        }
    }
}

using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Data
{
    public class MockData
    {
        #region Instance fields
        private Dictionary<string, Member> _memberData =
            new Dictionary<string, Member>()
            {
            { "23456789", new Member(1, "Peter","Jensen","23456789","Gaden 1","Hillerød","PH@gamil.com",MemberType.Senior,MemberRole.Member) },
             { "65345890", new Member(2, "Charlotte","Hansen","65345890","Street 1","Roskilde","ch@gamil.com",MemberType.Adult,MemberRole.Admin) },
            };

        private Dictionary<string, Boat> _boatData =
              new Dictionary<string, Boat>()
              {
            { "16-3335", new Boat(1, BoatType.TERA, "Model", "16-3335", "Is very good :3", 32, 23, 33, "1982")},
            { "17-8767", new Boat(2, BoatType.LYNÆS, "Model", "17-8767", "Fast :3", 34, 25, 17, "2000")},

              };

        private List<Booking> _bookingData =
            new List<Booking>()
            {
                new Booking(1, DateTime.Now, DateTime.Now, "Boathouse", new Member(1, "Peter","Jensen","23456789","Gaden 1","Hillerød","PH@gamil.com",MemberType.Senior,MemberRole.Member), new Boat(1, BoatType.TERA, "Model", "16-3335", "Is very good :3", 32, 23, 33, "1982"))
            };
        #endregion

        #region Properties
        public Dictionary<string, Member> MemberData
        {
            get { return _memberData; }
        }
        public Dictionary<string, Boat> BoatData
        {
            get { return _boatData; }
        }
        public List<Booking> BookingData
        {
            get { return _bookingData; }
        }

        #endregion
    }
}

using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Services
{
    internal class MemberRepositoryAsync : IMemberRepository
    {
        public int Count => throw new NotImplementedException();

        public void AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public List<Member> FilterMembers(string filterCriteria, string filterType)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        public void PrintAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Member? SearchMember(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}

using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IMemberRepository
    {
        int Count { get; }
        void AddMember(Member member);
        void RemoveMember(string phoneNumber);
        void UpdateMember(Member member);
        List<Member> GetAllMembers();
        void PrintAll();
        Member? SearchMember(string phoneNumber);
        List<Member> FilterMembers(string filterCriteria, string filterType);
    }
}

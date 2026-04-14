using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IMemberRepositoryAsync
    {
        Task<int> Count { get; }
        Task AddMemberAsync(Member member);
        Task RemoveMemberAsync(string phoneNumber);
        Task UpdateMemberAsync(Member updatedMember);
        Task<List<Member>> GetAllMembersAsync();
        Task PrintAllAsync();
        Task<Member?> SearchMemberAsync(string phoneNumber);
        Task<List<Member>> FilterMembersAsync(string filterCriteria, string filterType);
    }
}

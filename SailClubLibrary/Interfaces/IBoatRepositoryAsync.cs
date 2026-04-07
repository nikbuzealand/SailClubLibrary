using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IBoatRepositoryAsync
    {
        Task<int> Count { get; }
   
       Task <List<Boat>> GetAllBoatsAsync();
        Task AddBoatAsync(Boat boat);
        Task RemoveBoatAsync(string sailNumber);
        Task UpdateBoatAsync(Boat boat);
       Task< Boat?> SearchBoatAsync(string sailNumber);
       Task <List<Boat>> FilterBoatsAsync(string filterCriteria);
    }
}

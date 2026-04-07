using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Interfaces
{
    public interface IBoatRepositoryAsync
    {
        Task<int> Count { get; }
   
       Task <List<Boat>> GetAllBoats();
        Task AddBoat(Boat boat);
        Task RemoveBoat(string sailNumber);
        Task UpdateBoat(Boat boat);
       Task< Boat?> SearchBoat(string sailNumber);
       Task <List<Boat>> FilterBoats(string filterCriteria);
    }
}

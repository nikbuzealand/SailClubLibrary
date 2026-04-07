using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Interfaces
{
    public interface IMemberRepositoryAsync
    {
        Task<int> count { get; }
        Task Addmemberasync(Member amember);
        Task Removemember(Member amember);
        Task Updatemember(Member amember);
        Task<List<Member>> GetAllMembers();
        Task printall();
        Task<Member?> Searchmember(string number);
        Task<List<Member>> Filtermembers(string filtercriteria, string filtertype);
    }
}

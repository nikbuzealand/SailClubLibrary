using Microsoft.Data.SqlClient;
using SailClubLibrary.Exceptions;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Data;
using SailClubLibrary.Helpers;

namespace SailClubLibrary.Services
{
    /// <summary>
    /// Class for Constructing and calling Member Repository Objects using the interface
    /// </summary>
    public class MemberRepositoryAsync : Connection, IMemberRepositoryAsync
    {
        #region Instance Fields
        private Task<Dictionary<string,Member>> _members;
        #endregion

        #region Properties
        /// <summary>
        /// Count used for counting members in _members repository
        /// </summary>
        public Task<int> Count => _members.ContinueWith(task => task.Result.Count);
        #endregion

        #region Constructor
        /// <summary>
        /// MemberRepository constructor used for making a new member repository called _members with string as key and IMember as value
        /// </summary>
        public MemberRepositoryAsync()
        {
            _members = GetMembersFromDatabaseAsync();
        }
        #endregion

        #region Methods
        public async Task<Dictionary<string,Member>> GetMembersFromDatabaseAsync()
        {
            Dictionary<string,Member> memberDictionary = new Dictionary<string,Member>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string leString = "select * from members";
                SqlCommand command = new SqlCommand(leString,connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int memberID = reader.GetInt32("memberID");
                    string memberFirstName = reader.GetString("memberFirstName");
                    string memberSurName = reader.GetString("memberSurName");
                    string memberPhoneNumber = reader.GetString("memberPhoneNumber");
                    string memberAddress = reader.GetString("memberAddress");
                    string memberCity = reader.GetString("memberCity");
                    string memberMail = reader.GetString("memberMail");
                    
                    int memberTypeEnumID = reader.GetInt32("memberTypeEnumID");
                    int memberRoleEnumID = reader.GetInt32("memberRoleEnumID");
                    MemberType theMemberType = ADO.GetEnumValueFromInt<MemberType>(memberTypeEnumID);
                    MemberRole theMemberRole = ADO.GetEnumValueFromInt<MemberRole>(memberRoleEnumID);

                    Member locatedMember = new Member(memberID,memberFirstName,memberSurName,memberPhoneNumber,memberAddress,memberCity,memberMail,theMemberType,theMemberRole);
                    memberDictionary[memberPhoneNumber] = locatedMember;
                }

                reader.Close();
            }

            return memberDictionary;
        }

        /// <summary>
        /// Method for adding members to our repository, which runs a check to tell if the phone number is available
        /// </summary>
        public async Task AddMemberAsync(Member member)
        {
            Dictionary<string,Member> membahs = await _members;

            if (!membahs.ContainsKey(member.PhoneNumber))
            {
                membahs.Add(member.PhoneNumber, member);
                return;
            }
            throw new MemberPhoneNumberExistsException($"Medlemstelefonnummeret {member.PhoneNumber} findes allerede.");
        }
        // Formål:
        // At få fat på en list med alle medlemmer/objekter
        // Metoden returnere via en indbygget metode som hedder ToList(); som henter liste med _members Values

        /// <summary>
        /// Method for returning a list of members
        /// </summary>
        public async Task<List<Member>> GetAllMembersAsync()
        {
            _members = GetMembersFromDatabaseAsync();
            Dictionary<string, Member> membahs = await _members;
            return membahs.Values.ToList();
        }
        // Formål:
        // Fjerne Medlem
        // Metoden sletter via metoden Remove, og sletter telefonnummeret fra _members

        /// <summary>
        /// Method for removing a member from the dictionary, using their phone number
        /// </summary>
        public async Task RemoveMemberAsync(string phoneNumber)
        {
            Dictionary<string, Member> membahs = await _members;
            membahs.Remove(phoneNumber);
        }
        // Formål:
        // Opdatere Medlem
        // if-statement:
        // Hvis _members indholder Telefonnummeret argumentet, så overskrider de nye værdier de nuværende med samme telefonnummer.

        /// <summary>
        /// Method to update a member's info, using their phone number to distinguish them
        /// </summary>
        public async Task UpdateMemberAsync(Member updatedMember)
        {
            Dictionary<string, Member> membahs = await _members;

            if (membahs.ContainsKey(updatedMember.PhoneNumber))
            {
                Member existingMember = membahs[updatedMember.PhoneNumber];

                existingMember.FirstName = updatedMember.FirstName;
                existingMember.SurName = updatedMember.SurName;
                existingMember.Address = updatedMember.Address;
                existingMember.City = updatedMember.City;
                existingMember.Mail = updatedMember.Mail;
                existingMember.TheMemberType = updatedMember.TheMemberType;
                existingMember.TheMemberRole = updatedMember.TheMemberRole;
            }
        }

        /// <summary>
        /// Searches through the member dictionary and returns the member with the given phonenumber. 
        /// </summary>
        public async Task<Member?> SearchMemberAsync(string phoneNumber)
        {
            Dictionary<string, Member> membahs = await _members;

            if (membahs.ContainsKey(phoneNumber))
            {
                return membahs[phoneNumber];
            }

            return null;
        }

        /// <summary>
        /// Method for printing the info of every member in the dictionary
        /// </summary>
        public async Task PrintAllAsync()
        {
            Dictionary<string, Member> membahs = await _members;

            foreach (Member member in membahs.Values)
            {
                Console.WriteLine(member);
                Console.WriteLine();
            }
        }

        public async Task<List<Member>> FilterMembersAsync(string filterCriteria, string filterType)
        {
            Dictionary<string, Member> membahs = await _members;
            List<Member> filteredMembers = new List<Member>();

            foreach (Member m in membahs.Values)
            {
                //if (m.Id.ToString().Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase))
                //{
                //    filteredMembers.Add(m);
                //}
                //else if (m.TheMemberType.ToString().Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                //{
                //    filteredMembers.Add(m);
                //}
                if (filterType == "FirstName" && (m.FirstName.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                {
                    filteredMembers.Add(m);
                }
                else if (filterType == "SurName" && (m.SurName.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                {
                    filteredMembers.Add(m);
                }
                else if (filterType == "PhoneNumber" && (m.PhoneNumber.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                {
                    filteredMembers.Add(m);
                }
                //else if (m.Address.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                //{
                //    filteredMembers.Add(m);
                //}
                else if (filterType == "City" && (m.City.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                {
                    filteredMembers.Add(m);
                }
                else if (filterType == "Mail" && (m.Mail.Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase)))
                {
                    filteredMembers.Add(m);
                }
                //else if (m.TheMemberRole.ToString().Contains(filterCriteria, StringComparison.CurrentCultureIgnoreCase))
                //{
                //    filteredMembers.Add(m);
                //}
                else if (filterType == "All")
                {
                    filteredMembers.Add(m);
                }
            }
            return filteredMembers;
        }
        #endregion
    }
}

using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace TestBoatApp2026
{
    [TestClass]
    public sealed class BoatRepositoryAsyncTest
    {
        public TestContext TestContext { get; set; }
        public IMemberRepositoryAsync MemberRepo = new MemberRepositoryAsync();

        [TestMethod]
        public void GetMembersFromDatabaseAsyncTest()
        {
            List<Member> memberList = MemberRepo.GetAllMembersAsync().Result;

            //TestContext.WriteLine($"memberList count: {memberList.Count.ToString()}");
            //TestContext.WriteLine($"memberList content: {string.Join(", ",memberList)}");

            int expectedMemberCount = 2; //adjust according to member database size
            int resultMemberCount = memberList.Count;

            Assert.AreEqual(expectedMemberCount,resultMemberCount);
        }
    }
}

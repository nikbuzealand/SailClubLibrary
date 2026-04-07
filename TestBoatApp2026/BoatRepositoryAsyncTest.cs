using SailClubLibrary.Interfaces;
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
            MemberRepo.GetAllMembersAsync();
            TestContext.WriteLine("gorba");
        }
    }
}

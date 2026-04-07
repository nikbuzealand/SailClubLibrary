namespace SailClubLibrary.Services
{
    public abstract class Connection
    {
        protected string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SailClub2026;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
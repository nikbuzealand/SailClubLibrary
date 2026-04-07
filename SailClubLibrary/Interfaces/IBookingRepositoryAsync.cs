using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IBookingRepositoryAsync
    {
        Task AddBookingAsync(Booking booking);
        Task RemoveBookingAsync(Booking b);
      Task  <List<Booking>> GetAllBookingsAsync();
        Task UpdateBookingAsync(int id, Booking newBooking);
        Task PrintAllAsync();
       Task <int> GetBookingCountForMemberAsync(Member member);
        Task <Dictionary<string, int>> GetAllBookingsForMembersAsync();
    }
}

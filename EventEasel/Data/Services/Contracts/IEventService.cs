namespace EventEasel.Data.Services.Contracts
{
    using EventEasel.Data.Entities;

    public interface IEventService
    {
        Task<Event> GetById(int id);

        Task<IList<Event>> GetallByUser(string userId);

        Task<int> Create(string title, string description);
    }
}

namespace EventEasel.Data.Services
{
    using System.Collections.Generic;
    using EventEasel.Core;
    using EventEasel.Data.Entities;
    using EventEasel.Data.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _db;
        private readonly CurrentUserService _currentUserService;

        public EventService(ApplicationDbContext db, CurrentUserService currentUserService)
        {
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<int> Create(string title, string description)
        {
            var userEvent = new Event()
            {
                Title = title,
                Description = description,
                UserId = _currentUserService.GetId(),
            };

            _db.Events.Add(userEvent);
            await _db.SaveChangesAsync();

            return userEvent.Id;
        }

        public async Task<IList<Event>> GetallByUser(string userId)
            => await _db.Events
                .Where(e => e.User.Id == userId)
                .ToListAsync();

        public async Task<Event> GetById(int id)
            => await _db.Events
                .FirstOrDefaultAsync(e => e.Id == id);
    }
}

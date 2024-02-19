namespace EventEasel.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            Events = new List<Event>();
        }

        public IList<Event> Events;
    }
}

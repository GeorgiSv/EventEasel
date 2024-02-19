namespace EventEasel.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Event : BaseEntity<int>
    {
        public Event()
        {
            Photos = new List<Photo>();
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(600)]
        public string Description { get; set; }

        public bool IsEventPublic { get; set; }

        public bool ArePhotosPublic { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public IList<Photo> Photos { get; set; }
    }
}

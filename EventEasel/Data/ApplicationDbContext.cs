namespace EventEasel.Data
{
    using System.Linq;
    using EventEasel.Data.Entities;
    using EventEasel.Data.Entities.Contract;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().HasQueryFilter(e => !e.IsDeleted);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        private void ApplyAuditInfo()
            => ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.Entity is IAuditInfo deletableEntity && entry.State == EntityState.Deleted)
                    {
                        deletableEntity.IsDeleted = true;
                        deletableEntity.DeletedOn = DateTime.Now;

                        entry.State = EntityState.Modified;

                        return;
                    }

                    if (entry.Entity is IAuditInfo entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.Now;
                        }

                        if (entry.State == EntityState.Modified)
                        {
                            entity.UpdatedOn = DateTime.Now;
                        }

                        return;
                    }
                });
    }


}
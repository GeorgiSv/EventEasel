namespace EventEasel.Data.Entities
{
    using System;
    using EventEasel.Data.Entities.Contract;

    public abstract class BaseEntity<T> : IAuditInfo
    {
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}

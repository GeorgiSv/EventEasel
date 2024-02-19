namespace EventEasel.Data.Entities.Contract
{
    public interface IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}

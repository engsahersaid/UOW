namespace UOwPoc.Core.Entities.Base
{
    public abstract class BaseAuditableEntity : BaseEntity<Guid>
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime? lastUpdatedAt { get; set; }
        protected BaseAuditableEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        //Soft delete
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedAt { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }
    }
}
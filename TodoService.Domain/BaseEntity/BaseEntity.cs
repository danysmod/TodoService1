namespace TodoService.Domain
{
    using System;
    
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntityId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; } = null;
    }
}
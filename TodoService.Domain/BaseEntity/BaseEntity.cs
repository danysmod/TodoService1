namespace TodoService.Domain
{
    using System;
    
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntityId Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime EditDate { get; protected set; }
    }
}
namespace Domain
{
    using System;
    
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntityId Id { get; protected set; }
        public DateTime CreateTime { get; protected set; }
        public DateTime EditTime { get; protected set; }
    }
}
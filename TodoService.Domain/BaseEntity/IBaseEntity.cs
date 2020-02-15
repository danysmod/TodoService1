namespace Domain
{
    using System;
    public interface IBaseEntity
    {
        BaseEntityId Id { get; }
        DateTime CreateTime { get; }
        DateTime EditTime { get; }
    }
}
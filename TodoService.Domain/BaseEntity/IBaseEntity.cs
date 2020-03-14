namespace TodoService.Domain
{
    using System;
    public interface IBaseEntity
    {
        BaseEntityId Id { get; }
        DateTime CreateDate { get; }
        DateTime? EditDate { get; }
    }
}
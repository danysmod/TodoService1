namespace TodoService.Infrastructure.Entities
{
    using System;
    using TodoService.Domain;

    public class Account : Domain.Account
    {
        public Account()
        {
            Id = new BaseEntityId(Guid.NewGuid());
            CreateDate = DateTime.Now;
        }
    }
}

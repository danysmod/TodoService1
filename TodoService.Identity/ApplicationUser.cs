namespace TodoService.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using TodoService.Domain;

    public sealed class ApplicationUser : IdentityUser
    {
        public BaseEntityId AccountId { get; set; }
    }
}


namespace TodoService.Identity
{
    using Microsoft.AspNetCore.Identity;
    using TodoService.Domain;

    public class ApplicationUser : IdentityUser
    {
        public BaseEntityId AccountId { get; set; }
    }
}

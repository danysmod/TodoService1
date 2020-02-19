namespace API.UI.Account.Register
{
    using System.ComponentModel.DataAnnotations;
    
    public sealed class RegisterRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

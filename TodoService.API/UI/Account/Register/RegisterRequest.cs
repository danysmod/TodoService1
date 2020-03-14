namespace API.UI.Account
{
    using System.ComponentModel.DataAnnotations;
    
    public sealed class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}

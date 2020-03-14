namespace API.UI.Account
{
    using System.ComponentModel.DataAnnotations;
    
    public sealed class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

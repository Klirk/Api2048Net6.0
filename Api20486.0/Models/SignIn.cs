namespace Api20486._0.Models
{
    public class SignInRequest
    {
        public string? Login_user { get; set; }
        public string? Password_user { get; set; }
    }

    public class SignInResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}

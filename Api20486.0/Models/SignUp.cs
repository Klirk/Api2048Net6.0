namespace Api20486._0.Models
{
    public class SignUpRequest
    {
        public string? Login_user { get; set; }
        public string? Password_user { get; set; }
        public string? Password_confirmation { get; set; }
        public int Id_type { get; set; }
    }
    public class SignUpResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

}

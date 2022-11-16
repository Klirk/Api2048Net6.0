namespace Api20486._0.Models
{
    public class SignUpRequest
    {
        //UserName, PassWord, Role
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfigPassword { get; set; }
        public int IdType { get; set; }
    }

    public class SignUpResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}

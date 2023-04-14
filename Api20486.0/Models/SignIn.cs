using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api20486._0.Models
{
    public class SignInRequest
    {
        public string? Login_user { get; set; }
        public string? Password_user { get; set; }
    }

    public class SignInResponse
    {
        public int Id_user { get; set; }
        public int Id_type { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        
    }
    public class GetUserId {
        [Key]
        public int Id_user { get; set; }
    }

    public class GetUserType
    {
        [Key]
        public int Id_type { get; set; }
    }

}

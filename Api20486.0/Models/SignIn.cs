using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api20486._0.Models
{
    public class SignInRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class SignInResponse
    {
        public IEnumerable<GetUserId>? Id_user { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        
    }
    public class GetUserId {
        [Key]
        public int Id_user { get; set; }
    }

}

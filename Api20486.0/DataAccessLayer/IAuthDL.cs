using Api20486._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Api20486._0.DataAccessLayer
{
    public interface IAuthDL
    {
        public Task<SignUpResponse> SignUp(SignUpRequest request);

        public Task<SignInResponse> SignIn(SignInRequest request);

        
    }
}
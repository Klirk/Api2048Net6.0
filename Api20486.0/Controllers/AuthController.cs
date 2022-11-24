using Api20486._0.Context;
using Api20486._0.DataAccessLayer;
using Api20486._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api20486._0.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthDL _authDL;
        private AnimesContext _animeContext;
        public AuthController(IAuthDL authDL, AnimesContext animeContext)
        {
            _authDL = authDL;
            _animeContext = animeContext;
        }


        //Post Regisration//
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            try
            {
                response = await _authDL.SignUp(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        //Post Autorization//   
        [HttpPost]
        public async Task<ActionResult> SignIn(SignInRequest request)
        {
            IEnumerable<GetUserId> ids = _animeContext.GetUserIds.FromSqlRaw($"GetId {request.Login_user}");

            SignInResponse response = new SignInResponse();
            try
            {
                response = await _authDL.SignIn(request);
                response.Id_user = ids.First().Id_user;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
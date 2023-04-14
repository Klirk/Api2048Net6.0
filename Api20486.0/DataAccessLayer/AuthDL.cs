using Api20486._0.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;


namespace Api20486._0.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _mySqlConnection;

        public AuthDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mySqlConnection = new SqlConnection(_configuration["ConnectionStrings:MySqlDBConnectionString"]);
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "";
            try
            {

                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                string SqlQuery = @"SignIn";

                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@login_user", request.Login_user);
                    sqlCommand.Parameters.AddWithValue("@password_user", request.Password_user);
                    using (DbDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            response.Message = "Login Successfully";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Login Unsuccessfully";
                            return response;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { _mySqlConnection.Close(); }
            return response;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                if (request.Password_user != request.Password_confirmation)
                {
                    response.IsSuccess = false;
                    response.Message = "Password & Confirm Password not Match";
                    return response;
                }
                if (request.Id_type != 2 && request.Id_type == 1)
                {
                    response.IsSuccess = false;
                    response.Message = "U cant registation admin";
                    return response;
                }

                string SqlQuery = @"SignUp";

                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@login_user", request.Login_user);
                    sqlCommand.Parameters.AddWithValue("@password_user", request.Password_user);
                    sqlCommand.Parameters.AddWithValue("@id_type", request.Id_type);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { _mySqlConnection.Close(); }

            return response;
        }
    }
}
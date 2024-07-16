using CollegeManagmentSystem.Application.Interfaces.IRepositorys;
using CollegeManagmentSystem.Application.ProcedureName;
using CollegeManagmentSystem.Infrastructure.Data;
using CollegeManagmentSystemAssignment.Domain.Entity;
using Dapper;
using System.Data;

namespace CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Repositorys
{
    public class UserSignUpRepository : IUserSignUpRepository
    {
        private readonly DapperContext _dapperContext;

        public UserSignUpRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ResponseModal> CreateSignUp(UserSignupModal userSignupModal)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = SharedProcedure.UpdateAndSaveSignUpDetails;

                    var parameter = new
                    {
                        Id = userSignupModal.UserId,
                        userSignupModal.FirstName,
                        userSignupModal.LastName,
                        userSignupModal.PhoneNumber,
                        userSignupModal.Country,
                        userSignupModal.State,
                        userSignupModal.Gender,
                        userSignupModal.Email,
                        userSignupModal.Password
                    };

                    await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                    return new ResponseModal { Data = StaticData.data, Message = StaticData.CreateSuccessMessage, StatusCode = StaticData.statusCode};
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseModal { Data = StaticData.data, Message = StaticData.errorMessage, StatusCode = StaticData.errorStatusCode };
            }
        }

        public async Task<ResponseModal> DeleteRecord(int id)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    connection.Open();
                    var query = SharedProcedure.DelteSignUpDetails;
                    var param = new
                    {
                        Id = id,
                    };

                    await connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return new ResponseModal { Data = StaticData.data, Message = StaticData.deleteSuccessMessage, StatusCode = StaticData.statusCode };
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new ResponseModal { Data = StaticData.data, Message = StaticData.errorMessage, StatusCode = StaticData.errorStatusCode };
            }

        }

        public async Task<IEnumerable<UserSignupModal>> GetAllSignUpDetails()
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = SharedProcedure.GetAllSignUpDetails;
                    return await connection.QueryAsync<UserSignupModal>(query, commandType: CommandType.StoredProcedure);
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<UserSignupModal>();
            }

        }

        public async Task<ResponseModal> UpdateSignUpDetails(UserSignupModal userSignupModal)
        {
            try
            {
                using(var connnection = _dapperContext.CreateConnection())
                {
                    var query = SharedProcedure.UpdateAndSaveSignUpDetails;
                    var param = new
                    {
                        Id = userSignupModal.UserId,
                        userSignupModal.FirstName,
                        userSignupModal.LastName,
                        userSignupModal.PhoneNumber,
                        userSignupModal.Email,
                        userSignupModal.Password,
                        userSignupModal.Country,
                        userSignupModal.State,
                        userSignupModal.Gender,
                    };
                    await connnection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                    return new ResponseModal { StatusCode = StaticData.statusCode, Data = StaticData.data, Message = StaticData.UpdateSuccessMessage };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseModal { StatusCode = StaticData.errorStatusCode, Data = StaticData.data, Message = StaticData.errorMessage };
            }
        }

        public async Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = SharedProcedure.ValidatingEmailAndPassword;

                    var param = new { emailAndPassword.Email, emailAndPassword.Password };

                    return await connection.QueryFirstOrDefaultAsync<int>(query, param, commandType: CommandType.StoredProcedure);
                    
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
    }
}

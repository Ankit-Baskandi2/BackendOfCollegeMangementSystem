using CollegeManagmentSystem.Application.Interfaces.IRepositorys;
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

        public async Task<int> CreateSignUp(UserSignupModal userSignupModal)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = "SP_SignUp_Ankit";

                    var parameter = new
                    {
                        userSignupModal.FirstName,
                        userSignupModal.LastName,
                        userSignupModal.PhoneNumber,
                        userSignupModal.Country,
                        userSignupModal.State,
                        userSignupModal.Gender,
                        userSignupModal.Email,
                        userSignupModal.Password
                    };

                    var message = await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                    return message;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public void DeleteRecord(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var query = "UP_DelteSignUpDetail";
                var param = new
                {
                    Id = id,
                };

                connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserSignupModal>> GetAllSignUpDetails()
        {
           using(var connection = _dapperContext.CreateConnection())
            {
                var query = "UP_GetAllSignUpDetails";
                return await connection.QueryAsync<UserSignupModal>(query, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateSignUpDetails(UserSignupModal userSignupModal)
        {
            try
            {
                using(var connnection = _dapperContext.CreateConnection())
                {
                    var query = "UP_InsertAndUpdate";
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "UP_ValidateUserLogin";

                var param = new { emailAndPassword.Email, emailAndPassword.Password };

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}

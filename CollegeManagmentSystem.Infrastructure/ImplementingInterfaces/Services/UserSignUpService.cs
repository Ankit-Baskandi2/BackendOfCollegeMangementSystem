using CollegeManagmentSystem.Application.Interfaces.IRepositorys;
using CollegeManagmentSystem.Application.Interfaces.IServices;
using CollegeManagmentSystemAssignment.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Services
{
    public class UserSignUpService : IUserSignUpService
    {
        private readonly IUserSignUpRepository _userSignUpRepository;
        private readonly IConfiguration _config;

        public UserSignUpService(IUserSignUpRepository userSignUpRepository, IConfiguration configuration)
        {
            _userSignUpRepository = userSignUpRepository;
            _config = configuration;
        }

        public async Task<IEnumerable<UserSignupModal>> GetAllSignupDetails()
        {
            return await _userSignUpRepository.GetAllSignUpDetails();
        }

        public async Task<ResponseModal> SaveSignUpDetails(UserSignupModal userSignupModal)
        {
            return await _userSignUpRepository.CreateSignUp(userSignupModal);
        }

        public async Task<ResponseModal> UpdateSignUpDetails(UserSignupModal userSignupModal)
        {
            return await _userSignUpRepository.UpdateSignUpDetails(userSignupModal);
        }

        public async Task<ResponseModal> DeleteRecord(int id)
        {
            return await _userSignUpRepository.DeleteRecord(id);
        }

        public async Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword)
        {
            return await _userSignUpRepository.ValidatingUserEmailAndPassword(emailAndPassword);
        }

        public string GenerateToken(EmailAndPasswordModal userEmailAndPassword)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

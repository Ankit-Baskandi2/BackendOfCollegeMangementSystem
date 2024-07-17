using CollegeManagmentSystemAssignment.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Services
{
    public class TokenGenerationService
    {
        private readonly IConfiguration _config;

        public TokenGenerationService(IConfiguration configuration)
        {
            _config = configuration;
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

using CollegeManagmentSystem.Application.Interfaces.IServices;
using CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Services;
using CollegeManagmentSystemAssignment.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagmentSystemAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class UserSignUpController : ControllerBase
    {
        private readonly IUserSignUpService _userSignUpService;
        private readonly IConfiguration _config;

        public UserSignUpController(IUserSignUpService userSignUpService, IConfiguration config)
        {
            _userSignUpService = userSignUpService;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserSignUpDetails()
        {
            return Ok(await _userSignUpService.GetAllSignupDetails());
        }

        [HttpPost]
        [Route("SavingSignUpDetails")]
        public async Task<IActionResult> SavingDetails([FromBody] UserSignupModal userSignupModal)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _userSignUpService.SaveSignUpDetails(userSignupModal));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatingSignUpDetails(UserSignupModal userSignupModal)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _userSignUpService.UpdateSignUpDetails(userSignupModal));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userSignUpService.DeleteRecord(id));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("UserValidation")]
        public async Task<IActionResult> UserValidation([FromBody] EmailAndPasswordModal emailAndPassword)
        {
            if (!ModelState.IsValid)
                BadRequest(new ResponseModal { StatusCode = StaticData.errorStatusCode, Message = StaticData.errorMessage, Data = StaticData.data});

            var result = await _userSignUpService.ValidatingUserEmailAndPassword(emailAndPassword);

            if(result == 1)
            {
                TokenGenerationService tokenGeneration = new TokenGenerationService(_config);
                var token = tokenGeneration.GenerateToken(emailAndPassword);
                return Ok(new ResponseModal { StatusCode = StaticData.statusCode, Message = StaticData.successMessage, Data = token });
            }
            return BadRequest(new ResponseModal { StatusCode = StaticData.errorStatusCode, Message = StaticData.errorMessage, Data = StaticData.data});
        }
    }
}

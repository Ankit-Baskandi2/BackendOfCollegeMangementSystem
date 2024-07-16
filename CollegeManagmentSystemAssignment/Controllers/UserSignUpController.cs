using CollegeManagmentSystem.Application.Interfaces.IServices;
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

        public UserSignUpController(IUserSignUpService userSignUpService)
        {
            _userSignUpService = userSignUpService;
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
                BadRequest(new ResponseModal { StatusCode = 500, Message="Please Fill Email and Password", Data = null});

            var result = await _userSignUpService.ValidatingUserEmailAndPassword(emailAndPassword);

            if(result == 1)
            {
                var token = _userSignUpService.GenerateToken(emailAndPassword);
                return Ok(new ResponseModal { StatusCode = 200, Message = StaticData.successMessage, Data = token });
            }
            return BadRequest(new ResponseModal { StatusCode = 500, Message = "Incorrect Email and Password", Data=null});
        }
    }
}

using CollegeManagmentSystem.Application.Interfaces.IServices;
using CollegeManagmentSystemAssignment.Domain.Entity;
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
            var result = await _userSignUpService.SaveSignUpDetails(userSignupModal);
            if(result == 2)
                return Ok(new ResponseModal { StatusCode = 200, Data = null, Message = "Data Saved Submitted" });
            return BadRequest(new ResponseModal { StatusCode = 401, Message = "Something Went Wrong", Data = null});
        }

        [HttpPut]
        public async Task<IActionResult> UpdatingSignUpDetails(UserSignupModal userSignupModal)
        {
            return Ok(await _userSignUpService.UpdateSignUpDetails(userSignupModal));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _userSignUpService.DeleteRecord(id);
        }

        [HttpPost]
        [Route("UserValidation")]
        public async Task<IActionResult> UserValidation([FromBody] EmailAndPasswordModal emailAndPassword)
        {
            if (!ModelState.IsValid) BadRequest();
            var result = await _userSignUpService.ValidatingUserEmailAndPassword(emailAndPassword);

            if (result == 0) return Unauthorized(new ResponseModal { StatusCode = 401,
                Message = "Enter Correct Email And Password", Data = null});
            return Ok(new ResponseModal { StatusCode = 200, Message = "Welcome", Data = null });
        }
    }
}

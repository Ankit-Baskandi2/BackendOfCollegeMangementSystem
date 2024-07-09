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
            return Ok(await _userSignUpService.SaveSignUpDetails(userSignupModal));
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
    }
}

using CollegeManagmentSystem.Application.Interfaces.IRepositorys;
using CollegeManagmentSystem.Application.Interfaces.IServices;
using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Services
{
    public class UserSignUpService : IUserSignUpService
    {
        private readonly IUserSignUpRepository _userSignUpRepository;

        public UserSignUpService(IUserSignUpRepository userSignUpRepository)
        {
            _userSignUpRepository = userSignUpRepository;
        }

        public async Task<IEnumerable<UserSignupModal>> GetAllSignupDetails()
        {
            return await _userSignUpRepository.GetAllSignUpDetails();
        }

        public async Task<int> SaveSignUpDetails(UserSignupModal userSignupModal)
        {
            var message = await _userSignUpRepository.CreateSignUp(userSignupModal);
            return message;
        }

        public async Task<bool> UpdateSignUpDetails(UserSignupModal userSignupModal)
        {
            return await _userSignUpRepository.UpdateSignUpDetails(userSignupModal);
        }

        public void DeleteRecord(int id)
        {
            _userSignUpRepository.DeleteRecord(id);
        }

        public async Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword)
        {
            return await _userSignUpRepository.ValidatingUserEmailAndPassword(emailAndPassword);
        }
    }
}

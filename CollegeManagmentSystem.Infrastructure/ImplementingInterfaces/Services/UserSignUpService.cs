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

        public async Task<ResponseModal> GetAllSignupDetails()
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
    }
}

using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Application.Interfaces.IServices
{
    public interface IUserSignUpService
    {
        Task<int> SaveSignUpDetails(UserSignupModal userSignupModal);
        Task<IEnumerable<UserSignupModal>> GetAllSignupDetails();
        void DeleteRecord(int id);
        Task<bool> UpdateSignUpDetails(UserSignupModal userSignupModal);
        Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword);
    }
}

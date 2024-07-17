using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Application.Interfaces.IServices
{
    public interface IUserSignUpService
    {
        Task<ResponseModal> SaveSignUpDetails(UserSignupModal userSignupModal);
        Task<ResponseModal> GetAllSignupDetails();
        Task<ResponseModal> DeleteRecord(int id);
        Task<ResponseModal> UpdateSignUpDetails(UserSignupModal userSignupModal);
        Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword);
    }
}

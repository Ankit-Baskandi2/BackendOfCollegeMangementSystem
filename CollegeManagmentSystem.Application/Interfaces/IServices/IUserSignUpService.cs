using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Application.Interfaces.IServices
{
    public interface IUserSignUpService
    {
        Task<ResponseModal> SaveSignUpDetails(UserSignupModal userSignupModal);
        Task<IEnumerable<UserSignupModal>> GetAllSignupDetails();
        Task<ResponseModal> DeleteRecord(int id);
        Task<ResponseModal> UpdateSignUpDetails(UserSignupModal userSignupModal);
        Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword);
        string GenerateToken(EmailAndPasswordModal userEmailAndPassword);
    }
}

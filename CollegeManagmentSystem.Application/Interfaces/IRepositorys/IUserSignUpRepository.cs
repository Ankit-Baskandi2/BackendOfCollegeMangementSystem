using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Application.Interfaces.IRepositorys
{
    public interface IUserSignUpRepository
    {
        Task<ResponseModal> CreateSignUp(UserSignupModal userSignupModal);
        Task<IEnumerable<UserSignupModal>> GetAllSignUpDetails();
        Task<ResponseModal> DeleteRecord(int id);
        Task<ResponseModal> UpdateSignUpDetails(UserSignupModal userSignupModal);
        Task<int> ValidatingUserEmailAndPassword(EmailAndPasswordModal emailAndPassword);
    }
}

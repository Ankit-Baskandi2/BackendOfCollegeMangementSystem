using CollegeManagmentSystemAssignment.Domain.Entity;

namespace CollegeManagmentSystem.Application.Interfaces.IRepositorys
{
    public interface IUserSignUpRepository
    {
        Task<int> CreateSignUp(UserSignupModal userSignupModal);
        Task<IEnumerable<UserSignupModal>> GetAllSignUpDetails();
        void DeleteRecord(int id);
        Task<bool> UpdateSignUpDetails(UserSignupModal userSignupModal);
    }
}

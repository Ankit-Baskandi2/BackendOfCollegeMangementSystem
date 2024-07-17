

namespace CollegeManagmentSystemAssignment.Domain.Entity
{
    public class ResponseModal
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}

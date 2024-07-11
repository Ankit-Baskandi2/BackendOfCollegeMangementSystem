using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagmentSystemAssignment.Domain.Entity
{
    public class ResponseModal
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
    }
}

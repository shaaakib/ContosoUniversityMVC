using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [ValidateNever]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

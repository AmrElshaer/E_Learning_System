

using Mediator.Net.Contracts;

namespace ELearning.Application.Student.Commonds.CreatEditStudent
{
    public class CreatEditStudentCommond : IRequest
    {
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int DegreePursued { get; set; }
        public string ClassStandingCode { get; set; }
        public string StudentStatus { get; set; }
        public string EnrollmentTerm { get; set; }
    }
}

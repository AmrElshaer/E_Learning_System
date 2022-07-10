using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.Student.Queries
{
    public class StudentDto : IMapFrom
    {
        public int StudentId { get; set; }
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Student, StudentDto>();
        }
    }
}

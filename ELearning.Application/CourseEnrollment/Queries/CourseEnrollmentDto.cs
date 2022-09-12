using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.CourseEnrollment.Queries
{
    public class CourseEnrollmentDto : IMapFrom
    {
        public int? CourseEnrollmentId { get; set; }
        public int CourseOfferingId { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.CourseEnrollment, CourseEnrollmentDto>()
                .ForMember(d => d.StudentName,
                    s => s.MapFrom(ce => ce.Student.FirstName + ce.Student.LastName))
                .ForMember(d => d.CourseName,
                    s => s.MapFrom(ce => ce.CourseOffering.Cours.CourseTitle));
        }
    }
}

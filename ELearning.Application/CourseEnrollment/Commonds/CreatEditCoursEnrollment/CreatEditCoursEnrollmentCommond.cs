using Mediator.Net.Contracts;

namespace ELearning.Application.CourseEnrollment.Commonds.CreatEditCoursEnrollment
{
    public class CreatEditCoursEnrollmentCommond : IRequest
    {
        public int? CourseEnrollmentId { get; set; }
        public int CourseOfferingId { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
    }
}

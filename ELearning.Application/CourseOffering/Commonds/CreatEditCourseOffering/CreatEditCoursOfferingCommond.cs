using ELearning.Application.Course.Queries;
using ELearning.Application.Term.Queries;
using Mediator.Net.Contracts;

namespace ELearning.Application.CourseOffering.Commonds.CreatEditCourseOffering
{
    public class CreatEditCoursOfferingCommond : IRequest
    {
        public int? CourseOfferingId { get; set; }
        public int Section { get; set; }
        public int Capacity { get; set; }
        public int CourseNumber { get; set; }
        public CourseDto Cours { get; set; }
        public int? TermId { get; set; }
        public TermDto Term { get; set; }
    }
}

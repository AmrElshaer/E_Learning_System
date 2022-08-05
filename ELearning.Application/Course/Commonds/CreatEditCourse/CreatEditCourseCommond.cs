using Mediator.Net.Contracts;

namespace ELearning.Application.Course.Commonds.CreatEditCourse
{
    public class CreatEditCourseCommond : IRequest
    {
        public string DepartmentCode { get; set; }
        public int? CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public decimal Credits { get; set; }
        public int? MaximumSectionSize { get; set; }
    }
}

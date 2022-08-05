using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.Course.Queries
{
    public class CourseDto : IMapFrom
    {
        public string DepartmentCode { get; set; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public decimal Credits { get; set; }
        public int? MaximumSectionSize { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Cours, CourseDto>();
        }
    }
}

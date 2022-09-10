using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.CourseOffering.Queries
{
    public class CourseOfferingDto : IMapFrom
    {
        public int CourseOfferingId { get; set; }
        public int Section { get; set; }
        public int Capacity { get; set; }
        public int CourseNumber { get; set; }
        public int? TermId { get; set; }
        public string TermCode { get; set; }
        public string CourseName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.CourseOffering, CourseOfferingDto>()
                .ForMember(d => d.CourseName
                    , s => s.MapFrom(o => o.Cours.CourseTitle))
                .ForMember(d => d.TermCode, s => s.MapFrom(o => o.Term.TermCode));
        }
    }
}

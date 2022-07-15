using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.Degree.Queries
{
    public class DegreeDto : IMapFrom
    {
        public int DegreeId { get; set; }
        public string DepartmentCode { get; set; }
        public string DegreeTypeCode { get; set; }
        public string DegreeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Degree, DegreeDto>();
        }
    }
}

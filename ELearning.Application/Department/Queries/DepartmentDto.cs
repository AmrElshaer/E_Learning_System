using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.Department.Queries
{
    public class DepartmentDto : IMapFrom
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ELearning.Domain.Department, DepartmentDto>();
        }
    }
}

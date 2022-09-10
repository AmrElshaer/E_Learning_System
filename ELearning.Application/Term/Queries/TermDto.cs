using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application.Term.Queries
{
    public class TermDto : IMapFrom
    {
        public string TermCode { get; set; }
        public string SessionCode { get; set; }
        public int Year { get; set; }
        public int TermId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Term, TermDto>();
        }
    }
}

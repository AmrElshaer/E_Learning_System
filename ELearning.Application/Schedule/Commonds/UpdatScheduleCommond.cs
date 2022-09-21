using ELearning.Application.Schedule.Queries;
using Mediator.Net.Contracts;
using System.Collections.Generic;

namespace ELearning.Application.Schedule.Commonds
{
    public class UpdatScheduleCommond : IRequest
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<ScheduleEventDto> added { get; set; }
        public List<ScheduleEventDto> changed { get; set; }
        public List<ScheduleEventDto> deleted { get; set; }
        public ScheduleEventDto value { get; set; }
    }
}

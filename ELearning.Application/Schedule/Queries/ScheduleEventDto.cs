using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;
using System;

namespace ELearning.Application.Schedule.Queries
{
    public class ScheduleEventDto : IMapFrom
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Subject { get; set; }
        public DateTimeOffset? StartTimezone { get; set; }
        public DateTime? EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool? IsAllDay { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ScheduleEventData, ScheduleEventDto>();
        }
    }
}

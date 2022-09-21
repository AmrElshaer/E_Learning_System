using AutoMapper;
using AutoMapper.QueryableExtensions;
using ELearning.Application.Schedule.Queries;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Schedule.Commonds
{
    public class UpdateScheduleRespone : IResponse
    {
        public UpdateScheduleRespone(IList<ScheduleEventDto> schedules)
        {
            Schedules = schedules;
        }

        public IList<ScheduleEventDto> Schedules { get; set; }
    }
    public class UpdatScheduleCommondHandler : IRequestHandler<UpdatScheduleCommond, UpdateScheduleRespone>
    {
        private readonly StudentsEntities db;
        private readonly IMapper _mapper;

        public UpdatScheduleCommondHandler(StudentsEntities dbContext, IMapper mapper)
        {
            this.db = dbContext;
            _mapper = mapper;
        }
        public async Task<UpdateScheduleRespone> Handle(IReceiveContext<UpdatScheduleCommond> context, CancellationToken cancellationToken)
        {
            var param = context.Message;
            if (IsInsert(param)) InsertAppointment(param);
            if (IsUpdated(param)) await UpdateAppointment(param);
            if (IsDeleted(param)) await DeletApointment(param);
            await db.SaveChangesAsync();
            var res = await db.ScheduleEventDatas.ProjectTo<ScheduleEventDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new UpdateScheduleRespone(res);

        }

        private static bool IsDeleted(UpdatScheduleCommond param)
        {
            return param.action == "remove" || (param.action == "batch" && param.deleted != null);
        }

        private static bool IsUpdated(UpdatScheduleCommond param)
        {
            return param.action == "update" || (param.action == "batch" && param.changed != null);
        }

        private bool IsInsert(UpdatScheduleCommond param)
        {
            return param.action == "insert" || (param.action == "batch" && param.added != null);
        }

        private async Task DeletApointment(UpdatScheduleCommond param)
        {
            if (param.action == "remove")
            {
                int key = Convert.ToInt32(param.key);
                ScheduleEventData appointment = await db.ScheduleEventDatas.FindAsync(key);
                if (appointment != null) db.ScheduleEventDatas.Remove(appointment);
            }
            else
            {
                foreach (var apps in param.deleted)
                {
                    ScheduleEventData appointment = await db.ScheduleEventDatas.FindAsync(apps.Id);
                    if (appointment != null) db.ScheduleEventDatas.Remove(appointment);
                }
            }
        }

        private async Task UpdateAppointment(UpdatScheduleCommond param)
        {
            var value = (param.action == "update") ? param.value : param.changed[0];
            var appointment = await db.ScheduleEventDatas.FindAsync(value.Id);
            if (appointment != null)
            {
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                appointment.StartTime = startTime;
                appointment.EndTime = endTime;
                appointment.StartTimezone = value.StartTimezone;
                appointment.EndTimezone = value.EndTimezone;
                appointment.Subject = value.Subject;
                appointment.IsAllDay = value.IsAllDay;
                appointment.RecurrenceRule = value.RecurrenceRule;
                appointment.RecurrenceID = value.RecurrenceID;
                appointment.RecurrenceException = value.RecurrenceException;
            }
        }

        private void InsertAppointment(UpdatScheduleCommond param)
        {
            var value = (param.action == "insert") ? param.value : param.added[0];
            DateTime startTime = Convert.ToDateTime(value.StartTime);
            DateTime endTime = Convert.ToDateTime(value.EndTime);
            ScheduleEventData appointment = new ScheduleEventData()
            {
                StartTime = startTime,
                EndTime = endTime,
                Subject = value.Subject,
                IsAllDay = value.IsAllDay,
                StartTimezone = value.StartTimezone,
                EndTimezone = value.EndTimezone,
                RecurrenceRule = value.RecurrenceRule,
                RecurrenceID = value.RecurrenceID,
                RecurrenceException = value.RecurrenceException
            };
            db.ScheduleEventDatas.Add(appointment);
        }
    }
}

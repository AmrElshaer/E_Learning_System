using Ardalis.GuardClauses;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.CourseOffering.Commonds.DeletCourseOffering
{
    public class DeletCoursOfferingCommond : ICommand
    {
        public int CourseOfferingId { get; set; }
        public class DeletStudentCommondHandler : ICommandHandler<DeletCoursOfferingCommond>
        {
            private readonly StudentsEntities _context;

            public DeletStudentCommondHandler(StudentsEntities context)
            {
                this._context = context;
            }
            public async Task Handle(IReceiveContext<DeletCoursOfferingCommond> context, CancellationToken cancellationToken)
            {
                var courseOffering = await _context.CourseOfferings.FindAsync(context.Message.CourseOfferingId);
                Guard.Against.Null(courseOffering, nameof(context.Message.CourseOfferingId));
                _context.CourseOfferings.Remove(courseOffering);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Ardalis.GuardClauses;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.CourseEnrollment.Commonds.DeletCoursEnrollment
{
    public class DeletCoursEnrollCommond : ICommand
    {
        public int CourseEnrollId { get; set; }
        public class DeletCoursEnrollCommondHandler : ICommandHandler<DeletCoursEnrollCommond>
        {
            private readonly StudentsEntities _context;

            public DeletCoursEnrollCommondHandler(StudentsEntities context)
            {
                this._context = context;
            }
            public async Task Handle(IReceiveContext<DeletCoursEnrollCommond> context, CancellationToken cancellationToken)
            {
                var courseEnrollment = await _context.CourseEnrollments.FindAsync(context.Message.CourseEnrollId);
                Guard.Against.Null(courseEnrollment, nameof(context.Message.CourseEnrollId));
                _context.CourseEnrollments.Remove(courseEnrollment);
                await _context.SaveChangesAsync();
            }
        }
    }
}

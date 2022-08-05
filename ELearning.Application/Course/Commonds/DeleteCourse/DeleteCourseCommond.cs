using Ardalis.GuardClauses;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Course.Commonds.DeleteCourse
{
    public class DeleteCourseCommond : ICommand
    {
        public int CourseNumber { get; set; }
        public class DeletCourseCommondHandler : ICommandHandler<DeleteCourseCommond>
        {
            private readonly StudentsEntities _context;

            public DeletCourseCommondHandler(StudentsEntities context)
            {
                this._context = context;
            }
            public async Task Handle(IReceiveContext<DeleteCourseCommond> context, CancellationToken cancellationToken)
            {
                var std = await _context.Students.FindAsync(context.Message.CourseNumber);
                Guard.Against.Null(std, nameof(context.Message.CourseNumber));
                _context.Students.Remove(std);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Ardalis.GuardClauses;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Student.Commonds.DeletStudent
{
    public class DeletStudentCommond : ICommand
    {
        public int StudentId { get; set; }
        public class DeletStudentCommondHandler : ICommandHandler<DeletStudentCommond>
        {
            private readonly StudentsEntities _context;

            public DeletStudentCommondHandler(StudentsEntities context)
            {
                this._context = context;
            }
            public async Task Handle(IReceiveContext<DeletStudentCommond> context, CancellationToken cancellationToken)
            {
                var std = await _context.Students.FindAsync(context.Message.StudentId, cancellationToken);
                Guard.Against.Null(std, nameof(context.Message.StudentId));
                _context.Students.Remove(std);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

using Ardalis.GuardClauses;
using ELearning.Application.Common.Commond;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Student.Commonds.CreatEditStudent
{

    public class CreatEditStudentCommondHandler : IRequestHandler<CreatEditStudentCommond, BaseEntity<int>>
    {
        private readonly StudentsEntities _dbContext;

        public CreatEditStudentCommondHandler(StudentsEntities dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<BaseEntity<int>> Handle(IReceiveContext<CreatEditStudentCommond> context, CancellationToken cancellationToken)
        {
            ELearning.Domain.Student std;
            if (context.Message.StudentId.HasValue)
            {
                var entity = await _dbContext.Students.FindAsync(context.Message.StudentId.Value);
                Guard.Against.Null(entity, nameof(context.Message.StudentId), "Not Found This Student");
                std = entity;
            }
            else
            {
                std = new Domain.Student();
                _dbContext.Students.Add(std);
            }
            std.FirstName = context.Message.FirstName;
            std.LastName = context.Message.LastName;
            await _dbContext.SaveChangesAsync();
            return new BaseEntity<int>(std.StudentId);
        }
    }
}

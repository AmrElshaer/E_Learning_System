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
            try
            {
                var req = context.Message;
                ELearning.Domain.Student std;
                if (req.StudentId.HasValue)
                {
                    var entity = await _dbContext.Students.FindAsync(req.StudentId.Value);
                    Guard.Against.Null(entity, nameof(req.StudentId), "Not Found This Student");
                    std = entity;
                }
                else
                {
                    std = new Domain.Student();
                    _dbContext.Students.Add(std);
                }
                std.FirstName = req.FirstName;
                std.LastName = req.LastName;
                std.DegreePursued = req.DegreePursued;
                std.Telephone = req.Telephone;
                std.DateOfBirth = req.DateOfBirth.Value;
                std.email = req.email;
                std.StreetAddress = req.StreetAddress;
                await _dbContext.SaveChangesAsync();
                return new BaseEntity<int>(std.StudentId);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
    }
}

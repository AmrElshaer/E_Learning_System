using Ardalis.GuardClauses;
using ELearning.Application.Common.Commond;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.CourseEnrollment.Commonds.CreatEditCoursEnrollment
{
    public class CreatEditCoursEnrollCommondHandler : IRequestHandler<CreatEditCoursEnrollmentCommond, BaseEntity<int>>
    {
        private readonly StudentsEntities _dbContext;

        public CreatEditCoursEnrollCommondHandler(StudentsEntities dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseEntity<int>> Handle(IReceiveContext<CreatEditCoursEnrollmentCommond> context, CancellationToken cancellationToken)
        {

            var req = context.Message;
            //var enrollment = await _dbContext.CourseEnrollments.FirstOrDefaultAsync(e =>
            //    e.CourseOfferingId == req.CourseEnrollmentId && e.StudentId == req.StudentId);
            ELearning.Domain.CourseEnrollment courseEnrollment;
            if (req.CourseEnrollmentId.HasValue)
            {
                var entity = await _dbContext.CourseEnrollments.FindAsync(req.CourseEnrollmentId.Value);
                Guard.Against.Null(entity, nameof(req.CourseEnrollmentId), "Not Found This Student");
                courseEnrollment = entity;
            }
            else
            {
                courseEnrollment = new Domain.CourseEnrollment();
                _dbContext.CourseEnrollments.Add(courseEnrollment);
            }

            courseEnrollment.StudentId = req.StudentId;
            courseEnrollment.CourseOfferingId = req.CourseOfferingId;
            courseEnrollment.Grade = req.Grade;
            await _dbContext.SaveChangesAsync();
            return new BaseEntity<int>(courseEnrollment.CourseOfferingId);

        }




    }
}

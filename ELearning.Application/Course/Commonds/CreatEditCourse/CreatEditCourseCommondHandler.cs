using Ardalis.GuardClauses;
using ELearning.Application.Common.Commond;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Syncfusion.EJ2.Linq;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Course.Commonds.CreatEditCourse
{
    public class CreatEditCourseCommondHandler : IRequestHandler<CreatEditCourseCommond, BaseEntity<int>>
    {
        private readonly StudentsEntities _dbContext;

        public CreatEditCourseCommondHandler(StudentsEntities dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<BaseEntity<int>> Handle(IReceiveContext<CreatEditCourseCommond> context, CancellationToken cancellationToken)
        {
            try
            {
                var req = context.Message;
                ELearning.Domain.Cours cours;
                if (req.CourseNumber.HasValue)
                {
                    var entity = await _dbContext.Courses.FirstOrDefaultAsync(c => c.CourseNumber == req.CourseNumber.Value);
                    Guard.Against.Null(entity, nameof(req.CourseNumber), "Not Found This Student");
                    cours = entity;
                }
                else
                {
                    cours = new Domain.Cours();
                    cours.CourseNumber = await GenerateCourseNumber();
                    _dbContext.Courses.Add(cours);
                }
                cours.CourseDescription = req.CourseDescription;
                cours.CourseTitle = req.CourseTitle;
                cours.MaximumSectionSize = req.MaximumSectionSize;
                cours.DepartmentCode = req.DepartmentCode;
                cours.Credits = req.Credits;
                await _dbContext.SaveChangesAsync();
                return new BaseEntity<int>(cours.CourseNumber);
            }
            catch (System.Exception exception)
            {

                throw;
            }
        }

        private async Task<int> GenerateCourseNumber()
        {
            return (await _dbContext.Courses.OrderByDescending(c => c.CourseNumber).FirstOrDefaultAsync())?.CourseNumber + 1 ?? 1;
        }
    }
}

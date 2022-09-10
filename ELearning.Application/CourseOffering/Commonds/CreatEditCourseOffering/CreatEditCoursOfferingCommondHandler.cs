using Ardalis.GuardClauses;
using ELearning.Application.Common.Commond;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.CourseOffering.Commonds.CreatEditCourseOffering
{
    public class CreatEditCoursOfferingCommondHandler : IRequestHandler<CreatEditCoursOfferingCommond, BaseEntity<int>>
    {
        private readonly StudentsEntities _dbContext;

        public CreatEditCoursOfferingCommondHandler(StudentsEntities dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseEntity<int>> Handle(IReceiveContext<CreatEditCoursOfferingCommond> context, CancellationToken cancellationToken)
        {
            try
            {
                var req = context.Message;
                ELearning.Domain.CourseOffering courseOffering;
                if (req.CourseOfferingId.HasValue)
                {
                    var entity = await _dbContext.CourseOfferings.FindAsync(req.CourseOfferingId.Value);
                    Guard.Against.Null(entity, nameof(req.CourseOfferingId), "Not Found This Student");
                    courseOffering = entity;
                }
                else
                {
                    courseOffering = new Domain.CourseOffering();
                    _dbContext.CourseOfferings.Add(courseOffering);
                }
                courseOffering.Section = req.Section;
                courseOffering.Capacity = req.Capacity;
                courseOffering.CourseNumber = req.CourseNumber;
                courseOffering.TermId = req.TermId;
                await _dbContext.SaveChangesAsync();
                return new BaseEntity<int>(courseOffering.CourseOfferingId);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }




    }
}

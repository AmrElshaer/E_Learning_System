using ELearning.Domain;
using FluentValidation;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.CourseEnrollment.Commonds.CreatEditCoursEnrollment
{
    public class CreatEditCoursEnrollValidation : AbstractValidator<CreatEditCoursEnrollmentCommond>
    {
        private readonly StudentsEntities _context;

        public CreatEditCoursEnrollValidation()
        {
            _context = new StudentsEntities();
            RuleFor(a => a).MustAsync(CheckStudentEnrollBefore).WithMessage("This Student Enroll this course before");
        }

        private async Task<bool> CheckStudentEnrollBefore(CreatEditCoursEnrollmentCommond arg, CancellationToken arg2)
        {
            return await _context.CourseEnrollments.FirstOrDefaultAsync(e => e.CourseOfferingId == arg.CourseOfferingId && e.StudentId == arg.StudentId, arg2) == null;

        }
    }
}

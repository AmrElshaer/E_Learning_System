using FluentValidation;

namespace ELearning.Application.Student.Commonds.CreatEditStudent
{
    public class CreatEditStudentValidator : AbstractValidator<CreatEditStudentCommond>
    {
        public CreatEditStudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.LastName).NotEmpty();
        }
    }
}

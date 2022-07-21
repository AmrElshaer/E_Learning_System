using FluentValidation;

namespace ELearning.Application.Student.Commonds.CreatEditStudent
{
    public class CreatEditStudentValidator : AbstractValidator<CreatEditStudentCommond>
    {
        public CreatEditStudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().MinimumLength(5);
            RuleFor(s => s.LastName).NotEmpty().MinimumLength(5);
        }
    }
}

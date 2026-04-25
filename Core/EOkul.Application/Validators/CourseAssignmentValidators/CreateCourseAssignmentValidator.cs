using EOkul.Application.Dtos.CourseAssignmentDtos;
using FluentValidation;

namespace EOkul.Application.Validators.CourseAssignmentValidators
{
    public class CreateCourseAssignmentValidator : AbstractValidator<CreateCourseAssignmentDto>
    {
        public CreateCourseAssignmentValidator()
        {
            RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Ders seçimi zorunludur.")
            .GreaterThan(0).WithMessage("Geçerli bir ders seçiniz.");

            RuleFor(x => x.ClassroomId)
                .NotEmpty().WithMessage("Sınıf seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir sınıf seçiniz.");

            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("Öğretmen seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir öğretmen seçiniz.");
        }
    }
}

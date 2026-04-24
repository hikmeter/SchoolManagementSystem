using EOkul.Application.Dtos.CourseDtos;
using FluentValidation;

namespace EOkul.Application.Validators.CourseValidators
{
    public class UpdateCourseValidator : AbstractValidator<UpdateCourseDto>
    {
        public UpdateCourseValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("Kurs ID'si boş olamaz.");

            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Ders adı boş bırakılamaz.")
           .MinimumLength(2).WithMessage("Ders adı en az 2 karakter olmalıdır.")
           .MaximumLength(100).WithMessage("Ders adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.WeeklyHours)
                .NotEmpty().WithMessage("Haftalık ders saati boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Haftalık ders saati 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(10).WithMessage("Haftalık ders saati en fazla 10 olabilir.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Aktiflik durumu boş bırakılamaz.");
        }
    }
}

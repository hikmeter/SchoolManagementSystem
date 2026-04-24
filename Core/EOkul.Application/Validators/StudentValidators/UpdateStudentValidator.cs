using EOkul.Application.Dtos.StudentDtos;
using FluentValidation;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0)
            .WithMessage("Geçerli bir öğrenci ID girilmelidir.");

        RuleFor(x => x.StudentNumber)
            .NotEmpty().WithMessage("Öğrenci numarası boş olamaz.")
            .MaximumLength(20).WithMessage("Öğrenci numarası en fazla 20 karakter olabilir.");

        RuleFor(x => x.ClassroomId)
            .GreaterThan(0).WithMessage("Geçerli bir sınıf seçmelisiniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Öğrenci adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Öğrenci adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Öğrenci adı en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$")
            .WithMessage("Öğrenci adı yalnızca harf içermelidir.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Öğrenci soyadı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Öğrenci soyadı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Öğrenci soyadı en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$")
            .WithMessage("Öğrenci soyadı yalnızca harf içermelidir.");

        RuleFor(x => x.TCNumber)
            .NotEmpty().WithMessage("TC kimlik numarası boş bırakılamaz.")
            .Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.")
            .Matches(@"^[0-9]+$").WithMessage("TC kimlik numarası sadece rakamlardan oluşmalıdır.")
            .Must(BeValidTcKimlikNo).WithMessage("Geçersiz TC kimlik numarası.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.")
            .LessThan(DateTime.Today).WithMessage("Doğum tarihi bugünden büyük olamaz.")
            .GreaterThan(DateTime.Today.AddYears(-100))
            .WithMessage("Doğum tarihi geçerli bir aralıkta olmalıdır.");
    }

    private bool BeValidTcKimlikNo(string tc)
    {
        if (string.IsNullOrWhiteSpace(tc) || tc.Length != 11 || !tc.All(char.IsDigit))
            return false;

        if (tc[0] == '0')
            return false;

        int[] digits = tc.Select(c => int.Parse(c.ToString())).ToArray();

        int odd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        int even = digits[1] + digits[3] + digits[5] + digits[7];

        int tenth = ((odd * 7) - even) % 10;
        if (tenth != digits[9])
            return false;

        int sum = digits.Take(10).Sum();
        return sum % 10 == digits[10];
    }
}
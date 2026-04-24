using EOkul.Application.Dtos.TeacherDtos;
using FluentValidation;

namespace EOkul.Application.Validators.TeacherValidators
{
    public class UpdateTeacherValidator : AbstractValidator<UpdateTeacherDto>
    {
        public UpdateTeacherValidator()
        {
            RuleFor(x => x.TeacherId).GreaterThan(0).WithMessage("Öğretmen ID değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Öğretmen adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Öğretmen adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Öğretmen adı en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$")
            .WithMessage("Öğretmen adı yalnızca harf içermelidir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Öğretmen soyadı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Öğretmen soyadı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Öğretmen soyadı en fazla 50 karakter olabilir.")
                .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$")
                .WithMessage("Öğretmen soyadı yalnızca harf içermelidir.");

            RuleFor(x => x.TCNumber)
                .NotEmpty().WithMessage("TC kimlik numarası boş bırakılamaz.")
                .Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.")
                .Matches(@"^[0-9]+$").WithMessage("TC kimlik numarası yalnızca rakamlardan oluşmalıdır.")
                .Must(BeValidTcKimlikNo).WithMessage("Geçersiz TC kimlik numarası girdiniz.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.")
                .LessThan(DateTime.Today).WithMessage("Doğum tarihi bugünden ileri bir tarih olamaz.")
                .GreaterThan(DateTime.Today.AddYears(-100))
                .WithMessage("Doğum tarihi geçerli bir aralıkta olmalıdır.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                .Matches(@"^5[0-9]{9}$")
                .WithMessage("Telefon numarası 5xxxxxxxxx formatında olmalıdır.");
        }

        private bool BeValidTcKimlikNo(string tc)
        {
            if (string.IsNullOrWhiteSpace(tc) || tc.Length != 11 || !tc.All(char.IsDigit))
                return false;

            if (tc[0] == '0')
                return false;

            int[] digits = tc.Select(c => int.Parse(c.ToString())).ToArray();

            int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int evenSum = digits[1] + digits[3] + digits[5] + digits[7];

            int tenthDigit = ((oddSum * 7) - evenSum) % 10;
            if (tenthDigit != digits[9])
                return false;

            int firstTenSum = digits.Take(10).Sum();
            int eleventhDigit = firstTenSum % 10;

            return eleventhDigit == digits[10];
        }
    }
}


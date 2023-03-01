namespace Business.Utilities.Validators
{
    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(r => r.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(128)
                .EmailAddress()
                .MinimumLength(5);
            RuleFor(r => r.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(15)
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(r => r.Room)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);
            RuleFor(r => r.NumberOfAdults)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(6);
		}
    }
}

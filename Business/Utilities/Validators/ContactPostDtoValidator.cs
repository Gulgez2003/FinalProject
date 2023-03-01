namespace Business.Utilities.Validators
{
    public class ContactPostDtoValidator : AbstractValidator<ContactPostDto>
    {
        public ContactPostDtoValidator()
        {
            RuleFor(c => c.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(c => c.Message)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(128)
                .EmailAddress()
                .MinimumLength(5);
        }
    }
}

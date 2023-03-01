namespace Business.Utilities.Validators
{
    public class ServicePostDtoValidator : AbstractValidator<ServicePostDto>
    {
        public ServicePostDtoValidator()
        {
            RuleFor(s => s.Name)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(50);
            RuleFor(s => s.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(s => s.Icon)
                .NotNull()
                .NotEmpty();
        }
    }
}

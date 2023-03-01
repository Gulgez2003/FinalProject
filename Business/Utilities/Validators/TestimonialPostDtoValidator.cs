namespace Business.Utilities.Validators
{
    public class TestimonialPostDtoValidator : AbstractValidator<TestimonialPostDto>
    {
        public TestimonialPostDtoValidator()
        {
            RuleFor(t => t.Comment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256)
                .MinimumLength(2);
            RuleFor(t => t.CustomerName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}

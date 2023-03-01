namespace Business.Utilities.Validators
{
    public class BlogPostDtoValidator : AbstractValidator<BlogPostDto>
    {
        public BlogPostDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(b => b.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(b => b.DateTime)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}

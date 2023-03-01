namespace Business.Utilities.Validators
{
    public class RoomPostDtoValidator : AbstractValidator<RoomPostDto>
    {
        public RoomPostDtoValidator()
        {
            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(r => r.BedType)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(r => r.Services)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(128);
            RuleFor(r => r.Size)
                .NotEmpty()
                .NotNull()
                .GreaterThan(25)
                .LessThan(200);
            RuleFor(r => r.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(30)
                .LessThan(500);
            RuleFor(r => r.Capacity)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .LessThan(7);
        }
    }
}

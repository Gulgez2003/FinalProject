﻿using Core.Entities.DTOs.UserDtos;

namespace Core.Utilities.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(r => r.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(r => r.UserName)
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
            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20);
            RuleFor(r => r.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(50);
        }
    }
}

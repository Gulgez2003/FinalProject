using Core.Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<LoginDto>
    {
        public UserLoginDtoValidator()
        {
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
                .MaximumLength(50);
        }
    }
}

using CarSystem.Api.Configurations;
using CarSystem.Bll.DTOs.PersonDto;
using FluentValidation;

namespace CarSystem.Api.Validators;

public class CarDreateDtoValidator : AbstractValidator<PersonCreateDto>
{
    //private readonly IUserRepository UserRepository;

    public PersonCreateDtoValidator(IPersonRepository personRepository)
    {
        // UserRepository = userRepository;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName kiritilishi shart.")
            .MaximumLength(50).WithMessage("FirstName 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.LastName)
           .NotEmpty()
           .MaximumLength(50);

        RuleFor(x => x.Email)
             .NotEmpty().WithMessage("Email kiritilishi shart.")
             .MaximumLength(50).WithMessage("Email 50 belgidan oshmasligi kerak.")
             .EmailAddress().WithMessage("Email manzili noto‘g‘ri formatda.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol kiritilishi shart.")
            .MinimumLength(8).WithMessage("Parol kamida 8 belgidan iborat bo'lishi kerak.")
            .MaximumLength(50).WithMessage("Parol 100 ta belgidan oshmasligi kerak.")
            .Matches(@"[A-Z]").WithMessage("Parolda kamida 1ta katta harf bo'lishi kerak.")
            .Matches(@"[a-z]").WithMessage("Parolda kamida 1ta kichik harf bo'lishi kerak.")
            .Matches(@"[0-9]").WithMessage("Parolda kamida 1ta raqam bo'lishi kerak.")
            .Matches(@"[\!\?\*\.\@]").WithMessage("Parolda kamida bitta maxsus belgi (! ? * . @) bo‘lishi kerak.");



    }
}

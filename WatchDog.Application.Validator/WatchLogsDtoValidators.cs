using FluentValidation;
using WatchDog.Application.DTO;

namespace WatchDog.Application.Validator
{
    public class WatchLogsDtoValidators : AbstractValidator<WatchLogsDto>
    {
        public WatchLogsDtoValidators()
        {
            RuleFor(u => u.id).NotNull().NotEmpty();
        }
    }
}
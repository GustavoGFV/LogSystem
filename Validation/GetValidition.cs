using FluentValidation;
using Logger.Dto.Validation;

namespace Logger.Validation
{
    public class GetValidition : AbstractValidator<GetLog>
    {
        public GetValidition()
        {
            RuleSet("Code", () =>
            {
                RuleFor(log => log.Code).NotNull();
            });
            RuleSet("Date", () =>
            {
                RuleFor(log => log.Date).NotNull();
            });
            RuleSet("Id", () =>
            {
                RuleFor(log => log.Id).NotNull();
            });
        }
    }
}

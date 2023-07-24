using FluentValidation;
using Logger.Dto.Validation;
using Logger.Enum;
using Logger.Resources;

namespace Logger.Validation
{
    public class GetValidition : AbstractValidator<GetLog>
    {
        public GetValidition()
        {
            RuleSet("Code", () =>
            {
                RuleFor(log => log.Code).NotNull().WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(Error.CodeNull);
            });
            RuleSet("Date", () =>
            {
                RuleFor(log => log.InitialDate).NotNull().WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(Error.DateNull);

                RuleFor(log => log.FinalDate).NotNull().WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(Error.DateNull);

                RuleFor(log => log.InitialDate).LessThan(DateTime.MaxValue)
                .GreaterThan(DateTime.MinValue)
                .WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(log => string.Format(Error.DateInvalid, log.InitialDate));

                RuleFor(log => log.FinalDate).LessThan(DateTime.MaxValue)
                .GreaterThan(DateTime.MinValue)
                .WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(log => string.Format(Error.DateInvalid, log.FinalDate));

                RuleFor(log => log.InitialDate).GreaterThan(log => log.FinalDate)
                .WithErrorCode(ValidationErrorEnum.GetDate.ToString())
                .WithMessage(log => string.Format(Error.DatePeriodInvalid, log.InitialDate, log.FinalDate));
            });
            RuleSet("Id", () =>
            {
                RuleFor(log => log.Id).NotNull().WithErrorCode(ValidationErrorEnum.GetId.ToString())
                .WithMessage(Error.IDNull);
            });
        }
    }
}

using Castle.Core.Resource;
using FluentValidation;
using Logger.Dto;
using Logger.Enum;
using Logger.Resources;

namespace Logger.Validation
{
    public class CreateValidition : AbstractValidator<LogDto>
    {
        public CreateValidition()
        {
            RuleFor(log => log.Id).Null().WithErrorCode(ValidationErrorEnum.Id.ToString())
                 .WithMessage(Error.IDNotNull);

            RuleFor(log => log.Project).NotNull().WithErrorCode(ValidationErrorEnum.Project.ToString())
                 .WithMessage(Error.ProjectNull);

            RuleFor(log => log.ErrorCode).NotNull().WithErrorCode(ValidationErrorEnum.ErrorCode.ToString())
                 .WithMessage(Error.CodeNull);

            RuleFor(log => log.StackTrace).NotNull().WithErrorCode(ValidationErrorEnum.StackTrace.ToString())
                 .WithMessage(Error.StackTraceNull);

            RuleFor(log => log.ReportDate).NotNull()
                 .WithMessage(Error.DateNull);

            RuleFor(log => log.ReportDate).LessThan(DateTime.MaxValue)
                 .GreaterThan(DateTime.MinValue)
                 .WithErrorCode(ValidationErrorEnum.ReportDate.ToString())
                 .WithMessage(log => string.Format(Error.DateInvalid, log.ReportDate));
        }
    }
}

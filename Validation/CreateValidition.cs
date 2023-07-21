using Castle.Core.Resource;
using FluentValidation;
using Logger.Dto;

namespace Logger.Validation
{
    public class CreateValidition : AbstractValidator<LogDto>
    {
        public CreateValidition()
        {
            RuleFor(log => log.Id).Null().WithErrorCode("Id Preenchido!");
            RuleFor(log => log.Project).NotNull().WithErrorCode("Projeto Não Preenchido");
            RuleFor(log => log.ErrorCode).NotNull().WithErrorCode("Sem Código de Erro");
            RuleFor(log => log.StackTrace).NotNull().WithErrorCode("Sem StackTrace");
            RuleFor(log => log.ReportDate).NotNull().LessThan(DateTime.MaxValue)
                .GreaterThan(DateTime.MinValue)
                .WithErrorCode("Data Invalida");
        }
    }
}

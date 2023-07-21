using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Logger.Dto;
using Logger.Dto.Validation;
using Logger.Interface;
using Logger.Services;
using Logger.Validation;
using Logger.Enum;
using Logger.Resources;

namespace Logger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private CreateValidition _createValidiation;
        private GetValidition _getValidiation;
        private readonly ILoggerService _loggerService;

        private readonly string dateValidation = "Date";
        private readonly string idValidation = "Id";
        private readonly string codeValidation = "Code";

        public LoggerController(ILogger<LoggerController> logger, ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _createValidiation = new CreateValidition();
            _getValidiation = new GetValidition();
        }

        [HttpPost]
        public IActionResult Create(LogDto log)
        {
            try
            {
                var result = _createValidiation.Validate(log);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ArgumentException(error.ErrorMessage, error.ErrorCode);
                    }
                }
                _loggerService.Create(log);
                return Ok();
            }
            catch (ArgumentException e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = e.ParamName,
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.Create.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            try
            {
                var logs = _loggerService.Get();
                if (logs == null) return NotFound();
                return Ok(logs);
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.GetAll.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var result = _getValidiation.Validate(new GetLog() { Id = id },
                    options => options.IncludeRuleSets(idValidation));
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ArgumentException(error.ErrorMessage, error.ErrorCode);
                    }
                }

                var log = _loggerService.Get(id);
                if (log == null) return NotFound(string.Format(Error.IDNotFound, id));
                return Ok(log);
            }
            catch (ArgumentException e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = e.ParamName,
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.GetID.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }

        [HttpGet("Get/Date/{date}")]
        public IActionResult GetByDate([FromRoute] DateTime date)
        {
            try
            {
                var result = _getValidiation.Validate(new GetLog() { Date = date },
                    options => options.IncludeRuleSets(dateValidation));
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ArgumentException(error.ErrorMessage, error.ErrorCode);
                    }
                }

                var logs = _loggerService.Get(date);
                if (logs == null) return NotFound(string.Format(Error.DateNotFound, date));
                return Ok(logs);

            }
            catch (ArgumentException e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = e.ParamName,
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.GetDate.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }

        [HttpGet("Get/Error/{code}")]
        public IActionResult GetByCode([FromRoute] string code)
        {
            try
            {
                var result = _getValidiation.Validate(new GetLog() { Code = code },
                    options => options.IncludeRuleSets(codeValidation));
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ArgumentException(error.ErrorMessage, error.ErrorCode);
                    }
                }

                var logs = _loggerService.Get(code);
                if (logs == null) return NotFound(string.Format(Error.CodeNotFound, code));
                return Ok(logs);
            }
            catch (ArgumentException e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = e.ParamName,
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.GetCode.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }

        [HttpGet("Get/{date}&{code}")]
        public IActionResult GetByFilter([FromRoute] DateTime date, [FromRoute] string code)
        {
            try
            {
                var result = _getValidiation.Validate(new GetLog() { Code = code, Date = date },
                    options => options.IncludeRuleSets(codeValidation, dateValidation));
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ArgumentException(error.ErrorMessage, error.ErrorCode);
                    }
                }

                var logs = _loggerService.Get(date, code);
                if (logs == null) return NotFound(string.Format(Error.CodeDateNotFound, code, date));
                return Ok(logs);
            }
            catch (ArgumentException e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = e.ParamName,
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
            catch (Exception e)
            {
                _loggerService.Create(new LogDto()
                {
                    ErrorCode = InternalErrorEnum.GetCodeDate.ToString(),
                    Message = e.Message,
                    Project = "Logger",
                    ReportDate = DateTime.Now,
                    StackTrace = e.StackTrace
                });
                throw;
            }
        }
    }
}
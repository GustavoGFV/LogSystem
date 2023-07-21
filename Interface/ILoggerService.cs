using Logger.Dto;

namespace Logger.Interface
{
    public interface ILoggerService
    {
        void Create(LogDto log);
        Task<List<LogDto>> Get();
        Task<LogDto> Get(int id);
        Task<List<LogDto>> Get(DateTime date);
        Task<List<LogDto>> Get(string code);
        Task<List<LogDto>> Get(DateTime date, string code);
    }
}

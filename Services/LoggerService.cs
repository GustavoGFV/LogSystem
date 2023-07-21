using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Logger.Dbo;
using Logger.Dto;
using Logger.Interface;

namespace Logger.Services
{
    public class LoggerService : ILoggerService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public LoggerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async void Create(LogDto log)
        {
            await _context.Log!.AddAsync(_mapper.Map<LogModel>(log));
            await _context.SaveChangesAsync();
        }
        public async Task<List<LogDto>> Get() => _mapper.Map<List<LogDto>>(await _context.Log!.ToListAsync());

        public async Task<LogDto> Get(int id) => _mapper.Map<LogDto>(await _context.Log!.Where(i => i.Id == id).FirstOrDefaultAsync());

        public async Task<List<LogDto>> Get(DateTime date) => _mapper.Map<List<LogDto>>(await _context.Log!.Where(i => i.ReportDate == date).ToListAsync());

        public async Task<List<LogDto>> Get(string code) => _mapper.Map<List<LogDto>>(await _context.Log!.Where(i => i.ErrorCode == code).ToListAsync());
        public async Task<List<LogDto>> Get(DateTime date, string code)
        {
            var query = from log in _context.Log!
                        where log.ReportDate == date && log.ErrorCode == code
                        select log;

            return _mapper.Map<List<LogDto>>(await query.ToListAsync());
        }
    }
}

using AutoMapper;
using Logger.Dto;

namespace Logger.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDto, LogModel>();
        }
    }
}

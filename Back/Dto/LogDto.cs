namespace Logger.Dto
{
    public class LogDto
    {
        public LogDto()
        {
            CreatedAt = DateTime.Now;
        }
        public int? Id { get; set; }
        public string? Project { get; set; }
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? ReportTime => ReportDate?.ToUniversalTime();
        public DateTime CreatedAt { get; set; }
    }
}
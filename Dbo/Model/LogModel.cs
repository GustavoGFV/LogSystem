using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logger.Dto
{
    [Table("Logger")]
    public class LogModel
    {
        public LogModel()
        {
            CreatedAt = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string? Project { get; set; }
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime ReportTime => ReportDate.ToUniversalTime();
        public DateTime CreatedAt { get; set; }
    }
}
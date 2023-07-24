namespace Logger.Dto.Validation
{
    public class GetLog
    {
        public int? Id { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string? Code { get; set; }
    }
}

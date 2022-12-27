namespace WatchDog.Models.Dto
{
    public class ExceptionLogsDto
    {
        public int id { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public string typeOf { get; set; }
        public string source { get; set; }
        public string path { get; set; }
        public string method { get; set; }
        public string queryString { get; set; }
        public string requestBody { get; set; }
        public string encounteredAt { get; set; }
    }
}

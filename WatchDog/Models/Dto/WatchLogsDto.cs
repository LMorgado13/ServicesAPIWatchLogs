namespace WatchDog.Models.Dto
{
    public class WatchLogsDto
    {
        public int id { get; set; }
        public string responseBody { get; set; }
        public int responseStatus { get; set; }
        public string requestBody { get; set; }
        public string queryString { get; set; }
        public string path { get; set; }
        public string requestHeaders { get; set; }
        public string responseHeaders { get; set; }
        public string method { get; set; }
        public string host { get; set; }
        public string ipAddress { get; set; }
        public string timeSpent { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}

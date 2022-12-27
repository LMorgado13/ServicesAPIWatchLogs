namespace WatchDog.Models.Dto
{
    public class LogDto
    {
        public int id { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
        public string callingFrom { get; set; }
        public string callingMethod { get; set; }
        public int lineNumber { get; set; }
    }
}

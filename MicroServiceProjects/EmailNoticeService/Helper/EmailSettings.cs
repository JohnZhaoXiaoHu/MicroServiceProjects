
namespace EmailNoticeService.Helper
{
    public class EmailSettings
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }

    public class Content
    {
        public string Body { get; set; }
    }
}

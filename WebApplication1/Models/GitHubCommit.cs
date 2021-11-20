namespace WebHookReceiver.Models
{
    public class GitHubCommit
    {
        public int Id { get; set; }
        public string Developer { get; set; }
        public string Message { get; set; }
    }
}

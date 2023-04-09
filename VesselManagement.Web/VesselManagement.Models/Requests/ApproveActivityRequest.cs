namespace Cgi.Appmar.Models.Requests
{
    public class ApproveActivityRequest
    {
        public int ApprovalId { get; set; }
        public string Reason { get; set; } = string.Empty;

    }
}

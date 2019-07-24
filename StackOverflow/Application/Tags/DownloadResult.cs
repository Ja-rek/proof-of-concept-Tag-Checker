namespace Mediporta.StackOverflow.Application.Tags
{
    public class DownloadResult
    {
        public DownloadResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}

using System.Linq;

namespace Mediporta.StackOverflow.Application.Tags
{
    public class TagApplicationService
    {
        private readonly ITagStorageService storageService;
        private readonly ITagService service;

        public TagApplicationService(ITagStorageService storageService, ITagService service)
        {
            this.storageService = storageService;
            this.service = service;
        }

        public DownloadResult DownloadMostPopulateTags()
        {
            var tags = service.GetMostPopulateTags(1000);

            if (tags.Any())
            {
                this.storageService.Save(tags);

                return new DownloadResult(success: true);
            }

            return new DownloadResult(success: false);
        }
    }
}

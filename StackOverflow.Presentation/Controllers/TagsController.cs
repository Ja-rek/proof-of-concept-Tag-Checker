using System.Diagnostics;
using Mediporta.StackOverflow.Application.Tags;
using Microsoft.AspNetCore.Mvc;
using Mediporta.StackOverflow.Presentation.Models;
using System.Threading.Tasks;

namespace Mediporta.StackOverflow.Presentation.Controllers
{
    public class TagsController : Controller
    {
        private readonly TagApplicationService tagAppService;
        private readonly TagQueryService tagQueryService;

        public TagsController(TagApplicationService tagAppService, TagQueryService tagQueryService)
        {
            this.tagAppService = tagAppService;
            this.tagQueryService = tagQueryService;
        }

        public async Task<IActionResult> DownloadMostPopulateTags()
        {
            var result = await this.tagAppService.DownloadMostPopulateTagsAsync();

            return result.Success ? StatusCode(200) : StatusCode(429);
        }

        public ActionResult Index()
        {
            var tags = this.tagQueryService.GetMostPopulateTags();

            return View(tags);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

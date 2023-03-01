namespace FinalProject.app.Controllers
{
    public class NewsController : Controller
    {
        private readonly IBlogService _blogService;
        public NewsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        // GET: NewsController
        public async Task<IActionResult> Index()
        {
            List<BlogGetDto> blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

    }
}

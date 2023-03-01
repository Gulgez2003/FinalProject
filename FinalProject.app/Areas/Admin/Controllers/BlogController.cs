namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: BlogController
        public async Task<IActionResult> Index()
        {
            List<BlogGetDto> blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        // GET: BlogController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostDto postDto)
        {
            BlogPostDtoValidator validations= new BlogPostDtoValidator();
            ValidationResult validationResult= await validations.ValidateAsync(postDto);
            if (validationResult.IsValid)
            {
                await _blogService.CreateAsync(postDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            return View();
        }

        // GET: BlogController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            BlogUpdateDto blogUpdateDto = new BlogUpdateDto
            {
                blogGetDto = await _blogService.GetByIdAsync(id)
            };
            return View(blogUpdateDto);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BlogUpdateDto updateDto)
        {
            BlogPostDtoValidator validations = new BlogPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(updateDto.blogPostDto);
            if (validationResult.IsValid)
            {
                await _blogService.UpdateAsync(updateDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            return View();
        }

        // GET: Admin/TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Admin/TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog != null)
            {
                await _blogService.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

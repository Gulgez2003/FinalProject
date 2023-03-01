using FluentValidation;

namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // GET: TestimonialController
        public async Task<IActionResult> Index()
        {
            List<TestimonialGetDto> services = await _testimonialService.GetAllAsync();
            return View(services);
        }

        // GET: TestimonialController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestimonialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonialPostDto postDto)
        {
            TestimonialPostDtoValidator validations = new TestimonialPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(postDto);
            if (validationResult.IsValid)
            {
                await _testimonialService.CreateAsync(postDto);
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

        // GET: TestimonialController/Edit
        public async Task<IActionResult> Update(int id)
        {
            TestimonialUpdateDto testimonialUpdateDto = new TestimonialUpdateDto
            {
                testimonialGetDto = await _testimonialService.GetByIdAsync(id)
            };
            return View(testimonialUpdateDto);
        }

        // POST: TestimonialController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TestimonialUpdateDto updateDto)
        {
            await _testimonialService.UpdateAsync(updateDto);
            return RedirectToAction("Index");
        }

        // GET: Admin/Testimonial/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Admin/Service/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            if (testimonial != null)
            {
                await _testimonialService.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

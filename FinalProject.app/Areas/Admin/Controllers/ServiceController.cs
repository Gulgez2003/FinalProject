using FluentValidation;

namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: ServiceController
        public async Task<IActionResult> Index()
        {
            List<ServiceGetDto> services = await _serviceService.GetAllAsync();
            return View(services);
        }

        // GET: ServiceController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicePostDto postDto)
        {
            ServicePostDtoValidator validations = new ServicePostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(postDto);
            if (validationResult.IsValid)
            {
                await _serviceService.CreateAsync(postDto);
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

        // GET: ServiceController/Edit
        public async Task<IActionResult> Update(int id)
        {
            ServiceUpdateDto serviceUpdateDto = new ServiceUpdateDto
            {
                serviceGetDto = await _serviceService.GetByIdAsync(id)
            };
            return View(serviceUpdateDto);
        }

        // POST: ServiceController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceUpdateDto updateDto)
        {
            await _serviceService.UpdateAsync(updateDto);
            return RedirectToAction("Index");
        }

        // GET: Admin/Service/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Admin/Service/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service != null)
            {
                await _serviceService.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

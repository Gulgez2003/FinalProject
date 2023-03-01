namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // GET: SettingController
        public async Task<IActionResult> Index()
        {
            List<SettingGetDto> settings = await _settingService.GetAllAsync();
            return View(settings);
        }

        // GET: SettingController/Edit
        public async Task<IActionResult> Update(int id)
        {
            SettingUpdateDto settingUpdateDto = new SettingUpdateDto
            {
                settingGetDto = await _settingService.GetByIdAsync(id)
            };
            return View(settingUpdateDto);
        }

        // POST: SettingController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SettingUpdateDto updateDto)
        {
            SettingPostDtoValidator validations = new SettingPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(updateDto.settingPostDto);
            if (validationResult.IsValid)
            {
                await _settingService.UpdateAsync(updateDto);
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
    }
}

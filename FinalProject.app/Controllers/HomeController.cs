namespace FinalProject.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IServiceService _serviceService;
        public HomeController(IServiceService serviceService, ITestimonialService testimonialService)
        {
            _serviceService = serviceService;
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            List<TestimonialGetDto> testimonials = await _testimonialService.GetAllAsync();
            List<ServiceGetDto> services = await _serviceService.GetAllAsync();
            ServiceTestimonialVM serviceTestimonialVM = new ServiceTestimonialVM
            {
                TestimonialGetDtos = testimonials,
                ServiceGetDtos = services
            };

            return View(serviceTestimonialVM);
        }
    }
}
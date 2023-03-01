namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: ReservationController
        public async Task<IActionResult> Index()
        {
            List<ReservationGetDto> reservations = await _reservationService.GetAllAsync();
            return View(reservations);
        }
    }
}

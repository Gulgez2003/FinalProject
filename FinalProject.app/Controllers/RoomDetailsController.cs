namespace FinalProject.app.Controllers
{
    public class RoomDetailsController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomDetailsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: RoomDetailsController
        public async Task<IActionResult> Index()
        {
            List<RoomGetDto> rooms = await _roomService.GetAllAsync();
            return View(rooms);
        }
    }
}

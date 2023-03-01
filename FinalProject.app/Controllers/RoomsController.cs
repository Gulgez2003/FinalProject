namespace FinalProject.app.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: RoomsController
        public async Task<IActionResult> Index()
        {
            List<RoomGetDto> rooms = await _roomService.GetAllAsync();
            return View(rooms);
        }

        public async Task<IActionResult> Search(string type, int capacity, double minPrice, double maxPrice)
        {
            List<RoomGetDto> results = await _roomService.GetSearchResults(type, capacity, minPrice, maxPrice);
            return View(results);
        }
    }
}

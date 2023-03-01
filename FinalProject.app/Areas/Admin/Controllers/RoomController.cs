namespace FinalProject.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: RoomController
        public async Task<IActionResult> Index()
        {
            List<RoomGetDto> rooms = await _roomService.GetAllAsync();
            return View(rooms);
        }

        // GET: RoomController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomPostDto postDto)
        {
            RoomPostDtoValidator validations = new RoomPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(postDto);
            if (validationResult.IsValid)
            {
                await _roomService.CreateAsync(postDto);
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

        // GET: RoomController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            RoomUpdateDto roomUpdateDto = new RoomUpdateDto
            {
                roomGetDto = await _roomService.GetByIdAsync(id)
            };
            return View(roomUpdateDto);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoomUpdateDto updateDto)
        {
            RoomPostDtoValidator validations = new RoomPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(updateDto.roomPostDto);
            if (validationResult.IsValid)
            {
                await _roomService.UpdateAsync(updateDto);
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

        // GET: Admin/Room/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Admin/Room/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room != null)
            {
                await _roomService.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

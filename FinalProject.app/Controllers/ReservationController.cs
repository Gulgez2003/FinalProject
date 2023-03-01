namespace FinalProject.app.Controllers
{
    [Authorize(Roles = "User,Admin,SuperAdmin")]
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

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Room", Value = "Room" });
            rooms.Add(new SelectListItem() { Text = "Premium King Room", Value = "Premium King Room" });
            rooms.Add(new SelectListItem() { Text = "Deluxe Room", Value = "Deluxe Room" });
            rooms.Add(new SelectListItem() { Text = "Double Room", Value = "Double Room" });
            rooms.Add(new SelectListItem() { Text = "Luxury Room", Value = "Luxury Room" });
            rooms.Add(new SelectListItem() { Text = "Room With View", Value = "Room With View" });
            rooms.Add(new SelectListItem() { Text = "Small View", Value = "Small View" });
            ViewBag.Rooms = rooms;

            List<SelectListItem> adults = new List<SelectListItem>();
            adults.Add(new SelectListItem() { Text = "Adult(12+ Yrs)", Value = "0" });
            adults.Add(new SelectListItem() { Text = "1 Person", Value = "1" });
            adults.Add(new SelectListItem() { Text = "2 People", Value = "2" });
            adults.Add(new SelectListItem() { Text = "3 People", Value = "3" });
            adults.Add(new SelectListItem() { Text = "4 People", Value = "4" });
            adults.Add(new SelectListItem() { Text = "5 People", Value = "5" });
            adults.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.Adults = adults;

			List<SelectListItem> children = new List<SelectListItem>();
			children.Add(new SelectListItem() { Text = "Children(2-11 Yrs)", Value = "0" });
			children.Add(new SelectListItem() { Text = "1 Child", Value = "1" });
			children.Add(new SelectListItem() { Text = "2 Children", Value = "2" });
			children.Add(new SelectListItem() { Text = "3 Children", Value = "3" });
			children.Add(new SelectListItem() { Text = "4 Children", Value = "4" });
			children.Add(new SelectListItem() { Text = "5 Children", Value = "5" });
			children.Add(new SelectListItem() { Text = "More", Value = "6" });
			ViewBag.Children = children;

			List<SelectListItem> infants = new List<SelectListItem>();
			infants.Add(new SelectListItem() { Text = "Infant(under 2Yrs)", Value = "0" });
			infants.Add(new SelectListItem() { Text = "1 Infant", Value = "1" });
			infants.Add(new SelectListItem() { Text = "2 Infants", Value = "2" });
			infants.Add(new SelectListItem() { Text = "3 Infants", Value = "3" });
			infants.Add(new SelectListItem() { Text = "4 Infants", Value = "4" });
			infants.Add(new SelectListItem() { Text = "5 Infants", Value = "5" });
			infants.Add(new SelectListItem() { Text = "More", Value = "6" });
			ViewBag.Infants = infants;

			return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateDto createDto)
        {
            ReservationCreateDtoValidator validations = new ReservationCreateDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(createDto);
            if (validationResult.IsValid)
            {
                await _reservationService.CreateAsync(createDto);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(createDto.Email);
                    mail.To.Add(new MailAddress("siriushotel311@gmail.com"));
                    mail.Subject = "Reservation Form";
                    mail.IsBodyHtml = true;
                string body = $"<p>Name:  {createDto.FullName} </p>" +
                    $"<p>Phone Number:  {createDto.PhoneNumber} </p>" +
                    $"<p>Email:  {createDto.Email} </p>" +
                    $"<p>Arrival Date & Time:  {createDto.ArrivalDateTime} </p>" +
                    $"<p>Departure Date & Time:  {createDto.DepartureDateTime} </p>" +
                    $"<p>Room:  {createDto.Room} </p>" +
                    $"<p>Number Of Adults:  {createDto.NumberOfAdults} </p>" +
                    $"<p>Number Of Children:  {createDto.NumberOfChildren} </p>" +
                    $"<p>Number Of Infants:  {createDto.NumberOfInfants} </p>" +
                    $"<p>Message:  {createDto.Message} </p>";

                    mail.Body = body;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("siriushotel311@gmail.com", "iagwerwgjjwototz");

                    smtp.Send(mail);

                MailMessage mail1 = new MailMessage();
                mail1.From = new MailAddress("siriushotel311@gmail.com", "SiriusHotel");
                mail1.To.Add(new MailAddress(createDto.Email));
                mail1.Subject = $"You’re booked! Pack your bags – see you on {createDto.ArrivalDateTime}";
                mail1.IsBodyHtml = true;
                string body1 = $"<p>Hi, {createDto.FullName} </p>" +
                    $"<p>It’s confirmed, we’ll see you on {createDto.ArrivalDateTime}! Thank you for booking roon in Sirius Hotel with us on NYC. You’ll find details of your reservation and payment details enclosed below.</p>" +
                    $"<p><b>Reservation Details:<b></p>" +
                    $"<p>Name:  {createDto.FullName} </p>" +
                    $"<p>Phone Number:  {createDto.PhoneNumber} </p>" +
                    $"<p>Email:  {createDto.Email} </p>" +
                    $"<p>Arrival Date & Time:  {createDto.ArrivalDateTime} </p>" +
                    $"<p>Departure Date & Time:  {createDto.DepartureDateTime} </p>" +
                    $"<p>Room:  {createDto.Room} </p>" +
                    $"<p>Number Of Adults:  {createDto.NumberOfAdults} </p>" +
                    $"<p>Number Of Children:  {createDto.NumberOfChildren} </p>" +
                    $"<p>Number Of Infants:  {createDto.NumberOfInfants} </p>" +
                    $"<p>Message:  {createDto.Message} </p>" +
                    $"<p>If you need to get in touch, you can email or phone us directly. We look forward to welcoming you soon!</p>" +
                    $"<p>Thanks again,</p>" +
                    $"<p>The team at Sirius Hotel</p>" +
                    $"<p><b>More info:<b> siriushotel311@gmail.com, (12) 345 67890</p>";



                mail1.Body = body1;

                SmtpClient smtp1 = new SmtpClient();
                smtp1.Host = "smtp.gmail.com";
                smtp1.Port = 587;
                smtp1.EnableSsl = true;
                smtp1.Credentials = new NetworkCredential("siriushotel311@gmail.com", "iagwerwgjjwototz");

                smtp1.Send(mail1);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }

            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Room", Value = "Room" });
            rooms.Add(new SelectListItem() { Text = "Premium King Room", Value = "Premium King Room" });
            rooms.Add(new SelectListItem() { Text = "Deluxe Room", Value = "Deluxe Room" });
            rooms.Add(new SelectListItem() { Text = "Double Room", Value = "Double Room" });
            rooms.Add(new SelectListItem() { Text = "Luxury Room", Value = "Luxury Room" });
            rooms.Add(new SelectListItem() { Text = "Room With View", Value = "Room With View" });
            rooms.Add(new SelectListItem() { Text = "Small View", Value = "Small View" });
            ViewBag.Rooms = rooms;

            List<SelectListItem> adults = new List<SelectListItem>();
            adults.Add(new SelectListItem() { Text = "Adult(12+ Yrs)", Value = "0" });
            adults.Add(new SelectListItem() { Text = "1 Person", Value = "1" });
            adults.Add(new SelectListItem() { Text = "2 People", Value = "2" });
            adults.Add(new SelectListItem() { Text = "3 People", Value = "3" });
            adults.Add(new SelectListItem() { Text = "4 People", Value = "4" });
            adults.Add(new SelectListItem() { Text = "5 People", Value = "5" });
            adults.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.Adults = adults;

            List<SelectListItem> children = new List<SelectListItem>();
            children.Add(new SelectListItem() { Text = "Children(2-11 Yrs)", Value = "0" });
            children.Add(new SelectListItem() { Text = "1 Child", Value = "1" });
            children.Add(new SelectListItem() { Text = "2 Children", Value = "2" });
            children.Add(new SelectListItem() { Text = "3 Children", Value = "3" });
            children.Add(new SelectListItem() { Text = "4 Children", Value = "4" });
            children.Add(new SelectListItem() { Text = "5 Children", Value = "5" });
            children.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.Children = children;

            List<SelectListItem> infants = new List<SelectListItem>();
            infants.Add(new SelectListItem() { Text = "Infant(under 2Yrs)", Value = "0" });
            infants.Add(new SelectListItem() { Text = "1 Infant", Value = "1" });
            infants.Add(new SelectListItem() { Text = "2 Infants", Value = "2" });
            infants.Add(new SelectListItem() { Text = "3 Infants", Value = "3" });
            infants.Add(new SelectListItem() { Text = "4 Infants", Value = "4" });
            infants.Add(new SelectListItem() { Text = "5 Infants", Value = "5" });
            infants.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.Infants = infants;

            return View();
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

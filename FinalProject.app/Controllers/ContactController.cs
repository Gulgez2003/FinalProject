namespace FinalProject.app.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ISettingService _settingService;
        public ContactController(IContactService contactService, ISettingService settingsService)
        {
            _contactService = contactService;
            _settingService = settingsService;
        }

        // GET: ContactController
        public async Task<IActionResult> Index(ContactPostDto postDto)
        {
            SettingGetDto settingGetDto = _settingService.GetSetting();
            SettingContactViewModel settingCommentViewModel = new SettingContactViewModel
            {
                SettingGetDto = settingGetDto,
                ContactPostDto = new ContactPostDto()
            };

            return View(settingCommentViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SettingContactViewModel settingCommentViewModel)
        {
            ContactPostDtoValidator validations = new ContactPostDtoValidator();
            ValidationResult validationResult = await validations.ValidateAsync(settingCommentViewModel.ContactPostDto);
            if (validationResult.IsValid)
            {
                await _contactService.CreateAsync(settingCommentViewModel.ContactPostDto);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(settingCommentViewModel.ContactPostDto.Email);
                mail.To.Add(new MailAddress("siriushotel311@gmail.com"));
                mail.Subject = "Contact Form";
                mail.IsBodyHtml = true;
                string body = $"<p>FullName:  {settingCommentViewModel.ContactPostDto.FullName} </p>" +
                    $"<p>Email:  {settingCommentViewModel.ContactPostDto.Email} </p>" +
                    $"<p>Message:  {settingCommentViewModel.ContactPostDto.Message} </p>";

                mail.Body = body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("siriushotel311@gmail.com", "iagwerwgjjwototz");

                smtp.Send(mail);
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

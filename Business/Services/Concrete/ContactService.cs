namespace Business.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateAsync(ContactPostDto postDto)
        {
            Contact contact = new Contact
            {
                FullName = postDto.FullName,
                Email = postDto.Email,
                Message = postDto.Message
            };

            await _contactRepository.CreateAsync(contact);
            await _contactRepository.SaveAsync();
        }
    }
}

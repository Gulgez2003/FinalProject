using Entities.Concrete;

namespace Business.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ServicePostDto postDto)
        {
            Service service = new Service()
            {
                Name = postDto.Name,
                Description = postDto.Description,
                Icon=postDto.Icon
            };
            await _serviceRepository.CreateAsync(service);
            await _serviceRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Service service = await _serviceRepository.GetAsync(s => s.Id == id && !s.IsDeleted);
            if (service == null)
            {
                throw new NotFoundException(Messages.ServiceNotFound);
            }
            _serviceRepository.Delete(service);
            await _serviceRepository.SaveAsync();
        }

        public async Task<List<ServiceGetDto>> GetAllAsync()
        {
            List<Service> services = await _serviceRepository.GetAllAsync(s => !s.IsDeleted);
            //if (services.Count == 0)
            //{
            //    throw new NotFoundException(Messages.ServiceNotFound);
            //}
            return _mapper.Map<List<ServiceGetDto>>(services);
        }

        public async Task<ServiceGetDto> GetByIdAsync(int id)
        {
            Service service = await _serviceRepository.GetAsync(s => s.Id == id && !s.IsDeleted);
            if (service == null)
            {
                throw new NotFoundException(Messages.ServiceNotFound);
            }
            return _mapper.Map<ServiceGetDto>(service);
        }

        public async Task UpdateAsync(ServiceUpdateDto updateDto)
        {
            Service service = await _serviceRepository.GetAsync(s => s.Id == updateDto.serviceGetDto.Id && !s.IsDeleted);
            if (service == null)
            {
                throw new NotFoundException(Messages.ServiceNotFound);
            }
            service.Name = updateDto.servicePostDto.Name;
            service .Description = updateDto.servicePostDto.Description;
            service.Icon = updateDto.servicePostDto.Icon;
            _serviceRepository.Update(service);
            await _serviceRepository.SaveAsync();
        }
    }
}

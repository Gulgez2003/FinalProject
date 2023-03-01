namespace Business.Services.Concrete
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task<List<SettingGetDto>> GetAllAsync()
        {
            List<Setting> settings = await _settingRepository.GetAllAsync();
            if (settings.Count == 0)
            {
                throw new NotFoundException(Messages.SettingNotFound);

            }
            return _mapper.Map<List<SettingGetDto>>(settings);
        }

        public async Task<SettingGetDto> GetByIdAsync(int id)
        {
            Setting setting = await _settingRepository.GetAsync(s => s.Id == id);
            if (setting == null)
            {
                throw new NotFoundException(Messages.SettingNotFound);
            }
            return _mapper.Map<SettingGetDto>(setting);
        }

        public SettingGetDto GetSetting()
        {
            Setting setting = _settingRepository.FirstOrDefault(s => s.Id == 1);
            SettingGetDto settingGetDto = new SettingGetDto()
            {
                Information = setting.Information,
                PhoneNumber = setting.PhoneNumber,
                Email = setting.Email,
                Address = setting.Address,
                FaceBookIcon = setting.FaceBookIcon,
                TwitterIcon = setting.TwitterIcon,
                InstagramIcon = setting.InstagramIcon,
                YoutubeIcon = setting.YoutubeIcon
            };
            return settingGetDto;
        }

        public async Task UpdateAsync(SettingUpdateDto updateDto)
        {
            Setting setting = await _settingRepository.GetAsync(s => s.Id == updateDto.settingGetDto.Id);
            if (setting == null)
            {
                throw new NotFoundException(Messages.SettingNotFound);
            }

            setting.Information = updateDto.settingPostDto.Information;
            setting.PhoneNumber = updateDto.settingPostDto.PhoneNumber;
            setting.Email = updateDto.settingPostDto.Email;
            setting.Address = updateDto.settingPostDto.Address;
            setting.FaceBookIcon = updateDto.settingPostDto.FaceBookIcon;
            setting.TwitterIcon = updateDto.settingPostDto.TwitterIcon;
            setting.InstagramIcon = updateDto.settingPostDto.InstagramIcon;
            setting.YoutubeIcon = updateDto.settingPostDto.YoutubeIcon;

            _settingRepository.Update(setting);
            await _settingRepository.SaveAsync();
        }
    }
}

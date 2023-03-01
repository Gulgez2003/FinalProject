namespace Business.Services.Abstract
{
    public interface ISettingService
    {
        Task<List<SettingGetDto>> GetAllAsync();
        Task<SettingGetDto> GetByIdAsync(int id);
        Task UpdateAsync(SettingUpdateDto updateDto);
        public SettingGetDto GetSetting();
    }
}

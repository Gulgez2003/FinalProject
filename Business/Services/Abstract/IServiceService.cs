namespace Business.Services.Abstract
{
    public interface IServiceService
    {
        Task<List<ServiceGetDto>> GetAllAsync();
        Task<ServiceGetDto> GetByIdAsync(int id);
        Task CreateAsync(ServicePostDto postDto);
        Task UpdateAsync(ServiceUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}

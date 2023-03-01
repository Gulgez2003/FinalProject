namespace Business.Services.Abstract
{
    public interface IReservationService
    {
        Task<List<ReservationGetDto>> GetAllAsync();
        Task<ReservationGetDto> GetByIdAsync(int id);
        Task CreateAsync(ReservationCreateDto createDto);
        Task DeleteAsync(int id);
    }
}

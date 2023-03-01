namespace Business.Services.Abstract
{
    public interface IRoomService
    {
        Task<List<RoomGetDto>> GetAllAsync();
        Task<List<RoomGetDto>> GetSearchResults(string type, int capacity, double minPrice, double maxPrice);
        Task<RoomGetDto> GetByIdAsync(int id);
        Task CreateAsync(RoomPostDto postDto);
        Task UpdateAsync(RoomUpdateDto updateDto);
        Task DeleteAsync(int id);
        public RoomGetDto GetRoom(int id);
    }
}

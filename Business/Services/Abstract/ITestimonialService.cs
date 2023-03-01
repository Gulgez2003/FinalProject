namespace Business.Services.Abstract
{
    public interface ITestimonialService
    {
        Task<List<TestimonialGetDto>> GetAllAsync();
        Task<TestimonialGetDto> GetByIdAsync(int id);
        Task CreateAsync(TestimonialPostDto postDto);
        Task UpdateAsync(TestimonialUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}

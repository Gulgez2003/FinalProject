using Core.Entities;

namespace Business.Services.Abstract
{
    public interface IBlogService
    {
        Task<List<BlogGetDto>> GetAllAsync();
        Task<BlogGetDto> GetByIdAsync(int id);
        Task CreateAsync(BlogPostDto postDto);   
        Task UpdateAsync(BlogUpdateDto updateDto);
        Task DeleteAsync(int id);
        List<BlogGetDto> Take(int count);
        int Count();
        List<BlogGetDto> Skip(int count);
    }
}

namespace Entities.DTOs.BlogDTOs
{
    public class BlogPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public IFormFile File { get; set; }
    }
}

namespace Business.Services.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BlogService(IBlogRepository blogRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _env = env;
        }

        public int Count()
        {
            return _blogRepository.Count();
        }

        public async Task CreateAsync(BlogPostDto postDto)
        {
            Blog blog = new Blog()
            {
                Name=postDto.Name,
                Description=postDto.Description,
                DateTime=postDto.DateTime,
                ImageName = FileExtention.CreateFile(postDto.File, _env.WebRootPath, "assets/img")
            };
            await _blogRepository.CreateAsync(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Blog blog = await _blogRepository.GetAsync(b => b.Id == id && !b.IsDeleted);
            if (blog == null)
            {
                throw new NotFoundException(Messages.BlogNotFound);
            }
            _blogRepository.Delete(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task<List<BlogGetDto>> GetAllAsync()
        {
            List<Blog> blogs = await _blogRepository.GetAllAsync(b => !b.IsDeleted);
            if (blogs.Count == 0)
            {
                throw new NotFoundException(Messages.BlogNotFound);
            }
            return _mapper.Map<List<BlogGetDto>>(blogs);
        }

        public async Task<BlogGetDto> GetByIdAsync(int id)
        {

            Blog blog = await _blogRepository.GetAsync(b => b.Id == id && !b.IsDeleted);
            if (blog == null)
            {
                throw new NotFoundException(Messages.BlogNotFound);
            }
            return _mapper.Map<BlogGetDto>(blog);
        }

        public List<BlogGetDto> Skip(int count)
        {
            List<Blog> blogs = _blogRepository.Skip(count).ToList();
            return _mapper.Map<List<BlogGetDto>>(blogs);
        }

        public List<BlogGetDto> Take(int count)
        {
            List<Blog> blogs = _blogRepository.Take(count).ToList();
            return _mapper.Map<List<BlogGetDto>>(blogs);
        }

        public async Task UpdateAsync(BlogUpdateDto updateDto)
        {
            Blog blog = await _blogRepository.GetAsync(b => b.Id == updateDto.blogGetDto.Id && !b.IsDeleted);
            if (blog == null)
            {
                throw new NotFoundException(Messages.BlogNotFound);
            }
            blog.Name = updateDto.blogPostDto.Name;
            blog.Description = updateDto.blogPostDto.Description;
            blog.DateTime = updateDto.blogPostDto.DateTime;
            if (updateDto.blogPostDto.File != null)
            {
                blog.ImageName = updateDto.blogPostDto.File.CreateFile(_env.WebRootPath, "assets/img");
            }
            _blogRepository.Update(blog);
            await _blogRepository.SaveAsync();
        }
    }
}

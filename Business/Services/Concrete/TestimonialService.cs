namespace Business.Services.Concrete
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public TestimonialService(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TestimonialPostDto postDto)
        {
            await _testimonialRepository.CreateAsync(_mapper.Map<Testimonial>(postDto));
            await _testimonialRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Testimonial testimonial = await _testimonialRepository.GetAsync(t => t.Id == id && !t.IsDeleted);
            if (testimonial == null)
            {
                throw new NotFoundException(Messages.TestimonialNotFound);
            }
            _testimonialRepository.Delete(testimonial);
            await _testimonialRepository.SaveAsync();
        }

        public async Task<List<TestimonialGetDto>> GetAllAsync()
        {
            List<Testimonial> testimonials = await _testimonialRepository.GetAllAsync(t => !t.IsDeleted);
            //if (testimonials.Count == 0)
            //{
            //    throw new NotFoundException(Messages.TestimonialNotFound);
            //}
            return _mapper.Map<List<TestimonialGetDto>>(testimonials);
        }

        public async Task<TestimonialGetDto> GetByIdAsync(int id)
        {
            Testimonial testimonial = await _testimonialRepository.GetAsync(t => t.Id == id && !t.IsDeleted);
            if (testimonial == null)
            {
                throw new NotFoundException(Messages.TestimonialNotFound);
            }
            return _mapper.Map<TestimonialGetDto>(testimonial);
        }

        public async Task UpdateAsync(TestimonialUpdateDto updateDto)
        {
            Testimonial testimonial = await _testimonialRepository.GetAsync(t => t.Id == updateDto.testimonialGetDto.Id && !t.IsDeleted);
            if (testimonial == null)
            {
                throw new NotFoundException(Messages.TestimonialNotFound);
            }
            testimonial.Comment = updateDto.testimonialPostDto.Comment;
            testimonial.CustomerName = updateDto.testimonialPostDto.CustomerName;
            _testimonialRepository.Update(testimonial);
            await _testimonialRepository.SaveAsync();
        }
    }
}

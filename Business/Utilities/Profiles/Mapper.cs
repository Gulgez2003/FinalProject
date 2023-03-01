namespace Business.Utilities.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BlogPostDto, Blog>();
            CreateMap<Blog, BlogGetDto>();
            CreateMap<BlogUpdateDto, Blog>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();
            CreateMap<Service, ServiceGetDto>();
            CreateMap<SettingPostDto, Setting>();
            CreateMap<Setting, SettingGetDto>();
            CreateMap<TestimonialPostDto, Testimonial>();
            CreateMap<Testimonial, TestimonialGetDto>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<Reservation, ReservationGetDto>();
            CreateMap<RoomPostDto, Room>();
            CreateMap<Room, RoomGetDto>();
        }
    }
}

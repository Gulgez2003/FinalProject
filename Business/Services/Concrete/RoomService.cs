namespace Business.Services.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public RoomService(IRoomRepository roomRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync(RoomPostDto postDto)
        {
            Room room = new Room()
            {
                Title = postDto.Title,
                Price = postDto.Price,
                Services = postDto.Services,
                Size = postDto.Size,
                Description = postDto.Description,
                BedType = postDto.BedType,
                Capacity = postDto.Capacity,
                ImageName = FileExtention.CreateFile(postDto.File, _env.WebRootPath, "assets/img")
            };
            await _roomRepository.CreateAsync(room);
            await _roomRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Room room = await _roomRepository.GetAsync(b => b.Id == id && !b.IsDeleted);
            if (room == null)
            {
                throw new NotFoundException(Messages.RoomNotFound);
            }
            _roomRepository.Delete(room);
            await _roomRepository.SaveAsync();
        }

        public async Task<List<RoomGetDto>> GetAllAsync()
        {
            List<Room> rooms = await _roomRepository.GetAllAsync(b => !b.IsDeleted);
            if (rooms == null)
            {
                throw new NotFoundException(Messages.RoomNotFound);
            }
            return _mapper.Map<List<RoomGetDto>>(rooms);
        }

        public async Task<RoomGetDto> GetByIdAsync(int id)
        {
            Room room = await _roomRepository.GetAsync(b => b.Id == id && !b.IsDeleted);
            if (room == null)
            {
                throw new NotFoundException(Messages.RoomNotFound);
            }
            return _mapper.Map<RoomGetDto>(room);
        }

        public RoomGetDto GetRoom(int id)
        {
            Room room = _roomRepository.FirstOrDefault(s => s.Id == id);
            RoomGetDto roomGetDto = new RoomGetDto()
            {
                Title = room.Title,
                Price = room.Price,
                Services = room.Services,
                Size = room.Size,
                Description = room.Description,
                BedType = room.BedType,
                Capacity = room.Capacity
            };
            return roomGetDto;
        }

        public async Task<List<RoomGetDto>> GetSearchResults(string type, int capacity, double minPrice, double maxPrice)
        {
            List<Room> rooms = await _roomRepository.GetAllAsync(r => !r.IsDeleted 
            && r.IsAvailable
            || r.Title.Contains(type)
            && r.Capacity <= capacity
            && r.Price >= minPrice
            && r.Price <= maxPrice);
            if (rooms == null)
            {
                throw new NotFoundException(Messages.RoomNotFound);
            }
            return _mapper.Map<List<RoomGetDto>>(rooms);
        }

        public async Task UpdateAsync(RoomUpdateDto updateDto)
        {
            Room room = await _roomRepository.GetAsync(b => b.Id == updateDto.roomGetDto.Id && !b.IsDeleted);
            if (room == null)
            {
                throw new NotFoundException(Messages.RoomNotFound);
            }
            room.Title = updateDto.roomPostDto.Title;
            room.Price = updateDto.roomPostDto.Price;
            room.Size = updateDto.roomPostDto.Size;
            room.Capacity = updateDto.roomPostDto.Capacity;
            room.BedType = updateDto.roomPostDto.BedType;
            room.Description = updateDto.roomPostDto.Description;
            room.Services = updateDto.roomPostDto.Services;

            if (updateDto.roomPostDto.File != null)
            {
                room.ImageName = updateDto.roomPostDto.File.CreateFile(_env.WebRootPath, "assets/img");
            }

            _roomRepository.Update(room);
            await _roomRepository.SaveAsync();
        }
    }
}

namespace Business.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(ReservationCreateDto createDto)
        {
            Reservation reservation = new Reservation()
            {
                FullName = createDto.FullName,
                Email = createDto.Email,
                PhoneNumber = createDto.PhoneNumber,
                Room = createDto.Room,
                NumberOfAdults = createDto.NumberOfAdults,
                NumberOfChildren = createDto.NumberOfChildren,
                NumberOfInfants = createDto.NumberOfInfants,
                ArrivalDateTime = (DateTime)(createDto?.ArrivalDateTime),
                DepartureDateTime = (DateTime)(createDto?.DepartureDateTime),
                Message = createDto.Message
            };
            await _reservationRepository.CreateAsync(reservation);
            await _reservationRepository.SaveAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReservationGetDto>> GetAllAsync()
        {
            List<Reservation> reservations = await _reservationRepository.GetAllAsync();

            return _mapper.Map<List<ReservationGetDto>>(reservations);
        }

        public Task<ReservationGetDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

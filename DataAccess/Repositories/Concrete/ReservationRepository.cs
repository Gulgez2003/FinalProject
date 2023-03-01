namespace DataAccess.Repositories.Concrete
{
    public class ReservationRepository : EntityRepositoryBase<Reservation, AppDbContext>, IReservationRepository
    {
        public ReservationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

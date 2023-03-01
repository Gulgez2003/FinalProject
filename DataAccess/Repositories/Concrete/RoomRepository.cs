namespace DataAccess.Repositories.Concrete
{
    public class RoomRepository : EntityRepositoryBase<Room, AppDbContext>, IRoomRepository
    {
        public RoomRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

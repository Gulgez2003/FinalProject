namespace DataAccess.Repositories.Concrete
{
    public class BlogRepository : EntityRepositoryBase<Blog, AppDbContext>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext):base(dbContext)
        {
        }
    }
}

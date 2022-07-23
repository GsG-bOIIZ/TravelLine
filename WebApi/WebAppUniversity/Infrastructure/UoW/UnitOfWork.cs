using WebAppUniversity.Infrastructure;

namespace WebAppUniversity.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityDbContext _dbContext;

        public UnitOfWork(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;
using WebAppUniversity.Infrastructure;

namespace WebAppUniversity.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly UniversityDbContext _dbContext;

        public GroupRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Group> GetGroups()
        {
            return _dbContext.Class.ToList();
        }

        public Group Get(int id)
        {
            return _dbContext.Class.FirstOrDefault(x => x.Id == id);
        }

        public Group Create(Group group)
        {
            var entity = _dbContext.Class.Add(group);
            return entity.Entity;
        }

        public void Delete(Group group)
        {
            _dbContext.Class.Remove(group);
        }

        public void Update(Group group)
        {
            _dbContext.Class.Update(group);
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;
using WebAppUniversity.Infrastructure;

namespace WebAppUniversity.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly UniversityDbContext _dbContext;

        public FacultyRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Faculty> GetFaculties()
        {
            return _dbContext.Faculty.ToList();
        }

        public Faculty Get(int id)
        {
            return _dbContext.Faculty.FirstOrDefault(x => x.Id == id);
        }

        public Faculty Create(Faculty faculty)
        {
            var entity = _dbContext.Faculty.Add(faculty);
            return entity.Entity;
        }

        public void Delete(Faculty faculty)
        {
            _dbContext.Faculty.Remove(faculty);
        }

        public void Update(Faculty faculty)
        {
            _dbContext.Faculty.Update(faculty);
        }

        public Faculty GetByName(string name)
        {
            return _dbContext.Faculty.FirstOrDefault(x => x.Name == name);
        }
    }
}

using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IFacultyRepository
    {
        public List<Faculty> GetFaculties();
        public int Create(Faculty faculty);
        public int Update(Faculty faculty);
        public void Delete(Faculty faculty);
        public Faculty Get(int id);
    }
}

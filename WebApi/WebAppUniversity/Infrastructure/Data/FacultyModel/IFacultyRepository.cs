using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IFacultyRepository
    {
        List<Faculty> GetFaculties();
        Faculty? Get(int id);
        Faculty Create(Faculty faculty);
        void Delete(Faculty faculty);
        void Update(Faculty faculty);
    }
}

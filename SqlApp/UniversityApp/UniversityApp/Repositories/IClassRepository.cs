using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    public interface IClassRepository
    {
        IReadOnlyList<Class> GetAll();
        IReadOnlyList<Class> GetByFacultyId( int facultyId );
        Class GetById( int id );
        void Update( Class Class );
        void Delete( Class Class );
    }
}

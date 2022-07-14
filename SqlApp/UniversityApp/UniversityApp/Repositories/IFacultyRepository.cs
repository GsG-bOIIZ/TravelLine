using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    public interface IFacultyRepository
    {
        IReadOnlyList<Faculty> GetAll();

        void Delete( Faculty faculty );
        Faculty GetByName( string name );
    }
}

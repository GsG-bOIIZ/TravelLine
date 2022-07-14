using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    public interface IStudentRepository
    {
        IReadOnlyList<Student> GetAll();
        IReadOnlyList<string> GroupFromAge();
        Student GetById(int id);

    }
}

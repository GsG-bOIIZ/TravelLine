using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student? Get(int id);
        Student Create(Student student);
        void Delete(Student student);
        void Update(Student student);
    }
}

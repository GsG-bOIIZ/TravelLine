using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();
        public int Create(Student student);
        public void Delete(Student student);
        public Student Get(int id);
        public int Update(Student student);
    }
}

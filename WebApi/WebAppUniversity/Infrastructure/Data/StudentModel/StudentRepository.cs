using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;
using WebAppUniversity.Infrastructure;

namespace WebAppUniversity.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public StudentRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetStudents()
        {
            return _dbContext.Student.ToList();
        }

        public Student Get(int id)
        {
            return _dbContext.Student.FirstOrDefault(x => x.Id == id);
        }

        public Student Create(Student student)
        {
            var entity = _dbContext.Student.Add(student);
            return entity.Entity;
        }

        public void Delete(Student student)
        {
            _dbContext.Student.Remove(student);
        }

        public void Update(Student student)
        {
            _dbContext.Student.Update(student);
        }

        public List<Student> GetStudentsWithClassId(int classId)
        {
            return _dbContext.Student.Where(x => x.ClassId == classId).ToList();
        }

        public Student GetBySurname(string surname)
        {
            return _dbContext.Student.FirstOrDefault(x => x.Surname == surname);
        }
    }
}

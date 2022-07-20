using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;

namespace WebAppUniversity.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public int CreateStudent(StudentDto student)
        {
            if (student == null)
            {
                throw new Exception($"{nameof(student)} not found");
            }

            Student studentEntity = student.ConvertToStudent();

            return _studentRepository.Create(studentEntity);
        }

        public void DeleteStudent(int studentId)
        {
            Student student = _studentRepository.Get(studentId);
            if (student == null)
            {
                throw new Exception($"{nameof(student)} not found, #Id - {studentId}");
            }

            _studentRepository.Delete(student);
        }

        public Student GetStudent(int studentId)
        {
            Student student = _studentRepository.Get(studentId);
            if (student == null)
            {
                throw new Exception($"{nameof(student)} not found, #Id - {studentId}");
            }

            return student;
        }
    }
}

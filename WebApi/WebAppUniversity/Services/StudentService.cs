using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;
using WebAppUniversity.UnitOfWork;

namespace WebAppUniversity.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
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

            int id = _studentRepository.Create(studentEntity).Id;
            _unitOfWork.Commit();

            return id;
        }

        public void DeleteStudent(int studentId)
        {
            Student student = _studentRepository.Get(studentId);
            if (student == null)
            {
                throw new Exception($"{nameof(student)} not found, #Id - {studentId}");
            }

            _studentRepository.Delete(student);
            _unitOfWork.Commit();
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
        
        public int UpdateStudent(StudentDto studentDto)
        {
            if (studentDto == null)
            {
                throw new Exception($"{nameof(studentDto)} not found");
            }
            
            Student studentEntity = studentDto.ConvertToStudent();

            _studentRepository.Update( studentEntity );
            _unitOfWork.Commit();
            
            return studentEntity.Id;
        }     

        public List<Student> GetStudentsWithClassId(int classId)
        {
            List<Student> students = _studentRepository.GetStudentsWithClassId(classId);
            if (students == null)
            {
                throw new Exception($"{nameof(students)} not found, #facultyId - {classId}");
            }

            return students;
        }

        public Student GetStudentBySurname(string surname)
        {
            Student student = _studentRepository.GetBySurname(surname);
            if (student == null)
            {
                throw new Exception($"{nameof(student)} not found, #surname - {surname}");
            }

            return student;
        }


    }
}

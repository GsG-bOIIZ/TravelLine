using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;

namespace WebAppUniversity.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public List<Faculty> GetFaculties()
        {
            return _facultyRepository.GetFaculties();
        }

        public int CreateFaculty(FacultyDto faculty)
        {
            if (faculty == null)
            {
                throw new Exception($"{nameof(faculty)} not found");
            }

            Faculty facultyEntity = faculty.ConvertToFaculty();

            return _facultyRepository.Create(facultyEntity);
        }

        public void DeleteFaculty(int facultyId)
        {
            Faculty faculty = _facultyRepository.Get(facultyId);
            if (faculty == null)
            {
                throw new Exception($"{nameof(faculty)} not found, #Id - {facultyId}");
            }

            _facultyRepository.Delete(faculty);
        }

        public Faculty GetFaculty(int facultyId)
        {
            Faculty faculty = _facultyRepository.Get(facultyId);
            if (faculty == null)
            {
                throw new Exception($"{nameof(faculty)} not found, #Id - {facultyId}");
            }

            return faculty;
        }
    }
}

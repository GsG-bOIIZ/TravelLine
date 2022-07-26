using WebAppUniversity.Domain;
using WebAppUniversity.Dto;
using WebAppUniversity.Repositories;
using WebAppUniversity.UnitOfWork;

namespace WebAppUniversity.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FacultyService(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
        {
            _facultyRepository = facultyRepository;
            _unitOfWork = unitOfWork;
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

            int id = _facultyRepository.Create( facultyEntity ).Id;
            _unitOfWork.Commit();

            return id;
        }

        public void DeleteFaculty(int facultyId)
        {
            Faculty faculty = _facultyRepository.Get(facultyId);
            if (faculty == null)
            {
                throw new Exception($"{nameof(faculty)} not found, #Id - {facultyId}");
            }

            _facultyRepository.Delete(faculty);
            _unitOfWork.Commit();
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
        
        public int UpdateFaculty(FacultyDto facultyDto)
        {
            if (facultyDto == null)
            {
                throw new Exception($"{nameof(facultyDto)} not found");
            }
            
            Faculty facultyEntity = facultyDto.ConvertToFaculty();

            _facultyRepository.Update( facultyEntity );
            _unitOfWork.Commit();
            
            return facultyEntity.Id;
        }

        public Faculty GetFacultyByName(string name)
        {
            Faculty faculty = _facultyRepository.GetByName(name);
            if (faculty == null)
            {
                throw new Exception($"{nameof(faculty)} not found, #surname - {name}");
            }

            return faculty;
        }
    }
}

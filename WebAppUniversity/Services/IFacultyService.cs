using WebAppUniversity.Domain;
using WebAppUniversity.Dto;

namespace WebAppUniversity.Services
{
    public interface IFacultyService
    {
        public List<Faculty> GetFaculties();
        public int CreateFaculty(FacultyDto faculty);
        public void DeleteFaculty(int facultyId);
        public Faculty GetFaculty(int facultyId);
    }
}

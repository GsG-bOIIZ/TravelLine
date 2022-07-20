using WebAppUniversity.Domain;

namespace WebAppUniversity.Dto
{
    public static class FacultyDtoExtensions
    {
        public static Faculty ConvertToFaculty(this FacultyDto faculty)
        {
            return new Faculty
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Dean = faculty.Dean
            };
        }

        public static FacultyDto ConvertToFacultyDto(this Faculty facultyDto)
        {
            return new FacultyDto
            {
                Id = facultyDto.Id,
                Name = facultyDto.Name,
                Dean = facultyDto.Dean
            };
        }
    }
}

using WebAppUniversity.Domain;

namespace WebAppUniversity.Dto
{
    public static class StudentDtoExtensions
    {
        public static Student ConvertToStudent(this StudentDto student)
        {
            return new Student
            {
                Id = student.Id,
                Surname = student.Surname,
                Name = student.Name,
                Patronymic = student.Patronymic,
                Age = student.Age,
                ClassId = student.ClassId
            };
        }

        public static StudentDto ConvertToStudentDto(this Student studentDto)
        {
            return new StudentDto
            {
                Id = studentDto.Id,
                Surname = studentDto.Surname,
                Name = studentDto.Name,
                Patronymic = studentDto.Patronymic,
                Age = studentDto.Age,
                ClassId = studentDto.ClassId
            };
        }
    }
}

namespace UniversityApp.Models
{
    public class Student
    {
        public int Id { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public int Age { get; private set; }
        public int ClassId { get; private set; }

        public Student(int id, string surname, string name, string patronymic, int age, int classId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Age = age;
            ClassId = classId;
        }
    }
}

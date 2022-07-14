using UniversityApp.Models;
using UniversityApp.Repositories;

const string connectionString = @"Data Source=DESKTOP-JELFJO7\SQLEXPRESS;Initial Catalog=University;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

IFacultyRepository facultyRepository = new RawSqlFacultyRepository( connectionString );
IClassRepository classRepository = new RawSqlClassRepository( connectionString );
IStudentRepository studentRepository = new RawSqlStudentRepository( connectionString );


PrintCommands();
while (true)
{
    Console.WriteLine("Введите команду:");
    string command = Console.ReadLine();

    if (command == "get-faculties")
    {
        IReadOnlyList<Faculty> faculties = facultyRepository.GetAll();
        if (faculties.Count == 0)
        {
            Console.WriteLine("Факультеты не найдены!");
            continue;
        }

        foreach (Faculty faculty in faculties)
        {
            Console.WriteLine($"Id: {faculty.Id}, Name: {faculty.Name}, Dean: {faculty.Dean}");
        }
    }
    else if (command == "get-faculty-by-name")
    {
        Console.WriteLine("Введите название факультета:");
        string name = Console.ReadLine();
        Faculty faculty = facultyRepository.GetByName(name);
        if (faculty == null)
        {
            Console.WriteLine("Факультет не найден");
        }
        else
        {
            Console.WriteLine($"Id: {faculty.Id}, Name: {faculty.Name}, Dean: {faculty.Dean}");
        }

    }
    else if (command == "delete-faculty-by-name")
    {
        Console.WriteLine("Введите название факультета:");
        string name = Console.ReadLine();
        Faculty faculty = facultyRepository.GetByName(name);
        if (faculty == null)
        {
            Console.WriteLine("Факультет не найден");
            continue;
        }
        else
        {
            facultyRepository.Delete(faculty);
            Console.WriteLine("Факультет удален");
        }
    }
    else if (command == "get-class-by-facultyid")
    {
        Console.WriteLine("Введите Id факультета:");
        string temp = Console.ReadLine();
        int id;
        if (!int.TryParse(temp, out id))
        {
            Console.WriteLine("Неккоректный id");
            continue;
        }
        IReadOnlyList<Class> classes = classRepository.GetByFacultyId(id);
        if (classes.Count == 0)
        {
            Console.WriteLine("Классы не найдены");
            continue;
        }

        foreach (Class Class in classes)
        {
            Console.WriteLine($"Id: {Class.Id}, Name: {Class.Name}, FacultyId: {Class.FacultyId}");
        }
    }
    else if (command == "get-classes")
    {
        IReadOnlyList<Class> Classes = classRepository.GetAll();
        if (Classes.Count == 0)
        {
            Console.WriteLine("Факультеты не найдены!");
            continue;
        }

        foreach (Class Class in Classes)
        {
            Console.WriteLine($"Id: {Class.Id}, Name: {Class.Name}, FacultyId: {Class.FacultyId}");
        }
    }
    else if (command == "get-class-by-id")
    {
        Console.WriteLine("Введите Id:");
        string temp = Console.ReadLine();
        int id;
        if (!int.TryParse(temp, out id))
        {
            Console.WriteLine("Неккоректный id");
            continue;
        }
        Class Class = classRepository.GetById(id);
        if (Class == null)
        {
            Console.WriteLine("Класс не найден");
        }
        else
        {
            Console.WriteLine($"Id: {Class.Id}, Name: {Class.Name}, FacultyId: {Class.FacultyId}");
        }
    }
    else if (command == "update-class-by-id")
    {
        Console.WriteLine("Введите Id:");
        string temp = Console.ReadLine();
        int id;
        if (!int.TryParse(temp, out id))
        {
            Console.WriteLine("Неккоректный id");
            continue;
        }
        Class Class = classRepository.GetById(id);
        if (Class == null)
        {
            Console.WriteLine("Класс не найден");
            continue;
        }

        Console.WriteLine("Введите новое имя:");
        string newName = Console.ReadLine();
        if (string.IsNullOrEmpty(newName))
        {
            Console.WriteLine("Неккоректный имя:");
            continue;
        }
        Class.UpdateName(newName);

        IReadOnlyList<Faculty> faculties = facultyRepository.GetAll();
        List<int> FacultiesId = new List<int>();
        foreach (Faculty faculty in faculties)
        {
            FacultiesId.Add(faculty.Id);
        }
        Console.WriteLine("Введите новое id факультета:");
        temp = Console.ReadLine();
        if (!int.TryParse(temp, out id) || !FacultiesId.Contains(id))
        {
            Console.WriteLine("Неккоректный id");
            continue;
        }
        Class.UpdateFacultyId(id);

        classRepository.Update( Class );
        Console.WriteLine("Класс обновлен");
    }
    else if (command == "group-students-from-age")
    {
        IReadOnlyList<string> students = studentRepository.GroupFromAge();
        Console.WriteLine("Кол-во студентов -- Возраст");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }
    }
    else if (command == "get-student-by-id")
    {
        Console.WriteLine("Введите Id:");
        string temp = Console.ReadLine();
        int id;
        if (!int.TryParse(temp, out id))
        {
            Console.WriteLine("Неккоректный id");
            continue;
        }

        Student student = studentRepository.GetById(id);
        if (student == null)
        {
            Console.WriteLine("Студент не найден");
            continue;
        }
        else
        {
            Console.WriteLine($"" +
                $"Id: {student.Id}, " +
                $"ФИО: {student.Surname} {student.Name} {student.Patronymic}, " +
                $"Age: {student.Age}, " +
                $"ClassId: {student.ClassId}"
            );
        }
    }
    else if (command == "help")
    {
        PrintCommands();
    }
    else if (command == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Неправильно введенная команда");
    }
}




void PrintCommands()
{
    Console.WriteLine("Доступные команды:\n");
    Console.WriteLine("get-faculties - Получить список факультетов");
    Console.WriteLine("get-faculty-by-name - Получить факультет по названию");
    Console.WriteLine("delete-faculty-by-name - Удалить факультет по названию");
    Console.WriteLine("get-class-by-facultyid - Получить список классов одного факультета");
    Console.WriteLine("get-classes - Получить список классов");
    Console.WriteLine("get-class-by-id - Получить класс по id");
    Console.WriteLine("update-class-by-id - Изменить поля класса по id");
    Console.WriteLine("group-students-from-age - Количество ровесников");
    Console.WriteLine("get-student-by-id - Получить студента по id");

    Console.WriteLine("help - все команды");
    Console.WriteLine("exit - Выход\n");
}
namespace UniversityApp.Models
{
    public class Class
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int FacultyId { get; private set; }

        public Class( int id, string name, int facultyId )
        {
            Id = id;
            Name = name;
            FacultyId = facultyId;
        }

        public void UpdateName( string newName )
        {
            Name = newName;
        }

        public void UpdateFacultyId( int newId )
        {
            FacultyId = newId;
        }
    }
}

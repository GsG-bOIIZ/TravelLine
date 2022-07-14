namespace UniversityApp.Models
{
    public class Faculty
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Dean { get; private set; }

        public Faculty( int id, string name, string dean )
        {
            Id = id;
            Name = name;
            Dean = dean;
        }
    }
}

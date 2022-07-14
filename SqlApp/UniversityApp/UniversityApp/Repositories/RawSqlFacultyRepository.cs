using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    public class RawSqlFacultyRepository : IFacultyRepository
    {
        private readonly string _connectionString;

        public RawSqlFacultyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(Faculty faculty)
        {
            if (faculty == null)
            {
                throw new ArgumentNullException(nameof(faculty));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Faculty] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = faculty.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public IReadOnlyList<Faculty> GetAll()
        {
            var result = new List<Faculty>();

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Dean] from [Faculty]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                result.Add(new Faculty(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToString( reader[ "Name" ] ),
                    Convert.ToString( reader[ "Dean" ] )
                ));
            }

            return result;
        }

        public Faculty GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Dean] from [Faculty] where [Name] = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Faculty(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Dean"])
                );
            }
            else
            {
                Console.WriteLine($"Факультет под названием {name} не существует");
                return null;
            }
        }
    }
}

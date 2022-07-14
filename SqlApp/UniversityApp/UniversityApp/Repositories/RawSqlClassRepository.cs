using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    public class RawSqlClassRepository : IClassRepository
    {
        private readonly string _connectionString;

        public RawSqlClassRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public IReadOnlyList<Class> GetAll()
        {
            var result = new List<Class>();

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [FacultyId] from [Class]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                result.Add(new Class(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToString( reader[ "Name" ] ),
                    Convert.ToInt32( reader[ "FacultyId" ] )
                ));
            }

            return result;
        }

        public IReadOnlyList<Class> GetByFacultyId(int facultyId)
        {
            var result = new List<Class>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [FacultyId] from [Class] where [FacultyId] = @facultyId";
            sqlCommand.Parameters.Add("@facultyId", SqlDbType.Int).Value = facultyId;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Class(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["FacultyId"])
                ));
            }

            return result;
        }

        public Class GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [FacultyId] from [Class] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Class(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["FacultyId"])
                );
            }
            else
            {
                return null;
            }
        }

        public void Update(Class Class)
        {
            if (Class == null)
            {
                throw new ArgumentNullException(nameof(Class));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Class] set [Name] = @name, [FacultyId] = @facultyId where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = Class.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = Class.Name;
            sqlCommand.Parameters.Add("@facultyId", SqlDbType.Int).Value = Class.FacultyId;
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete(Class Class)
        {
            if (Class == null)
            {
                throw new ArgumentNullException(nameof(Class));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Author] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = Class.Id;
            sqlCommand.ExecuteNonQuery();
        }

    }
}

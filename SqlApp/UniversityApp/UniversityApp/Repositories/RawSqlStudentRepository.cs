using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using UniversityApp.Models;

namespace UniversityApp.Repositories
{
    internal class RawSqlStudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public RawSqlStudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Student> GetAll()
        {
            var result = new List<Student>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Surname], [Name], [Patronymic], [Age], [ClassId] from [Student]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Student(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Surname"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Patronymic"]),
                    Convert.ToInt32(reader["Age"]),
                    Convert.ToInt32(reader["ClassId"])
                ));
            }

            return result;
        }

        public IReadOnlyList<string> GroupFromAge()
        {
            var result = new List<string>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select count([Id]) AmountOfStudents, [Age] from [Student] group by [Age] order by [Age] desc";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add($"{Convert.ToString(reader["AmountOfStudents"]), -5}{Convert.ToInt32(reader["Age"]), -10}");
            }

            return result;
        }

        public Student GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Surname], [Name], [Patronymic], [Age], [ClassId] from [Student] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Student(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Surname"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Patronymic"]),
                    Convert.ToInt32(reader["Age"]),
                    Convert.ToInt32(reader["ClassId"])
                );
            }
            else
            {
                return null;
            }
        }
    }
}

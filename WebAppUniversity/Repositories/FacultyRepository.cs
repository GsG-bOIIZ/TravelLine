using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly string _connectionString;

        public FacultyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Faculty> GetFaculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Faculty]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            faculties.Add(new Faculty
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Dean = Convert.ToString(reader["Dean"])
                            });
                        }
                    }
                }
            }
            return faculties;
        }

        public int Create(Faculty faculty)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Faculty] (Name, Dean) VALUES (@name, @dean)";
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = faculty.Name;
                    cmd.Parameters.Add("@dean", SqlDbType.NVarChar).Value = faculty.Dean;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Faculty faculty)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Faculty] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = faculty.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Faculty Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Faculty] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Faculty
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Dean = Convert.ToString(reader["Dean"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public int Update(Faculty faculty)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Faculty] SET [Name] = @name, [Dean] = @dean
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = faculty.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = faculty.Name;
                    cmd.Parameters.Add("@dean", SqlDbType.NVarChar).Value = faculty.Dean;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}

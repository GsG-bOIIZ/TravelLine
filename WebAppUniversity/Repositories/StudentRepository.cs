using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Student]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Surname = Convert.ToString(reader["Surname"]),
                                Name = Convert.ToString(reader["Name"]),
                                Patronymic = Convert.ToString(reader["Patronymic"]),
                                Age = Convert.ToInt32(reader["Age"]),
                                ClassId = Convert.ToInt32(reader["ClassId"])
                            });
                        }
                    }
                }
            }
            return students;
        }

        public int Create(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Student] (Surname, Name, Patronymic, Age, ClassId) VALUES (@surname, @name, @patronymic, @age, @class_id)";
                    cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = student.Surname;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                    cmd.Parameters.Add("@patronymic", SqlDbType.NVarChar).Value = student.Patronymic;
                    cmd.Parameters.Add("@age", SqlDbType.NVarChar).Value = student.Age;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.Int).Value = student.ClassId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Student] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Student Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Student] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Surname = Convert.ToString(reader["Surname"]),
                                Name = Convert.ToString(reader["Name"]),
                                Patronymic = Convert.ToString(reader["Patronymic"]),
                                Age = Convert.ToInt32(reader["Age"]),
                                ClassId = Convert.ToInt32(reader["ClassId"])
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

        public int Update(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Student] SET [Surname] = @surname, [Name] = @name, [Patronymic] = @patronymic, [Age] = @age, [ClassId] = @class_id
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = student.Surname;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                    cmd.Parameters.Add("@patronymic", SqlDbType.NVarChar).Value = student.Patronymic;
                    cmd.Parameters.Add("@age", SqlDbType.NVarChar).Value = student.Age;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.Int).Value = student.ClassId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}

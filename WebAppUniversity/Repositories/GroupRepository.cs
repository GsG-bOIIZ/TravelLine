using System.Data;
using System.Data.SqlClient;
using WebAppUniversity.Domain;

namespace WebAppUniversity.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly string _connectionString;

        public GroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Group> GetGroupes()
        {
            List<Group> groupes = new List<Group>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Class]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groupes.Add(new Group
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                FacultyId = Convert.ToInt32(reader["FacultyId"])
                            });
                        }
                    }
                }
            }
            return groupes;
        }

        public int Create(Group group)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Class] (Name, FacultyId) VALUES (@name, @faculty_id)";
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = group.Name;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.NVarChar).Value = group.FacultyId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Group group)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Class] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = group.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Group Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Class] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Group
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = Convert.ToString(reader["Name"]),
                                FacultyId = Convert.ToInt32(reader["FacultyId"])
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

        public int Update(Group group)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Class] SET [Name] = @name, [FacultyId] = @faculty_id
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = group.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = group.Name;
                    cmd.Parameters.Add("@faculty_id", SqlDbType.NVarChar).Value = group.FacultyId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddUser(LoginUsers user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_addRegisterUsers", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LoginUsers GetUser(LoginUsers user)
        {
            LoginUsers? result = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_getUserList", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new LoginUsers
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                    }
                }
            }

            return result;
        }

        public IEnumerable<LoginUsers> GetAllUsers()
        {
            var users = new List<LoginUsers>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Name, Email, Phone, Password, RegisterDate  FROM users", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new LoginUsers
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Password = reader["Password"].ToString(),
                            RegisterDate = Convert.ToDateTime(reader["RegisterDate"])
                        });
                    }
                }
            }
            return users;
        }

        public LoginUsers? GetUserByEmailID(string Email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Email = @Email", connection))
            {
                cmd.Parameters.AddWithValue("@Email", Email);
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoginUsers
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }
            }
            return null;
        }


        public void UpdateUser(LoginUsers user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_updateUserList", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal object GenerateJwtToken(string email)
        {
            throw new NotImplementedException();
        }
    }
}

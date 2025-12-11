//using Microsoft.Data.SqlClient;
//using One_City_One_Pay.Moduls;
//using System.Data;

//namespace One_City_One_Pay.Data
//{
//    public class UserRepository
//    {
//        private readonly string _connectionString;

//        public UserRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }

//        public void AddUser(LoginUsers user)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_addRegisterUsers", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Name", user.Name);
//                cmd.Parameters.AddWithValue("@Email", user.Email);
//                cmd.Parameters.AddWithValue("@Phone", user.Phone);
//                cmd.Parameters.AddWithValue("@Password", user.Password);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public LoginUsers GetUser(LoginUsers user)
//        {
//            LoginUsers? result = null;

//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_getUserList", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@Email", user.Email);
//                cmd.Parameters.AddWithValue("@Password", user.Password);

//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        result = new LoginUsers
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            Name = reader["Name"].ToString(),
//                            Email = reader["Email"].ToString()
//                        };
//                    }
//                }
//            }

//            return result;
//        }

//        public IEnumerable<LoginUsers> GetAllUsers()
//        {
//            var users = new List<LoginUsers>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, Name, Email, Phone, Password, RegisterDate  FROM users", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        users.Add(new LoginUsers
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            Name = reader["Name"].ToString(),
//                            Email = reader["Email"].ToString(),
//                            Phone = reader["Phone"].ToString(),
//                            Password = reader["Password"].ToString(),
//                            RegisterDate = Convert.ToDateTime(reader["RegisterDate"])
//                        });
//                    }
//                }
//            }
//            return users;
//        }

//        public LoginUsers? GetUserByEmailID(string Email)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Email = @Email", connection))
//            {
//                cmd.Parameters.AddWithValue("@Email", Email);
//                connection.Open();
//                using (var reader = cmd.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        return new LoginUsers
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            Name = reader["Name"].ToString(),
//                            Email = reader["Email"].ToString(),
//                            Phone = reader["Phone"].ToString(),
//                            Password = reader["Password"].ToString()
//                        };
//                    }
//                }
//            }
//            return null;
//        }


//        public void UpdateUser(LoginUsers user)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_updateUserList", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@id", user.Id);
//                cmd.Parameters.AddWithValue("@Email", user.Email);
//                cmd.Parameters.AddWithValue("@Password", user.Password);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        internal object GenerateJwtToken(string email)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}



//postersql
using Npgsql;
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

        // ---------------------- ADD USER ---------------------------
        public void AddUser(LoginUsers user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            using (var cmd = new NpgsqlCommand(@"INSERT INTO users 
                (name, email, phone, password, registerdate) 
                VALUES (@Name, @Email, @Phone, @Password, NOW())", connection))
            {
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------------- GET USER BY LOGIN -------------------
        public LoginUsers? GetUser(LoginUsers user)
        {
            LoginUsers? result = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            using (var cmd = new NpgsqlCommand(
                @"SELECT id, name, email 
                  FROM users 
                  WHERE email=@Email", connection))
            {
                cmd.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new LoginUsers
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2)
                        };
                    }
                }
            }
            return result;
        }

        // ---------------------- GET ALL USERS ------------------------
        public IEnumerable<LoginUsers> GetAllUsers()
        {
            var users = new List<LoginUsers>();

            using (var connection = new NpgsqlConnection(_connectionString))
            using (var cmd = new NpgsqlCommand(
                @"SELECT id, name, email, phone, password, registerdate 
                  FROM users ORDER BY id DESC", connection))
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new LoginUsers
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Password = reader.GetString(4),
                            RegisterDate = reader.GetDateTime(5)
                        });
                    }
                }
            }
            return users;
        }

        // ---------------------- GET USER BY EMAIL --------------------
        public LoginUsers? GetUserByEmailID(string email)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            using (var cmd = new NpgsqlCommand(
                @"SELECT * FROM users WHERE email=@Email", connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoginUsers
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            Password = reader.GetString(reader.GetOrdinal("password"))
                        };
                    }
                }
            }
            return null;
        }

        // ---------------------- UPDATE USER ---------------------------
        public void UpdateUser(LoginUsers user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            using (var cmd = new NpgsqlCommand(
                @"UPDATE users 
                  SET email=@Email, password=@Password 
                  WHERE id=@Id", connection))
            {
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

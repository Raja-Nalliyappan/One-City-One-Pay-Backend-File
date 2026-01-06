//using Microsoft.Data.SqlClient;
//using One_City_One_Pay.Moduls;
//using System.Data;

//namespace One_City_One_Pay.Data
//{
//    public class BookingCountAndAmountRepository
//    {
//        private readonly string _connectionString;

//        public BookingCountAndAmountRepository (IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }


//        // Posting Booking Count And Amount Stored Procedure
//        public void AddBikeBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_BikeBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void AddAutoBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_AutoBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void AddCarBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_CarBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void AddBusBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_BusBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void AddMetroBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_MetroBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void AddLocalTrainBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("sp_LocalTrainBookingCountAndAmount", connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
//                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
//                cmd.Parameters.AddWithValue("@UserName", userName);
//                connection.Open();
//                cmd.ExecuteNonQuery();
//            }
//        }






//        //Get all Booking count and amount List Without using SP = used inline for my ref
//        public IEnumerable<BikeBookingCountAndAmount> GetBikeBookingCountAndAmount()
//        {
//            var bikeBookingData = new List<BikeBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM BikeBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        bikeBookingData.Add(new BikeBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return bikeBookingData;
//        }

//        public IEnumerable<AutoBookingCountAndAmount> GetAutoBookingCountAndAmount()
//        {
//            var autoBookingData = new List<AutoBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM AutoBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        autoBookingData.Add(new AutoBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return autoBookingData;
//        }

//        public IEnumerable<CarBookingCountAndAmount> GetCarBookingCountAndAmount()
//        {
//            var carBookingData = new List<CarBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM CarBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        carBookingData.Add(new CarBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return carBookingData;
//        }

//        public IEnumerable<BusBookingCountAndAmount> GetBusBookingCountAndAmount()
//        {
//            var busBookingData = new List<BusBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM BusBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        busBookingData.Add(new BusBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return busBookingData;
//        }

//        public IEnumerable<MetroBookingCountAndAmount> GetMetroBookingCountAndAmount()
//        {
//            var metroBookingData = new List<MetroBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM MetroBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        metroBookingData.Add(new MetroBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return metroBookingData;
//        }

//        public IEnumerable<LocalTrainBookingCountAndAmount> GetLocalTrainBookingCountAndAmount()
//        {
//            var localTrainBookingData = new List<LocalTrainBookingCountAndAmount>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM LocalTrainBookingCountAndAmount", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        localTrainBookingData.Add(new LocalTrainBookingCountAndAmount
//                        {
//                            Id = Convert.ToInt32(reader["Id"]),
//                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
//                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
//                            VehicleType = reader["VehicleType"].ToString(),
//                            UserName = reader["UserName"].ToString()
//                        });
//                    }
//                }
//            }
//            return localTrainBookingData;
//        }
//    }
//}






















//postersql

//using Npgsql;
//using One_City_One_Pay.Moduls;
//using System.Data;

//namespace One_City_One_Pay.Data
//{
//    public class BookingCountAndAmountRepository
//    {
//        private readonly string _connectionString;

//        public BookingCountAndAmountRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }

//        // ----------------------------- POSTING (USING SP) -----------------------------

//        public void AddBikeBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddBikeBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        public void AddAutoBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddAutoBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        public void AddCarBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddCarBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        public void AddBusBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddBusBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        public void AddMetroBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddMetroBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        public void AddLocalTrainBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
//        {
//            using var connection = new NpgsqlConnection(_connectionString);
//            using var cmd = new NpgsqlCommand("sp_AddLocalTrainBookingCountAndAmount", connection)
//            {
//                CommandType = CommandType.StoredProcedure
//            };
//            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
//            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
//            cmd.Parameters.AddWithValue("p_username", userName);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//        }

//        // ----------------------------- GET LIST (USING SP) -----------------------------

//        public IEnumerable<BikeBookingCountAndAmount> GetBikeBookingCountAndAmount()
//        {
//            var bikeBookingData = new List<BikeBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            // 1️⃣ Call stored procedure
//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetBikeBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "bike_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            // 2️⃣ Fetch data from cursor
//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM bike_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    bikeBookingData.Add(new BikeBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return bikeBookingData;
//        }


//        public IEnumerable<AutoBookingCountAndAmount> GetAutoBookingCountAndAmount()
//        {
//            var autoBookingData = new List<AutoBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetAutoBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "auto_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM auto_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    autoBookingData.Add(new AutoBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return autoBookingData;
//        }


//        public IEnumerable<CarBookingCountAndAmount> GetCarBookingCountAndAmount()
//        {
//            var carBookingData = new List<CarBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetCarBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "car_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM car_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    carBookingData.Add(new CarBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return carBookingData;
//        }



//        public IEnumerable<BusBookingCountAndAmount> GetBusBookingCountAndAmount()
//        {
//            var busBookingData = new List<BusBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetBusBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "bus_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM bus_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    busBookingData.Add(new BusBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return busBookingData;
//        }


//        public IEnumerable<MetroBookingCountAndAmount> GetMetroBookingCountAndAmount()
//        {
//            var metroBookingData = new List<MetroBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetMetroBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "metro_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM metro_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    metroBookingData.Add(new MetroBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return metroBookingData;
//        }


//        public IEnumerable<LocalTrainBookingCountAndAmount> GetLocalTrainBookingCountAndAmount()
//        {
//            var localTrainBookingData = new List<LocalTrainBookingCountAndAmount>();

//            using var connection = new NpgsqlConnection(_connectionString);
//            connection.Open();

//            using var transaction = connection.BeginTransaction();

//            using (var cmd = new NpgsqlCommand(
//                "CALL sp_GetLocalTrainBookingCountAndAmount(@ref)", connection, transaction))
//            {
//                cmd.Parameters.Add(new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor)
//                {
//                    Direction = ParameterDirection.InputOutput,
//                    Value = "localtrain_cursor"
//                });

//                cmd.ExecuteNonQuery();
//            }

//            using (var fetchCmd = new NpgsqlCommand(
//                "FETCH ALL FROM localtrain_cursor", connection, transaction))
//            using (var reader = fetchCmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    localTrainBookingData.Add(new LocalTrainBookingCountAndAmount
//                    {
//                        Id = reader.GetInt32(reader.GetOrdinal("id")),
//                        BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
//                        BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate"))
//                            ? null
//                            : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
//                        VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
//                        UserName = reader.GetString(reader.GetOrdinal("username"))
//                    });
//                }
//            }

//            transaction.Commit();
//            return localTrainBookingData;
//        }

//    }
//}











//supabase

using Npgsql;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class BookingCountAndAmountRepository
    {
        private readonly string _connectionString;

        public BookingCountAndAmountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ----------------------------- POSTING (USING FUNCTIONS) -----------------------------

        public void AddBikeBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_bike_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddAutoBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_auto_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddCarBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_car_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddBusBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_bus_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddMetroBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_metro_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddLocalTrainBookingCountAndAmount(decimal bookingAmount, string vehicleType, string userName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand("SELECT fn_add_localtrain_booking_count_and_amount(@p_bookingamount, @p_vehicletype, @p_username)", connection);
            cmd.Parameters.AddWithValue("p_bookingamount", bookingAmount);
            cmd.Parameters.AddWithValue("p_vehicletype", vehicleType);
            cmd.Parameters.AddWithValue("p_username", userName);
            connection.Open();
            cmd.ExecuteNonQuery();
        }



        // ----------------------------- GET LIST (USING FUNCTIONS) -----------------------------

        // ----------------- BIKE BOOKINGS -----------------
        public IEnumerable<BikeBookingCountAndAmount> GetBikeBookingCountAndAmount()
        {
            var bikeBookingData = new List<BikeBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM bikebookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bikeBookingData.Add(new BikeBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return bikeBookingData;
        }

        // ----------------- AUTO BOOKINGS -----------------
        public IEnumerable<AutoBookingCountAndAmount> GetAutoBookingCountAndAmount()
        {
            var autoBookingData = new List<AutoBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM autobookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                autoBookingData.Add(new AutoBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return autoBookingData;
        }

        // ----------------- CAR BOOKINGS -----------------
        public IEnumerable<CarBookingCountAndAmount> GetCarBookingCountAndAmount()
        {
            var carBookingData = new List<CarBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM carbookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                carBookingData.Add(new CarBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return carBookingData;
        }

        // ----------------- BUS BOOKINGS -----------------
        public IEnumerable<BusBookingCountAndAmount> GetBusBookingCountAndAmount()
        {
            var busBookingData = new List<BusBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM busbookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                busBookingData.Add(new BusBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return busBookingData;
        }

        // ----------------- METRO BOOKINGS -----------------
        public IEnumerable<MetroBookingCountAndAmount> GetMetroBookingCountAndAmount()
        {
            var metroBookingData = new List<MetroBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM metrobookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                metroBookingData.Add(new MetroBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return metroBookingData;
        }

        // ----------------- LOCAL TRAIN BOOKINGS -----------------
        public IEnumerable<LocalTrainBookingCountAndAmount> GetLocalTrainBookingCountAndAmount()
        {
            var localTrainBookingData = new List<LocalTrainBookingCountAndAmount>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM localtrainbookingcountandamount", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                localTrainBookingData.Add(new LocalTrainBookingCountAndAmount
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    BookingAmount = reader.GetDecimal(reader.GetOrdinal("bookingamount")),
                    BookingDate = reader.IsDBNull(reader.GetOrdinal("bookingdate")) ? null : reader.GetDateTime(reader.GetOrdinal("bookingdate")),
                    VehicleType = reader.GetString(reader.GetOrdinal("vehicletype")),
                    UserName = reader.GetString(reader.GetOrdinal("username"))
                });
            }

            return localTrainBookingData;
        }


    }
}

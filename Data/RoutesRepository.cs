//using Microsoft.Data.SqlClient;
//using One_City_One_Pay.Moduls;
//using System.Data;

//namespace One_City_One_Pay.Data
//{
//    public class RoutesRepository
//    {
//        private readonly string _connectionString;

//        public RoutesRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection") 
//                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//        }

//        public List<T> GetAllRoutes <T> (string storedProcedure) where T : BaseRoute, new()
//        {
//            List<T> routes = new List<T>();
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;
//                connection.Open();
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        routes.Add(new T
//                        {
//                            RouteId = Convert.ToInt32(reader["RouteId"]),
//                            FromLocation = reader["FromLocation"]?.ToString() ?? string.Empty,
//                            ToLocation = reader["ToLocation"]?.ToString() ?? string.Empty,
//                            Price = Convert.ToDecimal(reader["Price"]),
//                        });
//                    }
//                }
//            }
//            return routes;
//        }

//        public List<BikeRoute> GetAllBikeRoutes() => GetAllRoutes<BikeRoute>("GetAllBikeRoutes");
//        public List<AutoRoute> GetAllAutoRoutes() => GetAllRoutes<AutoRoute>("GetAllAutoRoutes");
//        public List<CarRoute> GetAllCarRoutes() => GetAllRoutes<CarRoute>("GetAllCarRoutes");
//        public List<BusRoute> GetAllBusRoutes() => GetAllRoutes<BusRoute>("GetAllBusRoutes");
//        public List<MetroRoute> GetAllMetroRoutes() => GetAllRoutes<MetroRoute>("GetAllMetroRoutes");
//        public List<LocalTrainRoute> GetAllLocalTrainRoutes() => GetAllRoutes<LocalTrainRoute>("GetAllLocalTrainRoutes");
//    }
//}








//postresql 

using Npgsql;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class RoutesRepository
    {
        private readonly string _connectionString;

        public RoutesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        private List<T> GetAllRoutesFromSP<T>(string spName) where T : BaseRoute, new()
        {
            List<T> routes = new List<T>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                using (var cmd = new NpgsqlCommand(spName, connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Create a cursor parameter
                    var refCursor = cmd.Parameters.Add("ref", NpgsqlTypes.NpgsqlDbType.Refcursor);
                    refCursor.Direction = ParameterDirection.InputOutput;
                    refCursor.Value = "mycursor";

                    cmd.ExecuteNonQuery();

                    // Fetch all from the cursor
                    using (var fetchCmd = new NpgsqlCommand("FETCH ALL FROM mycursor;", connection, transaction))
                    using (var reader = fetchCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            routes.Add(new T
                            {
                                RouteId = reader.GetInt32(reader.GetOrdinal("routeid")),
                                FromLocation = reader.GetString(reader.GetOrdinal("fromlocation")),
                                ToLocation = reader.GetString(reader.GetOrdinal("tolocation")),
                                Price = reader.GetDecimal(reader.GetOrdinal("price"))
                            });
                        }
                    }

                    transaction.Commit();
                }
            }

            return routes;
        }

        // SP mappings
        public List<BikeRoute> GetAllBikeRoutes() => GetAllRoutesFromSP<BikeRoute>("sp_getallbikeroutes");
        public List<AutoRoute> GetAllAutoRoutes() => GetAllRoutesFromSP<AutoRoute>("sp_getallautoroutes");
        public List<CarRoute> GetAllCarRoutes() => GetAllRoutesFromSP<CarRoute>("sp_getallcarroutes");
        public List<BusRoute> GetAllBusRoutes() => GetAllRoutesFromSP<BusRoute>("sp_getallbusroutes");
        public List<MetroRoute> GetAllMetroRoutes() => GetAllRoutesFromSP<MetroRoute>("sp_getallmetroroutes");
        public List<LocalTrainRoute> GetAllLocalTrainRoutes() => GetAllRoutesFromSP<LocalTrainRoute>("sp_getalllocaltrainroutes");
    }
}

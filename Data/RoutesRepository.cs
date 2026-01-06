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

namespace One_City_One_Pay.Data
{
    public class RoutesRepository
    {
        private readonly string _connectionString;

        public RoutesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }

        private List<T> GetAllRoutesFromFunction<T>(string functionName) where T : BaseRoute, new()
        {
            var routes = new List<T>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand(
                $"SELECT * FROM {functionName}()", connection);

            using var reader = cmd.ExecuteReader();

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

            return routes;
        }

        // ✅ PostgreSQL FUNCTIONS
        public List<BikeRoute> GetAllBikeRoutes()
            => GetAllRoutesFromFunction<BikeRoute>("fn_getallbikeroutes");

        public List<AutoRoute> GetAllAutoRoutes()
            => GetAllRoutesFromFunction<AutoRoute>("fn_getallautoroutes");

        public List<CarRoute> GetAllCarRoutes()
            => GetAllRoutesFromFunction<CarRoute>("fn_getallcarroutes");

        public List<BusRoute> GetAllBusRoutes()
            => GetAllRoutesFromFunction<BusRoute>("fn_getallbusroutes");

        public List<MetroRoute> GetAllMetroRoutes()
            => GetAllRoutesFromFunction<MetroRoute>("fn_getallmetroroutes");

        public List<LocalTrainRoute> GetAllLocalTrainRoutes()
            => GetAllRoutesFromFunction<LocalTrainRoute>("fn_getalllocaltrainroutes");
    }
}

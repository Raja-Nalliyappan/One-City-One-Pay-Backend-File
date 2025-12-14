//using Microsoft.Data.SqlClient;
//using One_City_One_Pay.Moduls;
//using System.Data;

//namespace One_City_One_Pay.Data
//{
//    public class ReviewRepository
//    {
//        private readonly string? _connectionString;
//        public ReviewRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }



//        // Add a new review comment to the database
//        public void AddReview(string name, string reviewComments) 
//        {
//        using (SqlConnection connection = new SqlConnection(_connectionString))
//        using (SqlCommand command = new SqlCommand("AddAllReviewComments", connection))
//            {
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                command.Parameters.AddWithValue("Name", name);
//                command.Parameters.AddWithValue("ReviewComments", reviewComments);
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }



//        // Retrieve all review comments from the database
//        public List<ReviewComment> GetReviewComments()
//        {
//            var reviewComments = new List<ReviewComment>();

//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            using (SqlCommand command = new SqlCommand("Select * from UserReviewComments", connection))
//            {
//                connection.Open();
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        var reviewComment = new ReviewComment
//                        {
//                            Id = reader.GetInt32(0),
//                            Name = reader.GetString(1),
//                            ReviewComments = reader.GetString(2)
//                        };
//                        reviewComments.Add(reviewComment);
//                    }
//                }
//            }

//            return reviewComments;
//        }
//    }
//}







//postgresql version

using Npgsql;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class ReviewRepository
    {
        private readonly string? _connectionString;

        public ReviewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Add a new review comment to PostgreSQL
        public void AddReview(string name, string reviewComments)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            using (var command = new NpgsqlCommand("CALL addallreviewcomments(@Name, @ReviewComments)", connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ReviewComments", reviewComments);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Retrieve all review comments
        public List<ReviewComment> GetReviewComments()
        {
            var reviewComments = new List<ReviewComment>();

            using (var connection = new NpgsqlConnection(_connectionString))
            using (var command = new NpgsqlCommand("SELECT * FROM userreviewcomments", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reviewComments.Add(new ReviewComment
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ReviewComments = reader.GetString(2)
                        });
                    }
                }
            }
            return reviewComments;
        }
    }
}

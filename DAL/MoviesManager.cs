using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MoviesManager
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["moviesConnectionString"].ConnectionString;
        public static List<Movie> GetAllMovies()
        {
            List<Movie> list = new List<Movie>();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlComm = new SqlCommand("GetAllMovies", conn);
                //sqlComm.Parameters.AddWithValue("@Start", StartTime);
                //sqlComm.Parameters.AddWithValue("@Finish", FinishTime);
                //sqlComm.Parameters.AddWithValue("@TimeRange", TimeRange);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            if (ds.Tables.Count == 1)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Movie movie = new Movie();
                    movie.Id = Convert.ToInt32(item["Id"]);
                    movie.Title = item["Title"].ToString();
                    movie.Author = item["Author"].ToString();
                    list.Add(movie);
                }
            }
            return list;
        }
        public static void InsertMovie(Movie movie)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlComm = new SqlCommand("InsertMovie", conn);
                sqlComm.Parameters.AddWithValue("@Title", movie.Title);
                sqlComm.Parameters.AddWithValue("@Author", movie.Author);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }
        }
    }
}

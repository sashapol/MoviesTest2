using BL.Contracts;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MoviesService : IMoviesService
    {
        public InitResponse Init()
        {
            InitResponse response = new InitResponse() { IsSuccess = true };
            response.EmptyMovie = new Movie();
            return response;
        }
        public GetAllMoviesResponse GetAllMovies()
        {
            GetAllMoviesResponse response = new GetAllMoviesResponse() { IsSuccess = true };
            try
            {
                response.MoviesList = MoviesManager.GetAllMovies().OrderByDescending(x=>x.Id).ToList();
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public InsertMovieResponse InsertMovie(InsertMovieRequest request)
        {
            InsertMovieResponse response = new InsertMovieResponse() { IsSuccess = true };
            try
            {
                if (request.Movie == null)
                {
                    throw new MovieAppException("The movie is empty");
                }
                if (String.IsNullOrEmpty(request.Movie.Title))
                {
                    throw new MovieAppException("The movie title field is empty");

                }
                if (String.IsNullOrEmpty(request.Movie.Author))
                {
                    throw new MovieAppException("The movie author field is empty");
                }
                MoviesManager.InsertMovie(request.Movie);
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                response.IsApplicationError = (e.GetType() == typeof(MovieAppException));
            }
            return response;
        }
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IMoviesService
    {
        InitResponse Init();
        GetAllMoviesResponse GetAllMovies();
        InsertMovieResponse InsertMovie(InsertMovieRequest request);
    }

    public class GetAllMoviesResponse : BaseResponse
    {
        public List<Movie> MoviesList { get; set; }
    }

    public class InitResponse : BaseResponse
    {
        public Movie EmptyMovie { get; set; }
    }
    public class InsertMovieResponse : BaseResponse
    {
    }
    

    public class InsertMovieRequest
    {
        public Movie Movie { get; set; }
    }

    
}

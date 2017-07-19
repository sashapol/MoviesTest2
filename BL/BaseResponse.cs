using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsApplicationError { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class MovieAppException : Exception
    {
        public MovieAppException()
        {

        }
        public MovieAppException(string message)
            : base(message)
        {

        }
        public MovieAppException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

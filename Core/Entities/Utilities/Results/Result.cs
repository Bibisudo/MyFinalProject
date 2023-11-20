using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
    public class Result : IResult
    {
       public Result(bool success, string message):this(success) //this demek, classın kendisi demek. Burada 
                                                                 // resultın tek parametli olan ctorına successi yolla diyoruz.
        {
           Message= message;
           
        }

        public Result(bool success) //Overload ediyoruz.
        {
            
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }

    }
}

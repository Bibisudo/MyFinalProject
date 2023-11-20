using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }   //- readonly, getterlar okumak için setterlar yazmak için burada sadece getter var.
        string Message { get; } 
    }
}

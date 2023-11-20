using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //İşlem başarılı true dönüyor ve mesaj veriyor.
        {
        }
        public SuccessResult(): base(true) //İşlem başarılı ama mesaj vermek istemeyince kullanılacak.
        {
        }
    }
}

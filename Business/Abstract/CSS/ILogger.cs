using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.CSS
{
    public interface ILogger //Loglama: yapılan operasyonların bir yerde kaydının tutulması.
                             // Üç yerde loglama çalıştırılabilir; metodun başı, sonu, hata verirse ortası
    {
        void Log();
    }
}

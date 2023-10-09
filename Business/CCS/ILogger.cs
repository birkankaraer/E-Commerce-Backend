using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public interface ILogger
    {
        //MicroService mimarisinin kullanılabilirliğini sağlar.
        void Log();
    }
}

using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public class FileLogger : ILogger //Dosyaya loglama, veri tabanına loglama, sunucuya, mail atma vs
    {
        //Birbirinin alternatifi olan durumlarda interface ile implemente etmek çok daha iyi
        //Logları bir dosyaya alıyoruz
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfiguration
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; }

        public string CacheType { get; set; }

        public string RedisHostIp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.BaileysPhonesAndRepairs.Adapters;

namespace BA.BaileysPhonesAndRepairs.Configuration
{
    public class EmailConfigurationModel
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string ToName { get; set; }
        public string DefaultToAddress { get;  set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionApi.Models
{
    public class UserSessionAggregator
    {
        public int Logons { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}

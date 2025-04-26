using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OcelotDownAPI
{
    public class IdentityServerConfig
    {
        public string IP { get; set; }
        public string Port { get; set; }
        public string IdentityScheme { get; set; }
        public string ResourceName { get; set; }
    }
}

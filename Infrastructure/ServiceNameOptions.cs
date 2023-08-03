using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class ServiceNameOptions
    {
        public const string Key = "ServiceNameOptionsSettings";
        public string ApiKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.APIModels
{
    public class FilterModel
    {
        public string? Contains { get; set; }
        public string? GreaterThan { get; set; }
        public string? LessThan { get; set; }
        public string? EqualToo { get; set; }
        public string? Limit { get; set; }
        public string? OffSet { get; set; }
    }
}

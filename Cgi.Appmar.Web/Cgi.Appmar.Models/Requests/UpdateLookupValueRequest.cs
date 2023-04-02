using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgi.Appmar.Models.Requests
{
    public class UpdateLookupValueRequest
    {
        public int LookupValueId { get; set; }

        public string LookupValue { get; set;} = string.Empty;
    }
}

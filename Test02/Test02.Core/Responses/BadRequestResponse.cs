using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test02.Core.Responses
{
    public class BadRequestResponse
    {
        public string Message { get; set; }
        public object Request { get; set; }
    }
}

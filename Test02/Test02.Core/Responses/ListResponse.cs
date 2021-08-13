using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test02.Core.Responses
{
    public class ListResponse<T>
    {
        public List<T> Items { get; set; }
        public int Results
        {
            get
            {
                return Items == null ? 0 : Items.Count;
            }
        }
    }
}

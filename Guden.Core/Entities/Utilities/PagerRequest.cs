using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Entities.Utilities
{
    public class PagerRequest
    {
       
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumb { get; set; }
        public bool IsSortColumbDesc { get; set; }

    }
}

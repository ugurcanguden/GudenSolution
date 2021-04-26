using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guden.Api.Model.Utilities
{
    public class PagerRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumb { get; set; }
    }
}

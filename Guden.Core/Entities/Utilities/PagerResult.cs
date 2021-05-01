using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Entities.Utilities
{
    public class PagerResult<T>
    {
        public List<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumb { get; set; }
        public int TotalPage { get; set; }
        public int TotalRowCount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

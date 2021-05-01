
using Guden.Core.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Guden.Core.Utilities.ToolUtilities
{
    public  static class PagerResult<T>
    {
        public static Guden.Core.Entities.Utilities.PagerResult<T> GetPagerRequest(List<T> list ,PagerRequest pagerRequest)
        {
            List<T> sortingList = new List<T>();

            if(!string.IsNullOrEmpty(pagerRequest.SortColumb))
            {

                var enumerable = typeof(AssemblyProductAttribute).GetProperty(pagerRequest.SortColumb); 
                System.Reflection.PropertyInfo prop = typeof(T).GetProperty(pagerRequest.SortColumb);
                if(pagerRequest.IsSortColumbDesc)               
                    sortingList= list.OrderByDescending(x => prop.GetValue(x, null))
                                        .Skip((pagerRequest.PageIndex - 1) * pagerRequest.PageSize)
                                        .Take(pagerRequest.PageSize)
                                        .ToList();
                else
                    sortingList = list.OrderBy(x => prop.GetValue(x, null))
                                        .Skip((pagerRequest.PageIndex - 1) * pagerRequest.PageSize)
                                        .Take(pagerRequest.PageSize)
                                        .ToList();
            }
            else
            {
                sortingList = list.Skip((pagerRequest.PageIndex-1) * pagerRequest.PageSize)
                                   .Take(pagerRequest.PageSize)
                                   .ToList();
            }

          
            return  new Guden.Core.Entities.Utilities.PagerResult<T>() 
            { 
                Data=sortingList,
                PageIndex=pagerRequest.PageIndex,
                PageSize=pagerRequest.PageSize,
                TotalPage= list.Count/ pagerRequest.PageSize+1,      
                SortColumb=pagerRequest.SortColumb,
                TotalRowCount= list.Count,
                CreateDate=DateTime.Now
            };
        }
    }
}

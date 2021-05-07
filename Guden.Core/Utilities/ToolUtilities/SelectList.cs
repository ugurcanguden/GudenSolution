using Guden.Core.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Utilities.ToolUtilities
{
    public static class SelectList<T>
    {
        public static List<SelectList> GetSelectList(List<T> list ,string key,string text,string value)
        {
            List<string> columbNames = new List<string>();
            columbNames.Add(text);
            columbNames.Add(value);
            columbNames.Add(key);



            return (from DataRow dr in ToDataTable<T>(list, columbNames).Rows
                    select new SelectList()
                    {
                        key = dr[key].ToString(),
                        text = dr[text].ToString(),
                        value = dr[value]
                        
                    }).ToList(); ;
            

        }
        public static DataTable ToDataTable<T>(List<T> data,List<string> columbNames)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            foreach (DataColumn dc in table.Columns)
            {
                if (!columbNames.Contains(dc.ColumnName))
                    table.Columns.Remove(dc.ColumnName);
            }

            return table;
        }
    }
}

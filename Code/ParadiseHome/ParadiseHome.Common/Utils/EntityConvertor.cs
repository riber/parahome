using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace ParadiseHome.Common.Utils
{
    public class EntityConvertor
    {
        /// <summary>
        /// 从Datatable中转换创建实体集合
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="table">要转换的Datatable集合</param>
        /// <returns></returns>
        public static IList<Object> CreateEntity(Type entityType, DataTable table)
        {
            List<Object> backObjs = null;
            if (entityType != null && table != null)
            {
                if (table.Rows.Count > 0)
                {
                    try
                    {
                        backObjs = new List<Object>();
                        Assembly asm = Assembly.GetExecutingAssembly();
                        // 一行对应一个实体
                        for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                        {
                            Object obj = asm.CreateInstance(entityType.FullName, true);
                            // 一列对应实体的一个属性
                            for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                            {
                                string caption = table.Columns[colIndex].Caption;
                                PropertyInfo pinfo = obj.GetType().GetProperty(caption);
                                pinfo.SetValue(obj, table.Rows[rowIndex].ItemArray[colIndex], null);
                            }
                            backObjs.Add(obj);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                    
                }
            }
            return backObjs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ParadiseHome.Common.Utils
{
    public class EntityConvertor
    {
        /// <summary>
        /// 从Datatable中转换创建实体集合
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="table">要转换的Datatable集合</param>
        /// <returns>转换出来的对象集合</returns>
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
                                if (table.Rows[rowIndex].ItemArray[colIndex].GetType() != typeof(DBNull))
                                {
                                    pinfo.SetValue(obj, table.Rows[rowIndex].ItemArray[colIndex], null);
                                }
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

        /// <summary>
        /// 从实体对象获得所有的属性对象列表
        /// </summary>
        /// <param name="entityObject">要转换的实体对象</param>
        /// <returns>所有的属性对象列表</returns>
        public static List<object> GetPropertyObjects(Object entityObject)
        {
            List<object> resultObjs = new List<object>();
            PropertyInfo[] pinfos = entityObject.GetType().GetProperties();
            foreach (PropertyInfo pinfo in pinfos)
            {
                resultObjs.Add(pinfo.GetValue(entityObject, null));
            }
            return resultObjs;
        }

        /// <summary>
        /// 从实体对象获得所有的属性名称列表
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns>所有的属性名称列表</returns>
        public static List<string> GetPropertyNames(Type entityType)
        {
            List<string> propertyNames = new List<string>();
            PropertyInfo[] pinfos = entityType.GetProperties();
            foreach (PropertyInfo pinfo in pinfos)
            {
                propertyNames.Add(pinfo.Name);
            }
            return propertyNames;
        }

        /// <summary>
        /// 从实体类型中获得数据表名
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns>数据表名</returns>
        public static string GetTableName(Type entityType)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(entityType);
            DescriptionAttribute descAttribute = null;

            // 先从DescriptionAttribute中获取表名，获取不到则退出
            foreach (Attribute attrib in attributes)
            {
                if (attrib is DescriptionAttribute)
                {
                    descAttribute = attrib as DescriptionAttribute;
                }
            }
            if (descAttribute == null)
            {
                return "";
            }

            Regex reg = new Regex(@"(?<=\bTableName:)\w+\b");
            return reg.Match(descAttribute.Description).Value;
        }

        /// <summary>
        /// 从实体类型中获得主键名
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns>主键名</returns>
        public static string GetPrimaryKeyName(Type entityType)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(entityType);
            DescriptionAttribute descAttribute = null;

            // 先从DescriptionAttribute中获取主键名，获取不到则退出
            foreach (Attribute attrib in attributes)
            {
                if (attrib is DescriptionAttribute)
                {
                    descAttribute = attrib as DescriptionAttribute;
                }
            }
            if (descAttribute == null)
            {
                return "";
            }

            Regex reg = new Regex(@"(?<=\bPrimary:)\w+\b");
            return reg.Match(descAttribute.Description).Value;
        }

        /// <summary>
        /// 获取主键对象
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <param name="entityObject">实体对象</param>
        /// <returns>主键对象</returns>
        public static object GetPrimaryKey(Type entityType, object entityObject)
        {
            string primaryKey = GetPrimaryKeyName(entityType);
            if (string.IsNullOrEmpty(primaryKey) || entityObject == null)
            {
                return null;
            }
            PropertyInfo[] pinfos = entityObject.GetType().GetProperties();
            foreach (PropertyInfo pinfo in pinfos)
            {
                if (pinfo.Name == primaryKey)
                {
                    return pinfo.GetValue(entityObject, null);
                }
            }
            return null;
        }
    }
}

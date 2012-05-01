using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParadiseHome.Common.Utils;
using ParadiseHome.DAL.Interface;
using System.Data;
using System.Windows.Forms;
using ParadiseHome.Common.Model.Basic;

namespace ParadiseHome.BLL
{
    public class LocationTypeBLL
    {
        public enum OperationMode
        {
            InsertBefore,
            InsertAfter,
            Initial,
            None,
            Modify
        }

        /// <summary>
        /// 获取所有的位置类型节点
        /// </summary>
        /// <returns>所有的位置类型节点</returns>
        public static List<Locationtype> GetAll()
        {
            try
            {
                ISQLExecutor executor = ConfigurationHelper.Instance.CreateNewSQLExecutor() as ISQLExecutor;
                DataTable dataTable = executor.FindAll(typeof(Locationtype));
                if (null == dataTable || dataTable.Rows.Count == 0)
                {
                    return null;
                }
                return EntityConvertor.CreateEntity(typeof(Locationtype), dataTable).Select(n => n as Locationtype).ToList(); ;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取所有LocationType时出现错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="locationType">这里locationType.LocationDepth表示想要插入的位置</param>
        /// <param name="mode">插入的方式，有初始化、前插、后插三种</param>
        /// <returns></returns>
        public static bool Insert(Locationtype locationType, OperationMode mode)
        {
            try
            {
                ISQLExecutor executor = ConfigurationHelper.Instance.CreateNewSQLExecutor() as ISQLExecutor;
                bool isPosExist = executor.Exist(typeof(Locationtype), "LocationDepth=@LocationDepth", new List<object>() { locationType.LocationDepth });
                if (executor == null)
                {
                    return false;
                }
                int effectrow = 0;

                switch(mode)
                {
                    case OperationMode.Initial:
                        if (isPosExist)
                        {
                            return false;
                        }
                        // 初始化，深度肯定为0
                        locationType.LocationDepth = 0;
                        effectrow = executor.Insert(typeof(Locationtype), new List<object>() { locationType });
                        break;
                    case OperationMode.InsertAfter:
                        if (!isPosExist)
                        {
                            return false;
                        }
                        executor.ExecuteNonQuery(ConfigurationHelper.Instance.SqlDictionary["ResetAllBeforeInsert"],
                            new List<object>() { locationType.LocationDepth });
                        locationType.LocationDepth += 1;
                        effectrow = executor.Insert(typeof(Locationtype), new List<object>() { locationType });
                        break;
                    case OperationMode.InsertBefore:
                        if (!isPosExist)
                        {
                            return false;
                        }
                        executor.ExecuteNonQuery(ConfigurationHelper.Instance.SqlDictionary["ResetAllBeforeInsert"],
                            new List<object>() { locationType.LocationDepth - 1 });
                        effectrow = executor.Insert(typeof(Locationtype), new List<object>() { locationType });
                        break;
                    default:
                        break;
                }
                if (effectrow > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 按实体的ID来删除节点
        /// </summary>
        /// <param name="locationType">要删除的节点实体</param>
        /// <returns>是否成功</returns>
        public static bool Delete(Locationtype locationType)
        {
            try
            {
                ISQLExecutor executor = ConfigurationHelper.Instance.CreateNewSQLExecutor() as ISQLExecutor;
                if (executor.DeleteByPrimaryKey(typeof(Locationtype), locationType))
                {
                    executor.ExecuteNonQuery(ConfigurationHelper.Instance.SqlDictionary["ResetAllAfterDelete"], 
                        new List<object>() { locationType.LocationDepth });
                    return true;
                }
            }
            catch
            {
            	return false;
            }
            return false;
        }

        /// <summary>
        /// 按实体的ID来更新节点
        /// </summary>
        /// <param name="locationType">要更新的节点实体</param>
        /// <returns>是否成功</returns>
        public static bool Update(Locationtype locationType)
        {
            try
            {
                ISQLExecutor executor = ConfigurationHelper.Instance.CreateNewSQLExecutor() as ISQLExecutor;
                return executor.UpdateByPrimaryKey(typeof(Locationtype), locationType);
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ParadiseHome.DAL.Interface
{
    public interface ISQLExecutor
    {
        /// <summary>
        /// 执行传入的sql字符串查询语句
        /// </summary>
        /// <param name="sql">sql字符串，若需参数，则用'@'符号加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>查询的结果集</returns>
        DataTable Execute(String sql, List<object> paras = null);

        /// <summary>
        /// 执行非查询数据库操作
        /// </summary>
        /// <param name="sql">sql字符串，若需参数，则用'@'符号加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>相应的数据库操作所影响的行数</returns>
        int ExecuteNonQuery(String sql, List<object> paras = null);

        /// <summary>
        /// 向数据库插入实体集合
        /// </summary>
        /// <param name="type">要插入的实体类型(主键必须为0)</param>
        /// <param name="objects">要插入的实体集合</param>
        /// <returns>插入数据表的行数</returns>
        int Insert(Type type, List<object> objects);

        /// <summary>
        /// 获取符合某条件的某类型的所有实体
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名（可选）</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>所有实体对应的datatable</returns>
        DataTable FindAll(Type type, string whereSql = null, List<object> paras = null);

        /// <summary>
        /// 判断符合某条件的某类型是否存在
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where本身,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>若存在则返回true，不存在或者出错返回false</returns>
        bool Exist(Type type, string whereSql, List<object> paras = null);

        /// <summary>
        /// 按实体的主键来更新实体
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="entityObject">实体对象</param>
        /// <returns>更新成功返回true</returns>
        bool UpdateByPrimaryKey(Type type, object entityObject);

        /// <summary>
        /// 删除符合某条件的某类型的所有实体
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>删除的数据行数</returns>
        int Delete(Type type, string whereSql, List<object> paras = null);

        /// <summary>
        /// 按实体的主键来删除实体
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="entityObject">实体对象</param>
        /// <returns>删除成功则返回true</returns>
        bool DeleteByPrimaryKey(Type type, object entityObject);
    }
}

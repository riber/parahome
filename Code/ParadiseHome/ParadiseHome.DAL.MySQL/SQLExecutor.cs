using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParadiseHome.DAL.Interface;
using System.Data;
using MySql.Data.MySqlClient;
using ParadiseHome.Common.Utils;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reflection;

namespace ParadiseHome.DAL.MySQL
{
    public class SQLExecutor : ISQLExecutor
    {
        /// <summary>
        /// 执行传入的sql字符串查询语句
        /// </summary>
        /// <param name="sql">sql字符串，若需参数，则用'@'符号加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>查询的结果集</returns>
        public DataTable Execute(String sql, List<object> paras = null)
        {
            MySqlConnection mySqlConn = ConnectingMySqlDB();
            if (mySqlConn != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = mySqlConn;
                    cmd.CommandType = CommandType.Text;

                    if (sql.Count(p => p == '@') == 0 && paras == null)
                    {
                        // 无参数传入，正常执行
                    }
                    else if (sql.Count(p => p == '@') != 0 && paras != null && sql.Count(p => p == '@') == paras.Count)
                    {
                        // 有参数传入
                        Regex reg = new Regex(@"@\w+");
                        MatchCollection mc = reg.Matches(sql);
                        int index = 0;
                        foreach (Match m in mc)
                        {
                            cmd.Parameters.AddWithValue(m.Value, paras[index++]);
                        }
                    }
                    else
                    {
                        mySqlConn.Close();
                        return null;
                    }

                    DataSet dataSet = new DataSet();

                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                    mySqlAdapter.SelectCommand = cmd;
                    mySqlAdapter.Fill(dataSet);

                    mySqlConn.Close();

                    if (dataSet.Tables.Count != 0)
                    {
                        return dataSet.Tables[0];
                    }
                }
                catch
                {
                    mySqlConn.Close();
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// 执行非查询数据库操作
        /// </summary>
        /// <param name="sql">sql字符串，若需参数，则用'@'符号加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>相应的数据库操作所影响的行数</returns>
        public int ExecuteNonQuery(string sql, List<object> paras = null)
        {
            MySqlConnection mySqlConn = ConnectingMySqlDB();
            if (mySqlConn != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = mySqlConn;
                    cmd.CommandType = CommandType.Text;

                    int effectRow = 0;


                    if (sql.Count(p => p == '@') == 0 && paras == null)
                    {
                        // 无参数传入，正常执行
                        effectRow = cmd.ExecuteNonQuery();
                    }
                    else if(sql.Count(p => p == '@') != 0 && paras != null && sql.Count(p => p == '@') == paras.Count)
                    {
                        // 有参数传入
                        Regex reg = new Regex(@"@\w+");
                        MatchCollection mc = reg.Matches(sql);
                        int index = 0;
                        foreach(Match m in mc)
                        {
                            cmd.Parameters.AddWithValue(m.Value, paras[index++]);
                        }
                        effectRow = cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        effectRow = 0;
                    }

                    mySqlConn.Close();
                    return effectRow;

                }
                catch
                {
                    mySqlConn.Close();
                    return 0;
                }
            }
            return 0;
        }

        /// <summary>
        /// 向数据库插入实体集合
        /// </summary>
        /// <param name="type">要插入的实体类型</param>
        /// <param name="objects">要插入的实体集合</param>
        /// <returns>插入数据表的行数</returns>
        public int Insert(Type type, List<object> objects)
        {
            if (objects == null || objects.Count == 0)
            {
                return 0;
            }

            string tableName = EntityConvertor.GetTableName(type);

            // 没写表名则退出
            if (string.IsNullOrEmpty(tableName))
            {
                return 0;
            }

            StringBuilder sbTotalSql = new StringBuilder();
            // 前缀
            sbTotalSql.Append("insert into ");
            // 表名
            sbTotalSql.Append(tableName);
            // 最终插入前缀
            sbTotalSql.Append(" values(");
            // 插入实体

            List<object> totalParamObjs = new List<object>();

            // 组合字符串
            List<string> propertyNames = EntityConvertor.GetPropertyNames(type);

            int index = 0;
            foreach(object entityObj in objects)
            {
                totalParamObjs.AddRange(EntityConvertor.GetPropertyObjects(entityObj));
                foreach (String propertyName in propertyNames)
                {
                    sbTotalSql.Append("@");
                    sbTotalSql.Append(propertyName);
                    sbTotalSql.Append("__");
                    sbTotalSql.Append(index.ToString());
                    sbTotalSql.Append(",");
                }
                // 去掉末尾的“，”
                sbTotalSql.Remove(sbTotalSql.Length - 1, 1);

                // 是否到尽头操作不一样
                if (index++ < objects.Count -1)
                {
                    sbTotalSql.Append("),(");
                }
            }

            // 最终插入后缀
            sbTotalSql.Append(");");

            return ExecuteNonQuery(sbTotalSql.ToString(),totalParamObjs);
        }

        /// <summary>
        /// 获取符合某条件的某类型的所有实体
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名（可选）</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>所有实体对应的datatable</returns>
        public DataTable FindAll(Type type , string whereSql = null, List<object> paras = null)
        {
            string tableName = EntityConvertor.GetTableName(type);

            // 没写表名则退出
            if (string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            // 属性名
            List<string> propertyNames = EntityConvertor.GetPropertyNames(type);

            StringBuilder sbTotalSql = new StringBuilder();
            // 前缀
            sbTotalSql.Append("select ");
            int index = 0;
            // 中间部分
            foreach (var item in propertyNames)
            {
                sbTotalSql.Append(item);
                if (index++ != propertyNames.Count - 1)
                {
                    // 不到最后一个都要加“，”
                    sbTotalSql.Append(",");
                }
            }
            // 后缀
            sbTotalSql.Append(" from ");
            sbTotalSql.Append(tableName);

            if (!string.IsNullOrEmpty(whereSql))
            {
                sbTotalSql.Append(" where ");
                sbTotalSql.Append(whereSql);
            }

            return Execute(sbTotalSql.ToString(), paras);
        }

        /// <summary>
        /// 判断符合某条件的某类型是否存在
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where本身,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>若存在则返回true，不存在或者出错返回false</returns>
        public bool Exist(Type type, string whereSql, List<object> paras = null)
        {
            MySqlConnection mySqlConn = ConnectingMySqlDB();
            if (mySqlConn != null)
            {
                string tableName = EntityConvertor.GetTableName(type);
                string primaryKeyName = EntityConvertor.GetPrimaryKeyName(type);

                if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(primaryKeyName))
                {
                    // 先组合字符串
                    StringBuilder sbTotalSQL = new StringBuilder();
                    // 前缀
                    sbTotalSQL.Append("select count(");
                    sbTotalSQL.Append(primaryKeyName);
                    sbTotalSQL.Append(") from ");
                    sbTotalSQL.Append(tableName);

                    if (!string.IsNullOrEmpty(whereSql))
                    {
                        sbTotalSQL.Append(" where ");
                        sbTotalSQL.Append(whereSql);
                    }

                    string sql = sbTotalSQL.ToString();

                    try
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.CommandText = sql;
                        cmd.Connection = mySqlConn;
                        cmd.CommandType = CommandType.Text;

                        MySqlDataReader reader;


                        if (sql.Count(p => p == '@') == 0 && paras == null)
                        {
                            // 无参数传入，正常执行
                            reader = cmd.ExecuteReader();
                        }
                        else if (sql.Count(p => p == '@') != 0 && paras != null && sql.Count(p => p == '@') == paras.Count)
                        {
                            // 有参数传入
                            Regex reg = new Regex(@"@\w+");
                            MatchCollection mc = reg.Matches(sql);
                            int index = 0;
                            foreach (Match m in mc)
                            {
                                cmd.Parameters.AddWithValue(m.Value, paras[index++]);
                            }
                            reader = cmd.ExecuteReader();
                        }
                        else
                        {
                            mySqlConn.Close();
                            return false;
                        }

                        bool res = false;
                        if (reader.Read())
                        {
                            res = reader.GetInt32(0) > 0 ? true : false;
                        }
                        
                        mySqlConn.Close();
                        return res;
                    }
                    catch
                    {
                        mySqlConn.Close();
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 按实体的主键来更新实体
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="entityObject">实体对象</param>
        /// <returns>更新成功返回true</returns>
        public bool UpdateByPrimaryKey(Type type, object entityObject)
        {
            string tableName = EntityConvertor.GetTableName(type);
            string primaryKeyName = EntityConvertor.GetPrimaryKeyName(type);

            if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(primaryKeyName))
            {
                // 先组合字符串
                StringBuilder sbTotalSQL = new StringBuilder();
                // 前缀
                sbTotalSQL.Append("update ");
                sbTotalSQL.Append(tableName);
                sbTotalSQL.Append(" set ");
                // 中间
                // 属性名
                List<string> propertyNames = EntityConvertor.GetPropertyNames(type);
                int index = 0;
                // 中间部分
                foreach (var item in propertyNames)
                {
                    sbTotalSQL.Append(item);
                    sbTotalSQL.Append("=@");
                    sbTotalSQL.Append(item);
                    if (index++ != propertyNames.Count - 1)
                    {
                        // 不到最后一个都要加“，”
                        sbTotalSQL.Append(",");
                    }
                }
                // 后面
                sbTotalSQL.Append(" where ");
                sbTotalSQL.Append(primaryKeyName);
                sbTotalSQL.Append("=@primaryKey__0");

                List<object> paras = EntityConvertor.GetPropertyObjects(entityObject);
                // 还要添上主键的值
                paras.Add(EntityConvertor.GetPrimaryKey(type, entityObject));

                int effectRow = ExecuteNonQuery(sbTotalSQL.ToString(), paras);

                if (effectRow > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除符合某条件的某类型的所有实体
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="whereSql">查询sql语句的where部分，不含where,若需参数，则用'@'符号
        /// 加在单词前方即可，如@param，参数不可重名</param>
        /// <param name="paras">'@'符号所替代的参数（可选）</param>
        /// <returns>删除的数据行数</returns>
        public int Delete(Type type, string whereSql, List<object> paras = null)
        {
            string tableName = EntityConvertor.GetTableName(type);

            // 先组合字符串
            StringBuilder sbTotalSQL = new StringBuilder();
            // 前缀
            sbTotalSQL.Append("delete from ");
            sbTotalSQL.Append(tableName);

            if (string.IsNullOrEmpty(whereSql))
            {
                return 0;
            }

            sbTotalSQL.Append(" where ");
            sbTotalSQL.Append(whereSql);

            return ExecuteNonQuery(sbTotalSQL.ToString(), paras);
        }

        /// <summary>
        /// 按实体的主键来删除实体
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="entityObject">实体对象</param>
        /// <returns>删除成功则返回true</returns>
        public bool DeleteByPrimaryKey(Type type, object entityObject)
        {
            string primaryKeyName = EntityConvertor.GetPrimaryKeyName(type);
            string whereSQL = primaryKeyName + "=@PrimaryKey__0";

            int effectRow = Delete(type, whereSQL, 
                new List<object>() { EntityConvertor.GetPrimaryKey(type, entityObject) });
            
            if (effectRow > 0)
            {
                return true;
            }

            return false;
        }

        private MySqlConnection ConnectingMySqlDB()
        {
            MySqlConnection mySqlConn = new MySqlConnection();
            mySqlConn.ConnectionString = ConfigurationHelper.Instance.DBConnectingString;
            try
            {
                mySqlConn.Open();
            }
            catch
            {
                return null;
            }
            return mySqlConn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParadiseHome.DAL.Interface;
using System.Data;
using MySql.Data.MySqlClient;
using ParadiseHome.Common.Utils;

namespace ParadiseHome.DAL.MySQL
{
    public class SQLExecutor : ISQLExecutor
    {
        /// <summary>
        /// 执行传入的sql字符串查询语句
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <returns>查询的结果集</returns>
        public DataTable Execute(String sql)
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

                    DataSet dataSet = new DataSet();

                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                    mySqlAdapter.SelectCommand = cmd;
                    mySqlAdapter.Fill(dataSet);

                    mySqlConn.Clone();

                    if (dataSet.Tables.Count != 0)
                    {
                        return dataSet.Tables[0];
                    }
                }
                catch
                {
                    mySqlConn.Clone();
                    return null;
                }
            }
            return null;
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

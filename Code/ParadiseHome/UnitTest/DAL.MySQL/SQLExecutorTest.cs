using ParadiseHome.DAL.MySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using ParadiseHome.Common.Model.Basic;
using System.Collections.Generic;

namespace UnitTest
{
    
    
    /// <summary>
    ///这是 SQLExecutorTest 的测试类，旨在
    ///包含所有 SQLExecutorTest 单元测试
    ///</summary>
    [TestClass()]
    public class SQLExecutorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Execute 的测试
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            SQLExecutor target = new SQLExecutor(); // TODO: 初始化为适当的值
            string sql = string.Empty; // TODO: 初始化为适当的值
            DataTable expected = null; // TODO: 初始化为适当的值
            DataTable actual;

            sql = "select * from am_user";

            actual = target.Execute(sql);

            //sql = @"insert into bm_locationtype values(0,@LocationDepth,@TypeName,@Comment,@locationtypecol)";
            ////sql = @"delete from bm_locationtype;";
            //Locationtype lt = new Locationtype
            //{
            //    LocationDepth=0,
            //    TypeName = "level0",
            //    Comment = "test",
            //    locationtypecol = "test"
            //};
            //int effectrow = target.ExecuteNonQuery(sql, new List<object> { lt.LocationDepth, lt.TypeName, lt.Comment, lt.locationtypecol });
            ////int effectrow = target.ExecuteNonQuery(sql);

            Assert.AreEqual("", "");
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

                /// <summary>
        ///Execute 的测试
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            
            List<object> lts = new List<object>();
            for (int i = 0; i < 5; i++ )
            {
                Locationtype lt = new Locationtype
                {
                    Comment = "test",
                    locationtypecol = "test"
                };
                lt.LocationDepth = i;
                lt.TypeName = "level" + i.ToString();
                lts.Add(lt);
            }

            SQLExecutor target = new SQLExecutor(); // TODO: 初始化为适当的值
            target.Insert(typeof(Locationtype), lts);

            Assert.AreEqual("", "");
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}

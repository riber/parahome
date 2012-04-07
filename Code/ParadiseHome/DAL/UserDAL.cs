using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using NHibernate.Expression;
namespace DAL
{
    public class UserDAL
    {
        private int m_UserCount=0;
        public int UserCount
        {
            get
            {
                return UserCount;
            }
        }
        public static int VerifyEmpoyee(String UserID,String UserPassword)
        {
            int i = 0;
            //DetachedCriteria query = DetachedCriteria.For<Post>(); 
            //query.CreateCriteria("Post").Add(Expression.In("TagName", 
            //    string.Join(",",tags.ToArray()) ); 

            //DetachedCriteria cri = DetachedCriteria.For(typeof(String), "User")
            //.CreateAlias("id", "id")
            //.Add(Expression.Eq("id", UserID));

            
            return 1;
        }
    }
}

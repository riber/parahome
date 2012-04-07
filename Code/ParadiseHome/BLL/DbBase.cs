using System;
using System.Collections.Generic;
using System.Text;

using Castle.ActiveRecord;

namespace BLL
{
    /// <summary>
    /// 数据操作基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ActiveRecord]
    public abstract class DbBase<T> : ActiveRecordBase<T>
    {
    }
}

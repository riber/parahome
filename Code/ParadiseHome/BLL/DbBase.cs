using System;
using System.Collections.Generic;
using System.Text;

using Castle.ActiveRecord;

namespace BLL
{
    /// <summary>
    /// ���ݲ�������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ActiveRecord]
    public abstract class DbBase<T> : ActiveRecordBase<T>
    {
    }
}

namespace ParadiseHome.Common.Utils
{
    /// <summary>
    /// 福位状态枚举
    /// </summary>
    public enum CellState
    {
        /// <summary>
        /// 默认状态（空位置）
        /// </summary>
        Default,
        /// <summary>
        /// 已被预订的状态
        /// </summary>
        Booked,
        /// <summary>
        /// 已售（已捐）状态
        /// </summary>
        Sold
    }
}
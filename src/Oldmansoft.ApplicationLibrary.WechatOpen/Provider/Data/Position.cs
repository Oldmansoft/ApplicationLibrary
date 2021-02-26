namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider.Data
{
    /// <summary>
    /// 位置
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public double Precision { get; set; }
    }
}

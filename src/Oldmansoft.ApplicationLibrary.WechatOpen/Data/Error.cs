namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// 异常结果
    /// </summary>
    class Error
    {
        /// <summary>
        /// 全局返回码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string errmsg { get; set; }
    }
}

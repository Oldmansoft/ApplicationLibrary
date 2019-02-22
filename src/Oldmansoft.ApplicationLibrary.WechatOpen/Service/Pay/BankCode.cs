using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 银行编号
    /// </summary>
    public class BankCode : Dictionary<string, string>
    {
        /// <summary>
        /// 实例
        /// </summary>
        public readonly static BankCode Instance = new BankCode();

        /// <summary>
        /// 创建
        /// </summary>
        private BankCode()
        {
            Add("1002", "工商银行");
            Add("1005", "农业银行");
            Add("1026", "中国银行");
            Add("1003", "建设银行");
            Add("1001", "招商银行");
            Add("1066", "邮储银行");
            Add("1020", "交通银行");
            Add("1004", "浦发银行");
            Add("1006", "民生银行");
            Add("1009", "兴业银行");
            Add("1010", "平安银行");
            Add("1021", "中信银行");
            Add("1025", "华夏银行");
            Add("1027", "广发银行");
            Add("1022", "光大银行");
            Add("1032", "北京银行");
            Add("1056", "宁波银行");
        }
    }
}

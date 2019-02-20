using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
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
            Add("工商银行", "1002");
            Add("农业银行", "1005");
            Add("中国银行", "1026");
            Add("建设银行", "1003");
            Add("招商银行", "1001");
            Add("邮储银行", "1066");
            Add("交通银行", "1020");
            Add("浦发银行", "1004");
            Add("民生银行", "1006");
            Add("兴业银行", "1009");
            Add("平安银行", "1010");
            Add("中信银行", "1021");
            Add("华夏银行", "1025");
            Add("广发银行", "1027");
            Add("光大银行", "1022");
            Add("北京银行", "1032");
            Add("宁波银行", "1056");
        }
    }
}

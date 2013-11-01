// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseBase.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   请求基类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 请求基类 
    /// </summary>
    public class ResponseBase : IResponseMessage
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string ResultDesc { get; set; }

        /// <summary>
        /// 随机字符串(在响应请求时需要带回)
        /// </summary>
        public string echostr { get; set; }
    }
}

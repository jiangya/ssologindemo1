// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponseMessage.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   返回结果消息接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 返回结果消息接口
    /// </summary>
    public interface IResponseMessage
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        int ResultCode { get; set; }

        /// <summary>
        /// 返回结果描述
        /// </summary>
        string ResultDesc { get; set; }

        /// <summary>
        /// 随机字符串(在响应请求时需要带回)
        /// </summary>
        string echostr { get; set; }
    }
}

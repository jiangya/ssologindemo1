// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestMessage.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   请求消息实体类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NvWa.PaaS.SSO.Client.PaaS
{
    /// <summary>
    /// 请求消息实体类
    /// </summary>
    public class RequestMessage
    {
        /// <summary>
        /// 加密签名(用于验证请求合法)
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// 应用标识
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 操作码（参见附录三）
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// 随机字符串(在响应请求时需要带回)
        /// </summary>
        public string echostr { get; set; }

        /// <summary>
        /// 消息体(加密后的消息体)
        /// </summary>
        public string content { get; set; }
    }
}

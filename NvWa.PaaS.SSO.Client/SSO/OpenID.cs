// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenID.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   用户的开发者编号
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using NetDimension.Json;

namespace NvWa.PaaS.SSO.Client.SSO
{
    /// <summary>
    /// 用户的开发者编号
    /// </summary>
    public class OpenID
    {
        /// <summary>
        /// client_id
        /// </summary>
        [JsonProperty(PropertyName = "client_id")]
        public string client_id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty(PropertyName = "openid")]
        public string openid { get; set; }
    }
}

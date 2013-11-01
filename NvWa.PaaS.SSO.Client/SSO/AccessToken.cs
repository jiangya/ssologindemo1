// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessToken.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   AccessToken实体类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using NetDimension.Json;

namespace NvWa.PaaS.SSO.Client.SSO
{
    /// <summary>
    /// AccessToken实体类
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Token
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; internal set; }

        /// <summary>
        /// ExpiresIn
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public DateTime ExpiresIn { get; internal set; }
    }
}

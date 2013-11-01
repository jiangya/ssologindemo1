// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberResponse.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   成员请求返回结果
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 成员请求返回结果
    /// </summary>
    public class MemberResponse : ResponseBase
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public Guid CorpID { get; set; }

        /// <summary>
        /// 用户列表
        /// </summary>
        public List<User> Users { get; set; }
    }
}

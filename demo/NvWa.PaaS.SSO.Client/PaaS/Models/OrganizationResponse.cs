// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrganizationResponse.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   部门请求返回结果
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 部门请求返回结果
    /// </summary>
    public class OrganizationResponse : ResponseBase
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public Guid CorpID { get; set; }

        /// <summary>
        /// 部门列表
        /// </summary>
        public List<Organization> Organizations { get; set; }
    }
}

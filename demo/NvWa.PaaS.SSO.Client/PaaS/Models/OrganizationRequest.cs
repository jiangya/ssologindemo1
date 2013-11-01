// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrganizationRequest.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   企业请求实体
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 企业请求实体
    /// </summary>
    public class OrganizationRequest 
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public string corpid { get; set; }

        /// <summary>
        /// 部门ID列表
        /// </summary>
        public string DeptIDs { get; set; }
    }
}

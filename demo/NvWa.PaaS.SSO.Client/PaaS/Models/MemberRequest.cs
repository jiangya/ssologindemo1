// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberRequest.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   成员请求
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 成员请求
    /// </summary>
    public class MemberRequest
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public string corpid { get; set; }

        /// <summary>
        /// 用户编号列表
        /// </summary>
        public string UserIDs { get; set; }
    }
}

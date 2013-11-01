// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   用户信息
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string UserLoginName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 状态0：正常-1：禁用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 所在企业
        /// </summary>
        public Guid Corpid { get; set; }
    }
}
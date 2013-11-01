// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Organization.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   部门信息
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父部门编号
        /// </summary>
        public Guid ParentID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
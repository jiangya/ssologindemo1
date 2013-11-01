// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyResponse.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   企业返回数据实体
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace NvWa.PaaS.SSO.Client.PaaS.Models
{
    /// <summary>
    /// 企业返回数据实体
    /// </summary>
    public class CompanyResponse : ResponseBase
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 企业编号
        /// </summary>
        public Guid CorpID { get; set; }

        /// <summary>
        /// 企业状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 企业地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Manager
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// PermitNumber
        /// </summary>
        public string PermitNumber { get; set; }

        /// <summary>
        /// LinkMan
        /// </summary>
        public string LinkMan { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ComCode
        /// </summary>
        public string ComCode { get; set; }
    }
}

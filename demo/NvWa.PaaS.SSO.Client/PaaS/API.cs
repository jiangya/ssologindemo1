// --------------------------------------------------------------------------------------------------------------------
// <copyright file="API.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   PAAS API接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Security;
using NetDimension.Json;
using NvWa.PaaS.SSO.Client.PaaS.Models;

namespace NvWa.PaaS.SSO.Client.PaaS
{
    /// <summary>
    /// PAAS API接口
    /// </summary>
    public class API
    {
        /// <summary>
        /// PAAS的地址
        /// </summary>
        private const string PAAS_URL = "http://10.10.2.37/message/index";

        #region 属性
        /// <summary>
        /// 获取App Key 
        /// </summary>
        public string AppKey { get; internal set; }

        /// <summary>
        /// 获取App Secret
        /// </summary>
        public string AppSecret { get; internal set; }
        #endregion

        #region 构造

        /// <summary>
        /// Initializes a new instance of the <see cref="API"/> class. 
        /// 实例化API类
        /// </summary>
        /// <param name="appKey">
        /// appKey
        /// </param>
        /// <param name="appSecret">
        /// appSecret
        /// </param>
        public API(string appKey, string appSecret)
        {
            AppKey = appKey;
            AppSecret = appSecret;
        }

        #endregion

        /// <summary>
        /// 获得企业信息接口
        /// </summary>
        /// <param name="corpid">
        /// 企业编号
        /// </param>
        /// <returns>
        /// 企业信息
        /// </returns>
        public CompanyResponse GetCompanyInfo(string corpid)
        {
            var _req = new CompanyRequest { corpid = corpid };
            var _message = getData("301", _req);
            if (!string.IsNullOrEmpty(_message))
            {
                return JsonConvert.DeserializeObject<CompanyResponse>(_message);
            }

            return null;
        }

        /// <summary>
        /// 获得员工信息接口，对于需要企业部门信息的ISV应用，则实现该接口，以接受企业部门信息更新。
        /// </summary>
        /// <param name="corpid">
        /// 企业编号
        /// </param>
        /// <param name="deptIDs">
        /// 部门ID列表
        /// </param>
        /// <returns>
        /// 部门列表
        /// </returns>
        public OrganizationResponse GetOrganizationInfo(string corpid, string[] deptIDs)
        {
            var _req = new OrganizationRequest { corpid = corpid, DeptIDs = string.Join(",", deptIDs) };
            var _message = getData("302", _req);
            if (!string.IsNullOrEmpty(_message))
            {
                return JsonConvert.DeserializeObject<OrganizationResponse>(_message);
            }

            return null;
        }

        /// <summary>
        /// 获得员工信息接口
        /// </summary>
        /// <param name="corpid">
        /// 企业信息
        /// </param>
        /// <param name="userIDs">
        /// 用户编号列表
        /// </param>
        /// <returns>
        /// 用户信息列表
        /// </returns>
        public MemberResponse GetMemberInfo(string corpid, string[] userIDs)
        {
            var _req = new MemberRequest { corpid = corpid, UserIDs = string.Join(",", userIDs) };
            var _message = getData("302", _req);
            if (!string.IsNullOrEmpty(_message))
            {
                return JsonConvert.DeserializeObject<MemberResponse>(_message);
            }

            return null;
        }

        /// <summary>
        /// 获得请求数据
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="content">正文内容</param>
        /// <returns>数据字符串</returns>
        private string getData(string code, object content)
        {
            var _timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var _random = new Random(DateTime.Now.Millisecond);
            var _nonce = _random.Next(0, 999999).ToString();
            var _echostr = Utility.GetRandomString(32, true, true, true, false, null);

            // 序列化数据
            var _jsonstring = JsonConvert.SerializeObject(content);

            // 加密数据
            var _contentstring = DESEncrypt.Encrypt(_jsonstring, AppSecret);

            var _config = new Dictionary<string, string>
                              {
                                  {"signature", GetSignature(AppSecret, _timestamp, _nonce)},
                                  {"appid", AppKey},
                                  {"code", code},
                                  {"timestamp", _timestamp},
                                  {"nonce", _nonce},
                                  {"echostr", _echostr},
                                  {"content", _contentstring},
                              };
            return Utility.PostDataToUrl(Utility.BuildQueryString(_config), PAAS_URL);
        }

        /// <summary>
        /// 获得加密签名
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="timestamp">
        /// The timestamp.
        /// </param>
        /// <param name="nonce">
        /// The nonce.
        /// </param>
        /// <returns>
        /// The get signature.
        /// </returns>
        private string GetSignature(string token, string timestamp, string nonce)
        {
            string[] _arrTmp = { token, timestamp, nonce };

            // 字典排序
            Array.Sort(_arrTmp);
            string _tmpStr = string.Join(string.Empty, _arrTmp);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(_tmpStr, "SHA1");
        }
    }
}

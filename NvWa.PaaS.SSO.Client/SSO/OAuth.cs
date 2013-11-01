// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OAuth.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   单点登录API
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using NetDimension.Json;

namespace NvWa.PaaS.SSO.Client.SSO
{
    /// <summary>
    /// 单点登录API
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// 授权地址
        /// </summary>
        private const string AUTHORIZE_URL = "http://localhost:23270/oauth2/Authorize";

        /// <summary>
        /// ACCESS_TOKEN地址
        /// </summary>
        private const string ACCESS_TOKEN_URL = "http://localhost:23270/oauth2/token";

        /// <summary>
        /// OPENID地址
        /// </summary>
        private const string OPENID_URL = "http://localhost:23270/oauth2/me";

        /// <summary>
        /// UserInfo地址
        /// </summary>
        private const string USER_INFO_URL = "http://localhost:23270/api/user/show";

        /// <summary>
        /// 退出登录地址
        /// </summary>
        private const string LOGOUT_URL = "http://localhost:23270/oauth2/logout";

        #region 属性
        /// <summary>
        /// 获取Access Token
        /// </summary>
        public string AccessToken { get; internal set; }

        /// <summary>
        /// 获取App Key 
        /// </summary>
        public string AppKey { get; internal set; }

        /// <summary>
        /// 获取App Secret
        /// </summary>
        public string AppSecret { get; internal set; }

        /// <summary>
        /// 获取或设置回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Refresh Token 似乎目前没用
        /// </summary>
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// 代理设置
        /// </summary>
        public WebProxy Proxy { get; set; }

        #endregion

        #region 构造

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth"/> class. 
        /// 实例化OAuth类
        /// </summary>
        /// <param name="appKey">
        /// appKey
        /// </param>
        /// <param name="appSecret">
        /// appSecret
        /// </param>
        /// <param name="accessToken">
        /// accessToken
        /// </param>
        /// <param name="refreshToken">
        /// refreshToken
        /// </param>
        public OAuth(string appKey, string appSecret, string accessToken, string refreshToken = null)
        {
            AppKey = appKey;
            AppSecret = appSecret;
            AccessToken = accessToken;
            RefreshToken = refreshToken ?? string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth"/> class. 
        /// 实例化OAuth类（用于授权）
        /// </summary>
        /// <param name="appKey">
        /// appKey
        /// </param>
        /// <param name="appSecret">
        /// appSecret
        /// </param>
        /// <param name="callbackUrl">
        /// callbackUrl
        /// </param>
        public OAuth(string appKey, string appSecret, string callbackUrl = null)
        {
            AppKey = appKey;
            AppSecret = appSecret;
            AccessToken = string.Empty;
            CallbackUrl = callbackUrl;
        }
        #endregion

        #region 方法

        /// <summary>
        /// OAuth2的authorize接口
        /// </summary>
        /// <param name="state">用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。 </param>
        /// <returns>授权地址</returns>
        public string GetAuthorizeURL(string state = null)
        {
            Dictionary<string, string> _config = new Dictionary<string, string>
                                                     {
                                                         {"client_id", AppKey},
                                                         {"redirect_uri", CallbackUrl},
                                                         {"response_type", "code"},
                                                         {"state", state ?? string.Empty},
                                                     };
            UriBuilder _builder = new UriBuilder(AUTHORIZE_URL);
            _builder.Query = Utility.BuildQueryString(_config);

            return _builder.ToString();
        }

        /// <summary>
        /// OAuth2的AccessToken接口
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="state">state</param>
        /// <returns>AccessToken地址</returns>
        public string GetAccessTokenURL(string code, string state = null)
        {
            Dictionary<string, string> _config = new Dictionary<string, string>
                                                     {
                                                         {"grant_type", "authorization_code"},
                                                         {"client_id", AppKey},
                                                         {"client_secret", AppSecret},
                                                         {"code", code},
                                                         {"redirect_uri", CallbackUrl},
                                                         {"state", state ?? string.Empty},
                                                     };
            UriBuilder _builder = new UriBuilder(ACCESS_TOKEN_URL);
            _builder.Query = Utility.BuildQueryString(_config);

            return _builder.ToString();
        }

        /// <summary>
        /// OAuth2的AccessToken接口
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="state">state</param>
        /// <returns>获得AccessToken</returns>
        public AccessToken GetAccessToken(string code, string state = null)
        {
            var _response = Utility.GetHttpRequest(GetAccessTokenURL(code, state));
            if (!string.IsNullOrEmpty(_response))
            {
                AccessToken _token = JsonConvert.DeserializeObject<AccessToken>(_response);
                AccessToken = _token.Token;
                return _token;
            }

            return null;
        }

        /// <summary>
        /// 获得OpenID
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="state">state</param>
        /// <returns>OpenID地址</returns>
        public string GetOpenIDURL(string access_token, string state = null)
        {
            Dictionary<string, string> _config = new Dictionary<string, string>
                                                     {
                                                         {"access_token", access_token},
                                                         {"state", state ?? string.Empty},
                                                     };
            UriBuilder _builder = new UriBuilder(OPENID_URL);
            _builder.Query = Utility.BuildQueryString(_config);

            return _builder.ToString();
        }

        /// <summary>
        /// 获得OPENid
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="state">state</param>
        /// <returns>OpenID</returns>
        public OpenID GetOpenID(string access_token, string state = null)
        {
            var _response = Utility.GetHttpRequest(GetOpenIDURL(access_token, state));

            if (!string.IsNullOrEmpty(_response))
            {
                OpenID _openid = JsonConvert.DeserializeObject<OpenID>(_response);
                return _openid;
            }

            return null;
        }

        /// <summary>
        /// 获得获取用户信息URL地址
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="openid">openid</param>
        /// <param name="state">state</param>
        /// <returns>用户信息</returns>
        public string GetUserInfoURL(string access_token, string openid, string state = null)
        {
            Dictionary<string, string> _config = new Dictionary<string, string>
                                                     {
                                                         {"access_token", access_token},
                                                         {"openid", openid},
                                                         {"state", state ?? string.Empty},
                                                     };
            UriBuilder _builder = new UriBuilder(USER_INFO_URL);
            _builder.Query = Utility.BuildQueryString(_config);
            return _builder.ToString();
        }

        /// <summary>
        /// 获得登录用户信息
        /// </summary>
        /// <param name="access_token">
        /// The access_token.
        /// </param>
        /// <param name="openid">
        /// The openid.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The get user info.
        /// </returns>
        public PaaS.Models.User GetUserInfo(string access_token, string openid, string state = null)
        {
            var _response = Utility.GetHttpRequest(GetUserInfoURL(access_token, openid, state));
            if (!string.IsNullOrEmpty(_response))
            {
                return JsonConvert.DeserializeObject<PaaS.Models.User>(_response);
            }

            return null;
        }

        /// <summary>
        /// 退出登录地址
        /// </summary>
        /// <param name="redirect_uri">
        /// The redirect_uri.
        /// </param>
        /// <returns>
        /// The get log out url.
        /// </returns>
        public string GetLogOutURL(string redirect_uri)
        {
            Dictionary<string, string> _config = new Dictionary<string, string>
                                                     {
                                                         {"redirect_uri", redirect_uri},
                                                     };
            UriBuilder _builder = new UriBuilder(LOGOUT_URL);
            _builder.Query = Utility.BuildQueryString(_config);
            return _builder.ToString();
        }

        #endregion
    }
}

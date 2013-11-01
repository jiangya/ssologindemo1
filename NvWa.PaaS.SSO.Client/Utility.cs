// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="德清女娲网络科技有限公司">
//   Copyright (c) 德清女娲网络科技有限公司 版权所有
// </copyright>
// <summary>
//   工具类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace NvWa.PaaS.SSO.Client
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// 默认用户头
        /// </summary>
        private const string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        /// <summary>
        /// 默认数据类型
        /// </summary>
        private const string DefaultContentType = "application/x-www-form-urlencoded";

        /// <summary>
        /// 创建查询字符串
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <returns>查询字符串</returns>
        internal static string BuildQueryString(Dictionary<string, string> parameters)
        {
            var _pairs = new List<string>();
            foreach (KeyValuePair<string, string> _item in parameters)
            {
                if (string.IsNullOrEmpty(_item.Value))
                {
                    continue;
                }

                _pairs.Add(string.Format("{0}={1}", Uri.EscapeDataString(_item.Key), Uri.EscapeDataString(_item.Value)));
            }

            return string.Join("&", _pairs.ToArray());
        }

        /// <summary>
        /// 执行HTTP请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns>请求结果</returns>
        internal static string GetHttpRequest(string url)
        {
            var _request = WebRequest.Create(url) as HttpWebRequest;
            if (_request != null)
            {
                _request.Method = "GET";
                _request.UserAgent = DefaultUserAgent;
                var _data = _request.GetResponse() as HttpWebResponse;
                if (_data != null)
                {
                    var _reader = new StreamReader(_data.GetResponseStream());
                    string _responseFromServer = _reader.ReadToEnd();
                    return _responseFromServer;
                }
            }

            return null;
        }

        /// <summary>
        /// Post data到url
        /// </summary>
        /// <param name="data">要post的数据</param>
        /// <param name="url">目标url</param>
        /// <returns>服务器响应</returns>
        internal static string PostDataToUrl(string data, string url)
        {
            Encoding _encoding = Encoding.UTF8;
            byte[] _bytesToPost = _encoding.GetBytes(data);
            return PostDataToUrl(_bytesToPost, url);
        }

        /// <summary>
        /// Post data到url
        /// </summary>
        /// <param name="data">要post的数据</param>
        /// <param name="url">目标url</param>
        /// <returns>服务器响应</returns>
        internal static string PostDataToUrl(byte[] data, string url)
        {
            #region 创建httpWebRequest对象

            WebRequest _webRequest = WebRequest.Create(url);
            var _httpRequest = _webRequest as HttpWebRequest;
            if (_httpRequest == null)
            {
                throw new ApplicationException(string.Format("Invalid url string: {0}", url));
            }
            #endregion

            #region 填充httpWebRequest的基本信息
            _httpRequest.UserAgent = DefaultUserAgent;
            _httpRequest.ContentType = DefaultContentType;
            _httpRequest.Method = "POST";
            #endregion

            #region 填充要post的内容
            _httpRequest.ContentLength = data.Length;
            Stream _requestStream = _httpRequest.GetRequestStream();
            _requestStream.Write(data, 0, data.Length);
            _requestStream.Close();
            #endregion

            #region 发送post请求到服务器并读取服务器返回信息
            Stream _responseStream;
            try
            {
                _responseStream = _httpRequest.GetResponse().GetResponseStream();
            }
            catch (Exception _e)
            {
                // log error
                Console.WriteLine(string.Format("POST操作发生异常：{0}", _e.Message));
                throw;
            }
            #endregion

            #region 读取服务器返回信息
            if (_responseStream != null)
            {
                string _stringResponse;
                using (var _responseReader = new StreamReader(_responseStream))
                {
                    _stringResponse = _responseReader.ReadToEnd();
                }

                _responseStream.Close();
                return _stringResponse;
            }

            return null;

            #endregion
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">目标字符串的长度</param>
        /// <param name="useNum">是否包含数字，1=包含，默认为包含</param>
        /// <param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        /// <param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        /// <param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        /// <param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        /// <returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] _b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(_b);
            Random _r = new Random(BitConverter.ToInt32(_b, 0));
            string _s = null, _str = custom;

            if (useNum) { _str += "0123456789"; }
            if (useLow) { _str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp) { _str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe) { _str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }

            for (int _i = 0; _i < length; _i++) { _s += _str.Substring(_r.Next(0, _str.Length - 1), 1); }

            return _s;
        }
    }

    /// <summary>
    /// 请求类型
    /// </summary>
    internal enum RequestMethod
    {
        /// <summary>
        /// Get
        /// </summary>
        Get,

        /// <summary>
        /// Post
        /// </summary>
        Post
    }
}

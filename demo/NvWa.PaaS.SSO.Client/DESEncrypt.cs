// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DESEncrypt.cs" company="����Ů�����Ƽ����޹�˾">
//   Copyright (c) ����Ů�����Ƽ����޹�˾ ��Ȩ����
// </copyright>
// <summary>
//   DES����/�����ࡣ
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace NvWa.PaaS.SSO.Client
{
    /// <summary>
    /// DES����/�����ࡣ
    /// </summary>
    public class DESEncrypt
    {
        #region ========����========

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="text">�ı�</param>
        /// <returns>���ܺ��ı�</returns>
        public static string Encrypt(string text)
        {
            return Encrypt(text, "MM");
        }

        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="text">�ı�</param> 
        /// <param name="sKey">Key</param> 
        /// <returns>���ܺ��ı�</returns> 
        public static string Encrypt(string text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }

            return ret.ToString();
        }

        #endregion

        #region ========����========
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="text">�ı�</param>
        /// <returns>���ܺ��ı�</returns>
        public static string Decrypt(string text)
        {
            return Decrypt(text, "MM");
        }

        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="text">�ı�</param> 
        /// <param name="sKey">Key</param> 
        /// <returns>���ܺ��ı�</returns> 
        public static string Decrypt(string text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
    }
}
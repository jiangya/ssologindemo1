using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NvWa.PaaS.SSO.Client.SSO;

namespace WebApplication1.Account
{
    public partial class LoginToSSO : System.Web.UI.Page
    {
        private string AppKey = "CTHocWlRMbojGIWTOy";
        private string AppSecret = "sewsWXTxmrmqEgVtRCnmCggMWvZE3xvN";
        private string AppCallbackUrl = "http://localhost:5287/Account/SSOCallback.aspx";
        private string state = Guid.NewGuid().ToString("N");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            OAuth oauth = new OAuth(AppKey, AppSecret, AppCallbackUrl);

            var authenticationUrl = oauth.GetAuthorizeURL(state);
            Session["requeststate"] = state;

            Response.Redirect(authenticationUrl);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wap_TheThaoSo.Library
{
    public class HitCounterHttpModule : IHttpModule
    {
        private HttpApplication _application;
        public void Init(HttpApplication app)
        {
            this._application = app;
            this._application.BeginRequest += new EventHandler(_application_BeginRequest);
        }
        public void _application_BeginRequest(object sender, EventArgs e)
        {

            //using isapi

            string strPath = HttpContext.Current.Request.Url.AbsolutePath;
            UrlRedirection oPR = new UrlRedirection();

            string strURL = "";

            string strRewrite = oPR.GetMatchingRewrite(strPath);

            if (!String.IsNullOrEmpty(strRewrite))
            {
                strURL = strRewrite;
            }
            else
            {
                strURL = strPath;
            }
            HttpContext.Current.RewritePath("~" + strURL);
        }

        public void Dispose()
        {

        }
    }
}
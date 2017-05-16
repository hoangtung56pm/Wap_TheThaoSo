using log4net;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.VnmCharging;

namespace Wap_TheThaoSo.Wap
{
    public partial class Landing94x : BasePage
    {
        int id = 0;
        readonly SqlProvider _sql = new SqlProvider();
        //string imgLink = "/assets/Images/Landing/anh6.jpg";
        //string registerLink = "http://visport.vn/wap/DangKy.aspx";
        //string RedirectLink = "http://wap.vietnamobile.com.vn";
        //string msisdn;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {                
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                if (string.IsNullOrEmpty(Request.QueryString["key"]))
                {

                    Response.Redirect("http://vmgame.vn/content.aspx?backurl=" + url);
                }

                if (Request.QueryString["msisdn"] == "")
                {
                    Session["msisdn"] = null;
                    Response.Redirect("http://wap.vietnamobile.com.vn");
                }
                else
                {
                    Session["msisdn"] = Request.QueryString["msisdn"];
                }
                Get_User_Agent_Info(url, Session["msisdn"].ToString());
                DataTable dt = _sql.S294x_Getinfo(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string service_name = dt.Rows[0]["Product_Name"].ToString();
                    string price = dt.Rows[0]["Charging_Price"].ToString();
                    string Periodlength = dt.Rows[0]["PeriodLength"].ToString();
                    lblAlert.Text = " Quý khách vui lòng xác nhận đồng ý đăng ký và gia hạn dịch vụ " + service_name + " với giá cước dịch vụ là " + price + "/" + Periodlength + " ngày.Trân trọng cảm ơn";
                }
            }
            
        }
        protected void btnAgree_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://vnm.ising.vn/sub/DK.aspx?id="+id);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://wap.vietnamobile.com.vn");
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
        }
        protected User_AgentInfo Get_User_Agent_Info(string link,string msisdn)
        {
            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
            o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            User_AgentInfo _info = new User_AgentInfo();
            _info.device_os = o_capabilityGetter.getCapability("device_os");
            _info.mobile_browser = o_capabilityGetter.getCapability("mobile_browser");
            _info.resolution_width = o_capabilityGetter.getCapability("resolution_width");
            _info.resolution_height = o_capabilityGetter.getCapability("resolution_height");
            _info.model_name = o_capabilityGetter.getCapability("model_name");
            _info.brand_name = o_capabilityGetter.getCapability("brand_name");

            int IsMobileDevice = 0;
            if (HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                IsMobileDevice = 1;
            }

            string ip = GetClientIPAddress();
            var _urlRefer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            string telco = "other";
            int isWifi = 1;
            if (CheckIsWifi.IsVinaphone(ip))
            {
                telco = "gpc";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsViettel(ip))
            {
                telco = "viettel";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsMobi(ip))
            {
                telco = "vms";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsVnm(ip) || !string.IsNullOrEmpty(msisdn))
            {
                telco = "vnm";
                isWifi = 0;
            }

            _sql.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, telco, isWifi, IsMobileDevice, _urlRefer, link, ip, 4);
            return _info;
        }
        public static string GetClientIPAddress()
        {
            try
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                    else
                    {
                        return HttpContext.Current.Request.UserHostAddress;
                    }
                }

                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }

        }
    }
}
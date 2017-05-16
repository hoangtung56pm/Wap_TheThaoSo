using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.UrlProcess;

namespace Wap_TheThaoSo.Wap
{
    public partial class Register_Euro : BasePage
    {
        readonly SqlProvider _sql = new SqlProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["msisdn"] = "841882406279";
             if (!Page.IsPostBack)
            {
                #region Dem Luot click
                User_AgentInfo _info = new User_AgentInfo();
                string link = "http://visport.vn/Wap/Register_Euro.aspx";
                _info = Get_User_Agent_Info(link);
                #endregion
             
            }
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    Transaction.DangKyEuro(Session["msisdn"].ToString());
                }
            }

            Response.Redirect("/Video/Default.aspx?lang=0&display=video&w=320");
        }
        protected User_AgentInfo Get_User_Agent_Info(string link)
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

            string ip = ClientIp;
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
            else if (CheckIsWifi.IsVnm(ip))
            {
                telco = "vnm";
                isWifi = 0;
            }

            _sql.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, telco, isWifi, IsMobileDevice, _urlRefer, link, ip, 3);
            return _info;
        }
        private static string ClientIp
        {
            get
            {
                var _ip = HttpContext.Current.Request.UserHostAddress;
                return _ip;
            }
        }
    }
}
using System;
using System.Web;
using System.Web.Mobile;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo
{
    public partial class Default : System.Web.UI.MobileControls.MobilePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_AgentInfo info = Get_User_Agent_Info();
            int width = ConvertUtility.ToInt32(info.resolution_width);
            if (ConvertUtility.ToInt32(width) == 0 || ConvertUtility.ToInt32(width) >= 480)
            {
                width = (int)Constant.DefaultScreen.Standard;
            }


            //use test only
            //if (AppEnv.GetSetting("TestFlag") == "1")
            //{
            //    Session["msisdn"] = "8492555555";
            //    Session["telco"] = Constant.T_Vietnamobile;
            //}
            //else
            //{
            //    if (Session["msisdn"] == null)
            //    {
            //        Response.Redirect("http://wap.vietnamobile.com.vn/pm/getmsisdnvsport.aspx");
            //    }
            //}

            AppEnv.GetMsisdn();
            //if (Session["msisdn"] == null)
            //{
            //    int is3g = 0;
            //    string msisdn = MobileUtils.GetMSISDN(out is3g);
            //    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            //    {
            //        Session["telco"] = Constant.T_Vietnamobile;
            //        Session["msisdn"] = msisdn;
            //    }
            //    else
            //    {
            //        Session["msisdn"] = "Unknown";
            //        Session["telco"] = Constant.T_Undefined;
            //    }
            //}

            string wapDefault = AppEnv.GetSetting("WapDefault");
           
            string url;
          
            if (ConvertUtility.ToInt32(AppEnv.GetSetting("CheckLowLife")) == 1)
            {
                if (width >= (int)Constant.DefaultScreen.Standard)
                {
                    url = wapDefault + UrlProcess.GetHomeUrl("1", width.ToString());
                    //url = "/Wap/GameShow.aspx";
                }
                else
                {
                    width = 240;
                    url = wapDefault + UrlProcess.GetHomeLowUrl("1", width.ToString());
                }
            }
            else
            {
                url = wapDefault + UrlProcess.GetHomeUrl("1", width.ToString());
            }

            var currentCapabilities = (MobileCapabilities)Request.Browser;
            String prefMime = currentCapabilities.PreferredRenderingMime;

            string accept = Request.ServerVariables["HTTP_ACCEPT"];
            string mime = "";

            if (prefMime == "text/html")
            {
                mime = "text/html";
            }
            else if (prefMime == "text/vnd.wap.wml")
            {
                mime = "text/vnd.wap.wml";
            }

            if (accept.Contains("application/vnd.wap.xhtml+xml"))
            {
                mime = "text/html";
            }

            if (mime == "text/html")
            {
                Response.Redirect(url);
            }
            else if (mime == "text/vnd.wap.wml")
            {
                string other = AppEnv.GetSetting("WapDefault") + UrlProcess.GetOtherHomeUrl();

                Response.Redirect(other);
            }
        }

        protected User_AgentInfo Get_User_Agent_Info()
        {

            if (Application["wurflFileProcessor"] == null)
            {
                string sPath = HttpContext.Current.Request.MapPath("\\WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(sPath);
            }
            var oDeviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            var oCapabilityGetter = new wurflApi.capabilitiesGetter(ref oDeviceFileProcessor);
            oCapabilityGetter.prepareNavigatorModelCapabilities(Request);

            //var info = new User_AgentInfo
            //{
            //    device_os = oCapabilityGetter.getCapability("device_os"),
            //    mobile_browser = oCapabilityGetter.getCapability("mobile_browser"),
            //    resolution_width = oCapabilityGetter.getCapability("resolution_width"),
            //    resolution_height = oCapabilityGetter.getCapability("resolution_height"),
            //    model_name = oCapabilityGetter.getCapability("model_name"),
            //    brand_name = oCapabilityGetter.getCapability("brand_name")
            //};

            var info = new User_AgentInfo();
            //{
            info.device_os = oCapabilityGetter.getCapability("device_os");
            info.mobile_browser = oCapabilityGetter.getCapability("mobile_browser");
            info.resolution_width = oCapabilityGetter.getCapability("resolution_width");
            info.resolution_height = oCapabilityGetter.getCapability("resolution_height");
            info.model_name = oCapabilityGetter.getCapability("model_name");
            info.brand_name = oCapabilityGetter.getCapability("brand_name");
            //};

            BasePage.AddDevice(HttpContext.Current.Request.UserAgent, info.model_name, info.brand_name, info.device_os, info.mobile_browser, info.resolution_width, info.resolution_height);

            return info;
        }
    }
}

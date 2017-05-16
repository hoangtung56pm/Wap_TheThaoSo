using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap
{
    public partial class tinthethao : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msisdn"] == null)
            {
                AppEnv.GetMsisdnWithParam("2");
            }

            User_AgentInfo info = GetUserAgentInfo();
            int width = ConvertUtility.ToInt32(info.resolution_width);
            if (ConvertUtility.ToInt32(width) == 0 || ConvertUtility.ToInt32(width) >= 480)
            {
                width = (int)Constant.DefaultScreen.Standard;
            }


            string url;
            if (Session["msisdn"].ToString() == "Khách")
            {
                if (width >= (int)Constant.DefaultScreen.Standard)
                    url = UrlProcess.GetSmsUrl("1", width.ToString());
                else
                    url = UrlProcess.GetSmsUrlLow("1", width.ToString());

                Response.Redirect(url);
            }
            else
            {
                Transaction.ViClipSubscriptionInsert(Session["msisdn"].ToString(), 1, "Addition", DateTime.Now, DateTime.Now.AddDays(7), "viSport");
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), AppEnv.GetSetting("Sub_Price"), "", "", AppEnv.GetSetting("Sub_Desc"), 5);

                if (width >= (int)Constant.DefaultScreen.Standard)
                    url = "http://visport.vn/DuLieu/Default.aspx?lang=0&display=livescore&w=320";
                else
                    url = "http://visport.vn/DuLieu/DefaultLow.aspx?lang=0&display=livescore&w=240";

                Response.Redirect(url);
            }
        }

        protected User_AgentInfo GetUserAgentInfo()
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

            var info = new User_AgentInfo();

            info.device_os = oCapabilityGetter.getCapability("device_os");
            info.mobile_browser = oCapabilityGetter.getCapability("mobile_browser");
            info.resolution_width = oCapabilityGetter.getCapability("resolution_width");
            info.resolution_height = oCapabilityGetter.getCapability("resolution_height");
            info.model_name = oCapabilityGetter.getCapability("model_name");
            info.brand_name = oCapabilityGetter.getCapability("brand_name");


            //BasePage.AddDevice(HttpContext.Current.Request.UserAgent, info.model_name, info.brand_name, info.device_os, info.mobile_browser, info.resolution_width, info.resolution_height);

            return info;
        }

    }
}
using System;
using System.Web;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.SQLHelper;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo
{
    public class BasePage : System.Web.UI.Page
    {
        public int Lang
        {
            get
            {
                return ConvertUtility.ToInt32(Request.QueryString["lang"]);
            }
        }
        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public string UrlData
        {
            get
            {
                return AppEnv.GetSetting("urldata");
            }
        }

        public string Display
        {
            get
            {
                if (ConvertUtility.ToString(Request.QueryString["display"]) == "")
                {
                    return "home";
                }
                return ConvertUtility.ToString(Request.QueryString["display"]).ToLower();
            }
        }

        public int CatID
        {
            get
            {
                return ConvertUtility.ToInt32(Request.QueryString["catid"]);
            }
        }

        public int CategoryType
        {
            get
            {
                return ConvertUtility.ToInt32(Request.QueryString["cattype"]);
            }
        }

        public int ID
        {
            get
            {
                return ConvertUtility.ToInt32(Request.QueryString["id"]);
            }
        }

        public User_AgentInfo UserAgentInfo
        {
            get
            {
                if (Context.Session["WAP_PLUS_MEMBER_INFO"] != null)
                {
                    return (User_AgentInfo)Context.Session["WAP_PLUS_MEMBER_INFO"];
                }
                return null;
            }
            set
            {
                Context.Session.Remove("WAP_PLUS_MEMBER_INFO");
                Context.Session["WAP_PLUS_MEMBER_INFO"] = value;
            }
        }

        log4net.ILog log = log4net.LogManager.GetLogger("File");

        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current.Request.UserAgent != null)
            {
                if (HttpContext.Current.Request.UserAgent.ToLower().Contains("midp") &&
                    !MobileUtils.IsBlackBerry(HttpContext.Current.Request.UserAgent.ToLower()))
                {
                    Response.Charset = "UTF-8";

                    string acceptHeader = Request.ServerVariables["HTTP_ACCEPT"];

                    if (acceptHeader.IndexOf("application/vnd.wap.xhtml+xml") != -1)
                    {
                        Response.ContentType = "application/vnd.wap.xhtml+xml";
                    }
                    else if (acceptHeader.IndexOf("application/xhtml+xml") != -1)
                    {
                        Response.ContentType = "application/xhtml+xml";
                    }
                    else
                    {
                        Response.ContentType = "text/html";
                    }
                }
            }

            if (UserAgentInfo == null)
            {
                UserAgentInfo = ConvertUtility.ToInt32(AppEnv.GetSetting("UseManualUserAgent")) == 1
                                    ? Get_User_Agent_Info(AppEnv.GetSetting("ManualUserAgent"))
                                    : Get_User_Agent_Info(HttpContext.Current.Request.Headers["User-Agent"]);
            }
            if (ConvertUtility.ToInt32(Request.QueryString["w"]) == 0)
            {
                int width = ConvertUtility.ToInt32(UserAgentInfo.resolution_width);
                if (width == 0 || width >= 480)
                {
                    _width = (int)Constant.DefaultScreen.Standard;
                }
            }
            else
            {
                _width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            }

            try
            {
                if (UserAgentInfo.brand_name != "" && UserAgentInfo.model_name != "")
                {
                    string page = Request.RawUrl.Replace(Request.Url.Host, "");
                    if (page.IndexOf("Default.aspx") > 0)
                    {
                        page = page.Substring(0, page.IndexOf("Default.aspx")).Replace("/", "");
                    }
                    //_commonController.LogUserAgentInfo(UserAgentInfo, page, Request.RawUrl, CategoryType);
                }
                else
                {
                    User_AgentInfo userAgent = UserAgentInfo;
                    userAgent.model_name = "unknown";
                    userAgent.device_os = HttpContext.Current.Request.UserAgent;
                    string page = Request.RawUrl.Replace(Request.Url.Host, "");
                    if (page.IndexOf("Default.aspx") > 0)
                    {
                        page = page.Substring(0, page.IndexOf("Default.aspx")).Replace("/", "");
                    }
                    //_commonController.LogUserAgentInfo(userAgent, page, Request.RawUrl, CategoryType);
                }
            }
            catch (Exception)
            {
                if (UserAgentInfo.brand_name != "" && UserAgentInfo.model_name != "")
                {
                    string page = Request.RawUrl;
                    //_commonController.LogUserAgentInfo(UserAgentInfo, page, Request.RawUrl, CategoryType);
                }
                else
                {
                    User_AgentInfo userAgent = UserAgentInfo;
                    userAgent.model_name = "unknown";
                    userAgent.device_os = HttpContext.Current.Request.UserAgent;
                    string page = Request.RawUrl;
                    //_commonController.LogUserAgentInfo(userAgent, page, Request.RawUrl, CategoryType);
                }
            }

            log.Debug("-----------------------------------------------");
            log.Debug("UserAgent:" + HttpContext.Current.Request.UserAgent);

        }

        //private readonly CommonController _commonController = CommonController.GetInstance();
        public UserInfo CurrentUser
        {
            get
            {
                if (Context.Session["UserInfo"] != null)
                {
                    return (UserInfo)Context.Session["UserInfo"];
                }
                return null;
            }
            set
            {
                Context.Session.Remove("UserInfo");
                Context.Session["UserInfo"] = value;
            }
        }

        protected User_AgentInfo Get_User_Agent_Info(string userAgent)
        {
            try
            {
                if (Application["wurflFileProcessor"] == null)
                {
                    string sPath = HttpContext.Current.Request.MapPath("..\\WURFL_Data\\wurfl.xml");
                    Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(sPath);
                }

                var oDeviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
                // prepare capability getter
                var oCapabilityGetter = new wurflApi.capabilitiesGetter(ref oDeviceFileProcessor);
                oCapabilityGetter.prepareNavigatorModelCapabilities(userAgent);
                var info = new User_AgentInfo
                {
                    device_os = oCapabilityGetter.getCapability("device_os"),
                    mobile_browser = oCapabilityGetter.getCapability("mobile_browser"),
                    resolution_width = oCapabilityGetter.getCapability("resolution_width"),
                    resolution_height = oCapabilityGetter.getCapability("resolution_height"),
                    model_name = oCapabilityGetter.getCapability("model_name"),
                    brand_name = oCapabilityGetter.getCapability("brand_name")
                };

                //SAMSUNG-GT-S3653W/1.0 SHP/VPP/R5 Jasmine/1.0 Nextreaming SMM-MMS/1.2.0 profile/MIDP-2.1 configuration/CLDC-1.1
                int index = userAgent.IndexOf("/");
                if (index > 0)
                {
                    string name = userAgent.Substring(0, userAgent.IndexOf("/"));
                    if (name.IndexOf("SAMSUNG-") > -1)
                    {
                        info.brand_name = "SAMSUNG";
                        info.model_name = name.Replace("SAMSUNG-", "");
                        return info;
                    }
                }
                return info;
            }
            catch
            {

                if (Application["wurflFileProcessor"] == null)
                {
                    string sPath = HttpContext.Current.Request.MapPath("..\\WURFL_Data\\wurfl.xml");
                    Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(sPath);
                }

                var oDeviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
                // prepare capability getter
                var oCapabilityGetter = new wurflApi.capabilitiesGetter(ref oDeviceFileProcessor);
                oCapabilityGetter.prepareNavigatorModelCapabilities(HttpContext.Current.Request);
                var info = new User_AgentInfo
                {
                    device_os = oCapabilityGetter.getCapability("device_os"),
                    mobile_browser = oCapabilityGetter.getCapability("mobile_browser"),
                    resolution_width = oCapabilityGetter.getCapability("resolution_width"),
                    resolution_height = oCapabilityGetter.getCapability("resolution_height"),
                    model_name = oCapabilityGetter.getCapability("model_name"),
                    brand_name = oCapabilityGetter.getCapability("brand_name")
                };

                //SAMSUNG-GT-S3653W/1.0 SHP/VPP/R5 Jasmine/1.0 Nextreaming SMM-MMS/1.2.0 profile/MIDP-2.1 configuration/CLDC-1.1
                int index = userAgent.IndexOf("/");
                if (index > 0)
                {
                    string name = userAgent.Substring(0, userAgent.IndexOf("/"));
                    if (name.IndexOf("SAMSUNG-") > -1)
                    {
                        info.brand_name = "SAMSUNG";
                        info.model_name = name.Replace("SAMSUNG-", "");
                        return info;
                    }
                }
                return info;

                //User_AgentInfo _info = new User_AgentInfo();
                //_info.device_os = "";
                //_info.mobile_browser = "";
                //_info.resolution_width = "40";
                //_info.resolution_height = "90";
                //_info.model_name = "";
                //_info.brand_name = "unknown";
                //return _info;
            }
        }

        public static void AddDevice(string UserAgent, string ModelName, string BrandName, string DeviceOS, string MobileBrowser, string ResolutionWidth, string ResolutionHeight)
        {
            SqlHelper.ExecuteNonQuery(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_TheThaoSo_CP_Device_Insert", UserAgent, ModelName, BrandName, DeviceOS, MobileBrowser, ResolutionWidth, ResolutionHeight);
        }

        private string GaAccount;
        private const string GaPixel = "ga.aspx";

        public string GoogleAnalyticsGetImageUrl()
        {
            GaAccount = "MO-15103302-16";
            System.Text.StringBuilder url = new System.Text.StringBuilder();
            url.Append(GaPixel + "?");
            url.Append("utmac=").Append(GaAccount);

            Random RandomClass = new Random();
            url.Append("&utmn=").Append(RandomClass.Next(0x7fffffff));

            string referer = "-";
            if (Request.UrlReferrer != null
                 && "" != Request.UrlReferrer.ToString())
            {
                referer = Request.UrlReferrer.ToString();
            }
            url.Append("&utmr=").Append(HttpUtility.UrlEncode(referer));

            if (HttpContext.Current.Request.Url != null)
            {
                url.Append("&utmp=").Append(HttpUtility.UrlEncode(Request.Url.PathAndQuery));
            }

            url.Append("&guid=ON");

            return url.ToString();
        }

    }
}
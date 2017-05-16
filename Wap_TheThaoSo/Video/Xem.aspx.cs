using System;
using System.Data;
using System.Web;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Video
{
    public partial class Xem : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;
        readonly VideoController _videoController = new VideoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            price = AppEnv.GetSetting("videopriceView");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetVideoHomeLowUrl() + "\" >VIDEO</a>";

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (telCo == "Undefined")
                {
                    string url = UrlProcess.GetSmsUrl(lang, width.ToString());
                    Response.Redirect(url);

                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            DataTable dt = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                            if (dt.Rows.Count > 0 && ConvertUtility.ToDateTime(dt.Rows[0]["ExpiredTime"].ToString()) >= DateTime.Now)
                            {
                                price = "0";
                                HienThiNoiDung(true);
                                break;
                            }
                            var charging = new Library.VNMCharging.VNMChargingGW();
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price,"Video Tran Dau : Id =" + Request.QueryString["id"]);
                            ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                            logger.Debug("---" + messageReturn + "---");
                            if (messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true);
                            }
                            else
                            {// Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(false);
                            }
                            break;
                    }
                }
            }
        }

        
        protected void HienThiNoiDung(Boolean thuchien)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = _videoController.GetVideoDetail(id, 1, 5).Tables[0];

            chitietGiaodich = "Video view:" + dtDetail.Rows[0]["Title"] + " | id=" + id;

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                lblTen.Text = dtDetail.Rows[0]["Title"].ToString();
                lnkDownload.Text = Resources.Resource.wBamDeXem;
                //ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " video " + dtDetail.Rows[0]["Title"];

                string path;
                //if (!string.IsNullOrEmpty(dtDetail.Rows[0]["SmartPhonePath"].ToString()))
                path = dtDetail.Rows[0]["SmartPhonePath"].ToString();
                //else
                //    path = dtDetail.Rows[0]["MobilePath"].ToString();

                //string path = dtDetail.Rows[0]["MobilePath"].ToString();
                string wapurl;

                //User_AgentInfo info = Get_User_Agent_Info();

                if(HttpContext.Current.Request.UserAgent != null)
                {
                    if(HttpContext.Current.Request.UserAgent.ToLower().Contains("safari"))
                    {
                        wapurl = lnkDownload.NavigateUrl = AppEnv.GetSetting("vnmviewIphone") + path.Replace("~/", "/");
                    }
                    else
                    {
                        wapurl = lnkDownload.NavigateUrl = AppEnv.GetSetting("vnmview") + path.Replace("~/Upload/Video", "");
                    }
                }
                else
                {
                    wapurl = lnkDownload.NavigateUrl = AppEnv.GetSetting("vnmview") + path.Replace("~/Upload/Video", "");
                }

                //if (info.mobile_browser == "safari" || info.device_os == "iphone os" || info.model_name == "iphone")
                //    wapurl = lnkDownload.NavigateUrl = AppEnv.GetSetting("vnmviewIphone") + path.Replace("~/", "/");
                //else
                //    wapurl = lnkDownload.NavigateUrl = AppEnv.GetSetting("vnmview") + path.Replace("~/Upload/Video", "");
                

                
                lnkDownload.NavigateUrl = wapurl;
                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "video " + "<b>" + dtDetail.Rows[0]["Title"] + "</b>";  

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.Video);

            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.Video, messageReturn);                    
            }

        }

        protected void btnCo_Click(object sender, EventArgs e)
        {

            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //DataTable dt = _videoController.GetVideoDetail(id, 1, 5).Tables[0];


            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string pageDisplayContentUrl = UrlProcess.GetVideoXemUrl(Lang.ToString(), Width.ToString(), dt.Rows[0]["VideoId"].ToString(), CatID.ToString());
            //    string url = UrlProcess.BuildUrlCharging(AppEnv.GetSetting("videoprice"),
            //                                                     dt.Rows[0]["VideoId"].ToString(), "5",
            //                                                     dt.Rows[0]["Title"].ToString(), pageDisplayContentUrl);

            //    Response.Redirect(url);
            //}

        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //string url = UrlProcess.GetVideoDetailUrl(id);
            //Response.Redirect(url);
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

            return info;
        }
    }
}
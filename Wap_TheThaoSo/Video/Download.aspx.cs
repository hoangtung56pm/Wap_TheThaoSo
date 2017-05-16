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
using Wap_TheThaoSo.vn.xzone.media;

namespace Wap_TheThaoSo.Video
{
    public partial class Download : BasePage
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
            price = AppEnv.GetSetting("videoprice");
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
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = _videoController.GetVideoDetail(id, 1, 5).Tables[0];

            chitietGiaodich = "Video download:" + dtDetail.Rows[0]["Title"] + " | id=" + id;

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                lblTen.Text = dtDetail.Rows[0]["Title"].ToString();
                lnkDownload.Text = Resources.Resource.wBamDeTai;

                MOReceiver videows = new MOReceiver();
                string wapurl = videows.XzoneReturnUrl(id.ToString(), "9");
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

            //log charging                                 
            ILog logger = LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"]);
            logger.Debug("Dich vu: Download Video - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["Title"] + " - id: " + id);
            logger.Debug("Video Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log    

        }

        protected void btnCo_Click(object sender, EventArgs e)
        {

            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            ////DataTable dt = _videoController.GetVideoDetailW4A(telco, id, 1, 5).Tables[0];
            //DataTable dt = _videoController.GetVideoDetail(id,1,5).Tables[0];

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string pageDisplayContentUrl = UrlProcess.GetVideoDownloadUrl(Lang.ToString(), Width.ToString(), dt.Rows[0]["VideoId"].ToString(), CatID.ToString());
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
    }
}
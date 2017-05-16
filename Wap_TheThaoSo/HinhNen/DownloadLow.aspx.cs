using System;
using System.Data;
using System.Web;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.HinhNen;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.HinhNen
{
    public partial class DownloadLow : BasePage
    {

        private int width;
        private string lang;
        private int id;
        private int catID;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string linkStr, linkStr_KD;
        private string telco;
        private string messageReturn = string.Empty;
        readonly HinhNenController _hinhnenController = new HinhNenController();

        protected void Page_Load(object sender, EventArgs e)
        {
            price = AppEnv.GetSetting("wallprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telco = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetHinhNenHomeLowUrl() + "\" >HINH NỀN</a>";
            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (telco == "Undefined")
                {
                    string url = UrlProcess.GetSmsUrlLow(lang, width.ToString());
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
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price,"Hinh Nen : Id =" + Request.QueryString["id"]);
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
            DataTable dtDetail = _hinhnenController.GetWallpaperDetail(telco, id, 1, 1).Tables[0];

            chitietGiaodich = "Hinh Nen Download: " + dtDetail.Rows[0]["WTitle_Unicode"] + " | id=" + id;

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                lblTen.Text = dtDetail.Rows[0]["WTitle_Unicode"].ToString();
                lnkDownload.Text = Resources.Resource.wBamDeTai;
                //ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " hình nền " + dtDetail.Rows[0]["WTitle_Unicode"] + " (" + dtDetail.Rows[0]["WCode"] + ")";

                lnkDownload.NavigateUrl = UrlProcess.GetDownloadItem(telco, "1", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "hình nền " + "<b>" + dtDetail.Rows[0]["WTitle_Unicode"] + "</b>";

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.HinhNen);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.HinhNen, messageReturn);                    
            }

            //log charging                                 
            ILog logger = LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"]);
            logger.Debug("Dich vu: Download Hinh Nen - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["WTitle_Unicode"] + " - id: " + id);
            logger.Debug("Hinh Nen Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log  
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {

            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //DataTable dt = _hinhnenController.GetWallpaperDetail(telco, id, 1, 1).Tables[0];

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string pageDisplayContentUrl = UrlProcess.GetWallpaperDownloadLowUrl(Lang.ToString(), Width.ToString(), dt.Rows[0]["W_WItemID"].ToString(), CatID.ToString());
            //    string url = UrlProcess.BuildUrlCharging(AppEnv.GetSetting("wallprice"),
            //                                                     dt.Rows[0]["W_WItemID"].ToString(), "1",
            //                                                     dt.Rows[0]["WTitle"].ToString(), pageDisplayContentUrl);

            //    Response.Redirect(url);
            //}

        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //string url = UrlProcess.GetHinhNenDetailLowUrl(id);
            //Response.Redirect(url);
        }
    }
}
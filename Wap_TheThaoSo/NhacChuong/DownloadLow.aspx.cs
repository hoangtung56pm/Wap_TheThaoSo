using System;
using System.Data;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.NhacChuong;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.NhacChuong
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
        readonly NhacChuongController _nhacChuongController = new NhacChuongController();

        protected void Page_Load(object sender, EventArgs e)
        {
            price = AppEnv.GetSetting("ringtoneprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telco = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetNhacChuongHomeLowUrl() + "\" >Nhạc Chuông</a>";
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
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price,"Nhac Chuong : Id =" + Request.QueryString["id"]);
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
            DataTable dtDetail = _nhacChuongController.GetRingToneDetail(telco, id, 1, 1).Tables[0];

            chitietGiaodich = "Nhac Chuong Download: " + dtDetail.Rows[0]["SongNameUnicode"] + " | id=" + id;

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                lblTen.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                lnkDownload.Text = Resources.Resource.wBamDeTai;

                lnkDownload.NavigateUrl = UrlProcess.GetRingToneDownloadItem(telco, "22", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "nhạc chuông " + "<b>" + dtDetail.Rows[0]["SongNameUnicode"] + "</b>";

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.NhacChuong);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.NhacChuong, messageReturn);                    
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {

            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //DataTable dt = _nhacChuongController.GetRingToneDetail(telco, id, 1, 5).Tables[0];

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string pageDisplayContentUrl = UrlProcess.GetRingToneDownloadLowUrl(Lang.ToString(), Width.ToString(), dt.Rows[0]["W_MItemId"].ToString(), CatID.ToString());
            //    string url = UrlProcess.BuildUrlCharging(AppEnv.GetSetting("ringtoneprice"),
            //                                                     dt.Rows[0]["W_MItemId"].ToString(), "2",
            //                                                     dt.Rows[0]["SongNameUnicode"].ToString(), pageDisplayContentUrl);

            //    Response.Redirect(url);
            //}
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //string url = UrlProcess.GetNhacChuongDetailLowUrl(0, id);
            //Response.Redirect(url);
        }

    }
}
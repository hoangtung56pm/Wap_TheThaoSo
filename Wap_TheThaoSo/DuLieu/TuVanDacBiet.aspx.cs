using System;
using System.Data;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu
{
    public partial class TuVanDacBiet : BasePage
    {
        private int width;
        private string lang;
        private string id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ms = "";
            if (Session["msisdn"] != null)
            {
                ms = Session["msisdn"].ToString();
            }
            UserAcountController uc = new UserAcountController();
            if (uc.Login(ms, "DK"))
            {
                price = "0";
                HienThiNoiDung(true);
            }
            else
            {
                price = AppEnv.GetSetting("TuVanBongDa");
                lang = Request.QueryString["lang"];
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                id = ConvertUtility.ToString(Request.QueryString["id"]);
                telCo = Session["telco"].ToString();
                linkStr = "<a href=\"../" + UrlProcess.GetVideoHomeLowUrl() + "\" >VIDEO<a>";
                if (!IsPostBack)
                {
                    if (width == 0)
                        width = (int)Constant.DefaultScreen.Standard;
                    ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                    if (telCo == "Undefined")
                    {

                        string url = UrlProcess.GetSmsUrl(lang, width.ToString());
                        Response.Redirect(url);
                        //HienThiNoiDung(true);

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
                                //DataTable dt = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                                //if (dt.Rows.Count > 0 && ConvertUtility.ToDateTime(dt.Rows[0]["ExpiredTime"].ToString()) >= DateTime.Now)
                                //{
                                //    price = "0";
                                //    HienThiNoiDung(true);
                                //    break;
                                //}

                                var charging = new Library.VNMCharging.VNMChargingGW();
                                messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price, "Tu Van Bong Da : Id =" + Request.QueryString["id"]);
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
        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    if (!Page.IsPostBack)
        //    {
               
        //    }
        //}

        protected void HienThiNoiDung(Boolean thuchien)
        {
            pnlNoiDung.Visible = true;
            string id = ConvertUtility.ToString(Request.QueryString["id"]);
            DataTable dtDetail = _duLieuController.WapTheThaoSoGet87Content(id.ToString());

            //string game87Id = dtDetail.Rows[0]["Game87_Id"].ToString();

            chitietGiaodich = "Tu Van Bong Da:" + dtDetail.Rows[0]["ServiceName"] + " | id=" + id;

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                lblTen.Text = dtDetail.Rows[0]["ServiceName"].ToString();
                ltrNoiDung.Text = dtDetail.Rows[0]["Content"].ToString().Replace("\r\n", "<br />");

                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "tư vấn đặc biệt " + "<b>" + dtDetail.Rows[0]["ServiceName"] + "</b>";
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa, messageReturn);                    
            }

        }

        protected void btnCo_Click(object sender, EventArgs e)
        {

            //id = ConvertUtility.ToString(Request.QueryString["id"]);
            //DataTable dt = _duLieuController.WapTheThaoSoGet87Content(id);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string pageDisplayContentUrl = UrlProcess.GetTuVanDownloadUrl(Lang.ToString(), Width.ToString(), id, CatID.ToString());
            //    string url = UrlProcess.BuildUrlCharging(AppEnv.GetSetting("goldprice"),
            //                                                     id, "14",
            //                                                     dt.Rows[0]["ServiceName"].ToString(), pageDisplayContentUrl);

            //    Response.Redirect(url);
            //}

        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            //string url = UrlProcess.GetTuVanUrl();
            //Response.Redirect(url);
        }
    }
}
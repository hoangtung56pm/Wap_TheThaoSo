using System;
using System.Data;
using System.Web;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow.Bonus
{
    public partial class ChiTietTranDau_TyLe : System.Web.UI.UserControl
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
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {
            price = AppEnv.GetSetting("DuLieu_TyLe");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telco = Session["telco"].ToString();
            if(!Page.IsPostBack)
            {
                if (telco == "Undefined")
                {

                    string url = UrlProcess.GetSmsUrlLow(lang, width.ToString());
                    Response.Redirect(url);

                    pnlThongBao.Visible = true;
                    if (lang == "1")
                    {
                        ltrThongBao.Text = Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrThongBao.Text = Resources.Resource.wChon3G_KD;
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
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price,"Ty Le Bong Da : MatchId =" + Request.QueryString["id"]);
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
            if (id > 0)
            {
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchOdd(id);

                if (ds != null)
                {
                    chitietGiaodich = "Xem tỷ lệ trận đấu : " + ds.Tables[0].Rows[0]["Team_A_Name"] + " vs " + ds.Tables[0].Rows[0]["Team_B_Name"] + " | Matchid=" + id;
                    string status = string.Empty;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptTeamInfo.DataSource = ds.Tables[0];
                        rptTeamInfo.DataBind();

                        rptInfoLink.DataSource = ds.Tables[0];
                        rptInfoLink.DataBind();

                        status = ds.Tables[0].Rows[0]["Status"].ToString();
                    }

                    if(thuchien)
                    {
                        pnlThongBao.Visible = false;
                        pnlTyLe.Visible = true;

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            rptTyle.DataSource = ds.Tables[1];
                            rptTyle.DataBind();

                            if (!string.IsNullOrEmpty(status) && status != "Played")
                            {
                                rptUpdateDate.DataSource = ds.Tables[1];
                                rptUpdateDate.DataBind();
                            }
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            rptTaixiu.DataSource = ds.Tables[2];
                            rptTaixiu.DataBind();
                        }

                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.RawUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa);
                    }
                    else
                    {
                        //Thông báo lỗi thanh toán
                        pnlThongBao.Visible = true;
                        pnlTyLe.Visible = false;

                        if (lang == "1")
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan;
                        }
                        else
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                        }
                        Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa, messageReturn);                    
                    }

                    //log charging                                 
                    ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("--------------------------------------------------");
                    logger.Debug("MSISDN:" + Session["msisdn"]);
                    logger.Debug("Dich vu: Xem ty le tran dau - parameter: " + price + " - Tran: " + ds.Tables[0].Rows[0]["Team_A_Name"] + "vs" + ds.Tables[0].Rows[0]["Team_B_Name"] + " - id: " + id);
                    logger.Debug("Ty le Url:" + AppEnv.GetSetting("WapDefault") + Request.RawUrl);
                    logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                    logger.Debug("Error:" + messageReturn);
                    logger.Debug("Current Url:" + Request.RawUrl);
                    //end log   
                }
            }
        }
    }
}
﻿using System;
using System.Data;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu
{
    public partial class Tip : BasePage
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
            price = AppEnv.GetSetting("TuVanBongDa");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToString(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = "TIP";
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
                            //DataTable dt = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                            //if (dt.Rows.Count > 0 && ConvertUtility.ToDateTime(dt.Rows[0]["ExpiredTime"].ToString()) >= DateTime.Now)
                            //{
                            //    price = "0";
                            //    HienThiNoiDung(true);
                            //    break;
                            //}

                            var charging = new Library.VNMCharging.VNMChargingGW();
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price, "Tip Bong Da : Id =" + Request.QueryString["id"]);
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
            string id = ConvertUtility.ToString(Request.QueryString["id"]);

            DataTable dtDetail = _duLieuController.WapTheThaoSoGetTipContent(id);

            if (thuchien)
            {
                pnlNoiDung.Visible = true;
                pnlSMS.Visible = false;

                chitietGiaodich = "Tip Bong Da:" + dtDetail.Rows[0]["MatchName"] + " | id=" + id;

                lblTen.Text = dtDetail.Rows[0]["MatchName"].ToString();
                ltrNoiDung.Text = dtDetail.Rows[0]["Tip_Content"].ToString().Replace("\r\n", "<br />");

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id, chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id, chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa, messageReturn);
            }

        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WapXzone.Library.UrlProcess;
//using WapXzone.Library.Utilities;
//using WapXzone.Library.Constant;
//using WapXzone.Library;
using System.Configuration;
using System.Data;
//using WapXzone.Library.Component.Transaction;
//using WapXzone.Library.Component.HinhNen;
//using WapXzone.Library.Component.MT;
using log4net;

namespace Wap_TheThaoSo.Hinhnen
{
    public partial class SendGift : BasePage
    {
        private int width;        
        private string lang;        
        private int id;
        private string SoDT;
        private int catID = 0;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string linkStr, linkStr_KD;
        private string telCo;
        private string messageReturn = string.Empty;
        private string opr = string.Empty;
                
        protected void Page_Load(object sender, EventArgs e)
        {            
            //lang = Request.QueryString["lang"];
            //width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            //SoDT = Request.QueryString["sdt"];
            //telCo = Session["telco"].ToString();
            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);              
            //DataTable dtDetail = HinhNenController.GetWallpaperDetailByID(telCo, id);            
                
            //if (catID == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
            //    price = ConfigurationSettings.AppSettings.Get("thuphapprice");
            //else
            //    price = ConfigurationSettings.AppSettings.Get("wallprice");
            //linkStr = "<a href=\"../" + UrlProcess.GetWallpaperHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >HÌNH NỀN<a>";
            //linkStr_KD = "<a href=\"../" + UrlProcess.GetWallpaperHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >HINH NEN<a>";
            //if (!IsPostBack)
            //{
            //    if (width == 0)
            //        width = (int)Constant.DefaultScreen.Standard;
            //    ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

            //    //Nếu số điện thoại không hợp lệ thì hướng dẫn
            //    if (!MobileUtils.IsMobileNumber(SoDT))
            //    {
            //        pnlSMS.Visible = true;
            //        if (lang == "1")
            //        {
            //            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
            //            ltrSMS.Text =  Resources.Resource.wSoDienThoaiKhongHopLe;
            //        }
            //        else
            //        {
            //            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
            //            ltrSMS.Text =  Resources.Resource.wSoDienThoaiKhongHopLe_KD;
            //        }
            //        return;
            //    }
                
            //    if (Session["transactionid_old"] != null)
            //    {// Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán                    
            //        messageReturn = ConvertUtility.ToString(Session["debit_status"]);
            //        if (ConvertUtility.ToString(Session["debit_status"]) == "0")
            //        {// Thanh toán thành công >> trả nội dung
            //            HienThiNoiDung(true);
            //        }
            //        else
            //        {// Thanh toán không thành công >> thông báo lỗi
            //            HienThiNoiDung(false);                        
            //        }
            //        Session["transactionid_old"] = null;
            //        Session["soguitang"] = null;
            //    }
            //    else
            //    {                    
            //        if (telCo == Constant.T_Mobifone)
            //        {
            //            Session["soguitang"] = SoDT;
            //            string content = Session["cpid"].ToString() + "&" + Constant.hinhnen + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();                        
            //            Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
            //        }
            //        else if (telCo == Constant.T_Vinaphone)
            //        {
            //            Session["soguitang"] = SoDT;
            //            string orderdatetime = DateTime.Now.ToString("yyyyMMddHHmmss");                        
            //            Session["VinaContentUrl"] = Request.Url.AbsoluteUri;
            //            Session["orderid"] = orderdatetime + SecurityMethod.RandomStringNumber(4); 
            //            Session["price"] = price;
            //            Session["orderinfo"] = "Hình nền " + dtDetail.Rows[0]["WTitle_Unicode"].ToString();
            //            string backurl = ConvertUtility.ToString(Request.UrlReferrer);
            //            if (backurl == String.Empty) backurl = ConfigurationSettings.AppSettings.Get("WapVinaphoneDefault");
            //            backurl = Server.UrlEncode(backurl);
            //            Response.Redirect(ConfigurationSettings.AppSettings.Get("vnp3g") + "?orderid=" + Session["orderid"].ToString() + "&orderinfo=" + Server.UrlEncode(Session["orderinfo"].ToString()) +
            //                "&orderdatetime=" + orderdatetime + "&price=" + price + "&reason=" + ConfigurationSettings.AppSettings.Get("vnpreason") +
            //                "&originalprice=" + price + "&promotion=0" + "&note=" + Server.UrlEncode("") + "&returnurl=" + Server.UrlEncode(ConfigurationSettings.AppSettings.Get("WapVinaphoneDefault") + ConfigurationSettings.AppSettings.Get("vnpreturnurl")) +
            //                "&backurl=" + backurl + "&servicename=" + ConfigurationSettings.AppSettings.Get("vnpservicename") +
            //                "&securecode=" + SecurityMethod.MD5Encrypt(Session["orderid"].ToString() + " " + orderdatetime + " " + ConfigurationSettings.AppSettings.Get("vnpsecurepass")));                                                                        
            //        }
            //        //                
            //        if (telCo == "Undefined")
            //        {
            //            pnlSMS.Visible = true;
            //            if (lang == "1")
            //            {
            //                ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
            //                ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("wallcode") + " " + dtDetail.Rows[0]["WCode"].ToString() + " " + SoDT + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("wallcommandcode") + "</b> để gửi tặng hình nền <b>" + dtDetail.Rows[0]["WTitle_Unicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
            //            }
            //            else
            //            {
            //                ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
            //                ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("wallcode") + " " + dtDetail.Rows[0]["WCode"].ToString() + " " + SoDT + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("wallcommandcode") + "</b> de gui tang hinh nen <b>" + dtDetail.Rows[0]["WTitle"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
            //            }
            //        }
            //        else
            //        {
            //            pnlThongBao.Visible = true;
            //            if (lang == "1")
            //            {
            //                ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
            //                //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu.Replace("xxx", price);
            //                ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu + "hình nền " + dtDetail.Rows[0]["WTitle_Unicode"].ToString();
            //                btnCo.Text = Resources.Resource.btnCo;
            //                btnKhong.Text = Resources.Resource.btnKhong;
            //            }
            //            else
            //            {
            //                ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
            //                //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD.Replace("xxx", price);
            //                ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD + "hinh nen " + dtDetail.Rows[0]["WTitle"].ToString();
            //                btnCo.Text = Resources.Resource.btnCo_KD;
            //                btnKhong.Text = Resources.Resource.btnKhong_KD;
            //            }
            //        }
            //    }
            //}
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            //pnlThongBao.Visible = false;
            //try
            //{
            //    switch (Session["telco"].ToString())
            //    {
            //        //case "Vinaphone":
            //        //    messageReturn = Vinaphone_Charging.ReturnChargingResult(Session["msisdn"].ToString(), price);
            //        //    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "0")
            //        //    {// Thanh toán thành công >> trả nội dung                        
            //        //        HienThiNoiDung(true);
            //        //    }
            //        //    else
            //        //    {// Thanh toán không thành công >> thông báo lỗi
            //        //        HienThiNoiDung(false);
            //        //    }
            //        //    break;
            //        case "Viettel":
            //            Session["transactionid"] = ConvertUtility.ToString(HttpContext.Current.Request.Headers.Get("VSessionid"));
            //            string type = "WALLPAPER";
            //            DateTime sentTime = DateTime.Now;
            //            if (WapXzone.Library.Viettel_Charging.ChargingSuccess(Session["msisdn"].ToString(), Session["transactionid"].ToString(), price, out messageReturn, type, sentTime))
            //            {// Thanh toán thành công >> trả nội dung                                    
            //                HienThiNoiDung(true);
            //            }
            //            else
            //            {// Thanh toán không thành công >> thông báo lỗi
            //                HienThiNoiDung(false);
            //            };
            //            break;
            //        case "EVN":
            //            string resultCode = WapXzone.Library.EVN_Charging.ReturnChargingResult(Session["msisdn"].ToString(), price);
            //            if (resultCode == "1" || resultCode == "2")
            //            {// Thanh toán thành công >> trả nội dung
            //                if (resultCode == "2") opr = "Postpaid";
            //                HienThiNoiDung(true);
            //            }
            //            else
            //            {// Thanh toán không thành công >> thông báo lỗi
            //                HienThiNoiDung(false);
            //            }
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            //    logger.Debug("----------Lỗi charging----------------------");
            //    logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            //    logger.Debug(ex.ToString());
            //    logger.Debug("----------Lỗi charging----------------------");
            //}
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            //Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            //pnlNoiDung.Visible = true;
            
            //id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //DataTable dtDetail = HinhNenController.GetWallpaperDetailByID(Session["telco"].ToString(), id);
            //SoDT = MobileUtils.ToSTDMobileNumber(SoDT);
            //if (thuchien)
            //{
            //    if (lang == "1")
            //    {
            //        ltrTieuDe.Text = linkStr;
            //        lblTen.Text = dtDetail.Rows[0]["WTitle_Unicode"].ToString();
            //        //lnkDownload.Text = Resources.Resource.wBamDeTai;
            //        ltrNoiDung.Text = Resources.Resource.wTangThanhCong + " hình nền " + dtDetail.Rows[0]["WTitle_Unicode"].ToString() + " (" + dtDetail.Rows[0]["WCode"].ToString() + ") tới số điện thoại 0" + SoDT.Remove(0, 2);
            //    }
            //    else
            //    {
            //        ltrTieuDe.Text = linkStr_KD;
            //        lblTen.Text = dtDetail.Rows[0]["WTitle"].ToString();
            //        //lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
            //        ltrNoiDung.Text = Resources.Resource.wTangThanhCong_KD + " hinh nen " + dtDetail.Rows[0]["WTitle"].ToString() + " (" + dtDetail.Rows[0]["WCode"].ToString() + ") toi so dien thoai 0" + SoDT.Remove(0, 2);
            //    };

            //    string url = UrlProcess.GetDownloadItem(Session["telco"].ToString(), "1", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
            //    MTInfo mtInfo = new MTInfo();
            //    Random random = new Random();
            //    //Thông báo cho người được tặng                
            //    mtInfo.User_ID = SoDT;
            //    mtInfo.Service_ID = ConfigurationSettings.AppSettings.Get("wallcommandcode");
            //    mtInfo.Command_Code = ConfigurationSettings.AppSettings.Get("wallcode");
            //    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
            //    mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
            //    mtInfo.Total_Message = 1;
            //    mtInfo.Message_Index = 0;
            //    mtInfo.IsMore = 0;
            //    mtInfo.Content_Type = 0;
            //    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
            //    mtInfo.Message = "Ban nhan duoc qua tang hinh nen " + dtDetail.Rows[0]["WCode"].ToString() + " tu so dien thoai " + "0" + Session["msisdn"].ToString().Remove(0, 2);
            //    MTController.SMS_MTInsert(mtInfo);

            //    //MT thong bao cho nguoi gui tang biet
            //    mtInfo.Content_Type = 0;
            //    mtInfo.User_ID = Session["msisdn"].ToString();
            //    mtInfo.Message = "Ban da gui tang thanh cong hinh nen " + dtDetail.Rows[0]["WCode"].ToString() + " toi so dt " + SoDT;
            //    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
            //    mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
            //    MTController.SMS_MTInsert(mtInfo);

            //    //Build waplink send to customer and insert to MT table
            //    mtInfo.User_ID = SoDT;
            //    mtInfo.Message = "Tai hinh nen duoc tang theo dia chi: " + url;
            //    mtInfo.Content_Type = 8;
            //    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
            //    mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
            //    MTController.SMS_MTInsert(mtInfo);

            //    bool log = true;
            //    if (ConvertUtility.ToString(Session["transactionid_detail"]) == chitietGiaodich) log = false;
            //    Session["transactionid_detail"] = chitietGiaodich;
            //    if (log)
            //    {
            //        //Lưu Transaction
            //        if (ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]) == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
            //        {
            //            chitietGiaodich = "Thu phap: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            //            Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 15, opr);
            //        }
            //        else
            //        {
            //            chitietGiaodich = "Hinh nen: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            //            Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 1, opr);
            //        }
            //        HinhNenController.SetDownloadCounter(Session["telco"].ToString(), id);
            //    }
            //}
            //else
            //{
            //    //Thông báo lỗi thanh toán
            //    if (lang == "1")
            //    {
            //        ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
            //        ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
            //    }
            //    else
            //    {
            //        ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
            //        ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
            //    }
            //    if (ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]) == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
            //    {
            //        chitietGiaodich = "Thu phap: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            //        Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 15, messageReturn, opr);
            //    }
            //    else
            //    {
            //        chitietGiaodich = "Hinh nen: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            //        Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 1, messageReturn, opr);
            //    }
            //    //--Thông báo lỗi thanh toán    
            //}
            ////log charging                                 
            //ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            //logger.Debug("--------------------------------------------------");
            //logger.Debug("MSISDN: " + Session["msisdn"].ToString());
            //logger.Debug("So gui tang: " + SoDT);
            //logger.Debug("Dich vu: Hinh nen - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["WTitle"].ToString() + " - id: " + id);
            //logger.Debug("Wallpaper Url:" + lnkDownload.NavigateUrl);
            //string clientIP = HttpContext.Current.Request.UserHostAddress;
            //if (Session["telco"].ToString() == Constant.T_Viettel) clientIP = ConvertUtility.ToString(HttpContext.Current.Request.Headers.Get("VX-Forwarded-For"));
            //logger.Debug("IP:" + clientIP);
            //logger.Debug("Error:" + messageReturn);
            //logger.Debug("Current Url:" + Request.RawUrl);
            ////end log
        }
    }
}

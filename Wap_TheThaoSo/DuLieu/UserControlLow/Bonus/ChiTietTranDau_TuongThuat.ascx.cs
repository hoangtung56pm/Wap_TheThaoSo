using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow.Bonus
{
    public partial class ChiTietTranDau_TuongThuat : System.Web.UI.UserControl
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

        protected int VideoId;

        private readonly VideoController _videoController = new VideoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            price = AppEnv.GetSetting("DuLieu_TuongThuat");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
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

                            if (Session["messageReturn_" + id] != null)
                            {
                                if (Session["messageReturn_" + id].ToString() == "1")
                                {
                                    price = "0";
                                    HienThiNoiDung(true);
                                    break;
                                }
                            }

                            var charging = new Library.VNMCharging.VNMChargingGW();
                            messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price, "Tuong thuat Bong Da : MatchId =" + Request.QueryString["id"]);
                            ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                            logger.Debug("---" + messageReturn + "---");
                            if (messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true);
                                Session["messageReturn_" + id] = "1";
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

        protected void lnkVideo_Click(object sender, EventArgs e)
        {
            if (Session["msisdn"] != null)
            {
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);
                int videoId = ConvertUtility.ToInt32(ds.Tables[3].Rows[0]["Video_Id"]);
                string url = GetVideoLink(videoId);

                DataTable dt = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                if (dt.Rows.Count > 0 && ConvertUtility.ToDateTime(dt.Rows[0]["ExpiredTime"].ToString()) >= DateTime.Now) // Da DK Goi Tuan
                {
                    messageReturn = "1";
                    pnlTuongThuat.Visible = false;

                    pnlThongBao.Visible = true;
                    ltrThongBao.Text = "<a href=\" " + url + " \"><span style=\"color:#0000FF; text-decoration:underline\">Bấm vào đây để xem Video</span></a>";
                }
                else //Chua DK Goi Tuan
                {
                    price = "2000";

                    chitietGiaodich = "Xem video Tran Dau Id :" + id;

                    var charging = new Library.VNMCharging.VNMChargingGW();
                    messageReturn = charging.PaymentVnm(Session["msisdn"].ToString(), price, "Xem Video Tran Dau : MatchId =" + Request.QueryString["id"]);
                    ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("---" + messageReturn + "---");
                    if (messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung       

                        pnlTuongThuat.Visible = false;

                        pnlThongBao.Visible = true;
                        ltrThongBao.Text = "<a href=\" " + url + " \"><span style=\"color:#0000FF; text-decoration:underline\">Bấm vào đây để xem Video</span></a>";

                        if (AppEnv.GetSetting("TestFlag") == "0")
                        {
                            Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.RawUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa);   
                        }
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        pnlThongBao.Visible = true;
                        pnlTuongThuat.Visible = false;

                        if (lang == "1")
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan;
                        }
                        else
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                        }
                        if (AppEnv.GetSetting("TestFlag") == "0")
                        {
                            Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa, messageReturn);   
                        }
                    }
                }

                //log charging                                 
                ILog loggerVideo = LogManager.GetLogger(Session["telco"].ToString());
                loggerVideo.Debug("--------------------------------------------------");
                loggerVideo.Debug("MSISDN:" + Session["msisdn"]);
                loggerVideo.Debug("Dich vu: Xem Video thuat tran dau - parameter: " + price + " - id: " + id);
                loggerVideo.Debug("Tuong thuat Url:" + AppEnv.GetSetting("WapDefault") + Request.RawUrl);
                loggerVideo.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                loggerVideo.Debug("Error:" + messageReturn);
                loggerVideo.Debug("Current Url:" + Request.RawUrl);
                //end log 

            }
        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
            
        //}

        protected string GetVideoLink(int videoId)
        {
            DataSet ds = _videoController.GetVideoDetail(videoId, 1, 1);

            string str = string.Empty;

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                str = AppEnv.GetViewLinkLow(dt.Rows[0]["MobilePath"].ToString());
            }

            return str;
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            if (id > 0)
            {
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);
                if (ds != null)
                {
                    string status = string.Empty;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptTeamInfo.DataSource = ds.Tables[0];
                        rptTeamInfo.DataBind();

                        rptInfoLink.DataSource = ds.Tables[0];
                        rptInfoLink.ItemDataBound += rptInfoLink_ItemDataBound;
                        rptInfoLink.DataBind();

                        status = ds.Tables[0].Rows[0]["Status"].ToString();

                        chitietGiaodich = "Xem tường thuật trận đấu : " + ds.Tables[0].Rows[0]["Team_A_Name"] + " vs " + ds.Tables[0].Rows[0]["Team_B_Name"] + " | Matchid=" + id;
                    }

                    if(thuchien)
                    {
                        pnlTuongThuat.Visible = true;
                        pnlThongBao.Visible = true;

                        if (ds.Tables[1].Rows.Count > 0)
                        {

                            if (ds.Tables[1].Rows[0]["Content"].ToString() != "Trận đấu bắt đầu")
                            {
                                DataRow dr = ds.Tables[1].NewRow();
                                dr["Match_ID"] = id;
                                dr["Time"] = 1;
                                dr["Minute_Extra"] = 0;
                                dr["Content"] = "Trận đấu bắt đầu";
                                dr["Code"] = id;

                                ds.Tables[1].Rows.InsertAt(dr, 0);
                            }

                            if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            {
                                status = ds.Tables[2].Rows[0]["Status"].ToString();
                                if (status.ToLower() == "played")
                                {
                                    if (ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Content"].ToString() != "Trận đấu kết thúc !!!")
                                    {
                                        DataRow drLast = ds.Tables[1].NewRow();
                                        drLast["Match_ID"] = id;
                                        drLast["Time"] = "90";
                                        drLast["Minute_Extra"] = ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Minute_Extra"];
                                        drLast["Content"] = "Trận đấu kết thúc !!!";
                                        drLast["Code"] = id;

                                        ds.Tables[1].Rows.InsertAt(drLast, ds.Tables[1].Rows.Count);
                                    }
                                }
                            }


                            rptCommentary.DataSource = ds.Tables[1];
                            rptCommentary.ItemDataBound += rptCommentary_ItemDataBound;
                            rptCommentary.DataBind();
                        }
                        else
                        {
                            if (status == "Fixture")
                            {
                                divThongBao.Visible = true;
                            }
                        }

                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.RawUrl, id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa);
                    }
                    else
                    {
                        //Thông báo lỗi thanh toán
                        pnlThongBao.Visible = true;
                        pnlTuongThuat.Visible = false;

                        if (lang == "1")
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan;
                        }
                        else
                        {
                            ltrThongBao.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                        }
                        Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, (int)Constant.ItemType.DuLieuBongDa ,messageReturn);                    
                    }

                    //log charging                                 
                    ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("--------------------------------------------------");
                    logger.Debug("MSISDN:" + Session["msisdn"]);
                    logger.Debug("Dich vu: Xem tuong thuat tran dau - parameter: " + price + " - Tran: " + ds.Tables[0].Rows[0]["Team_A_Name"] + "vs" + ds.Tables[0].Rows[0]["Team_B_Name"] + " - id: " + id);
                    logger.Debug("Tuong thuat Url:" + AppEnv.GetSetting("WapDefault") + Request.RawUrl);
                    logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                    logger.Debug("Error:" + messageReturn);
                    logger.Debug("Current Url:" + Request.RawUrl);
                    //end log   
                }
            }
        }

        void rptCommentary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var litImg = (Literal)e.Item.FindControl("litImage");
            var extraTIme = (Literal)e.Item.FindControl("litExtraTime");
            var currData = (DataRowView)e.Item.DataItem;


            if (extraTIme != null)
            {
                int extra = ConvertUtility.ToInt32(currData["Minute_Extra"]);
                if (extra > 0)
                {
                    extraTIme.Text = "+" + extra;
                }
            }

            if (litImg != null)
            {
                if (currData["Code"].ToString() == "G")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/icon-bong.png\">";
                }
                else if (currData["Code"].ToString() == "YC")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/YC.png\">";
                }
                else if (currData["Code"].ToString() == "Y2C")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/Y2C.png\">";
                }
                else if (currData["Code"].ToString() == "SI")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/in.png\">";
                }
                else if (currData["Code"].ToString() == "PG")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/PG.png\">";
                }
                else if (currData["Code"].ToString() == "RC")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/red-card.jpg\">";
                }
                else if (currData["Code"].ToString() == "OG")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/ball1.png\">";
                }
            }

        }

        protected void rptInfoLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);

            if (e.Item.ItemIndex < 0) return;

            var pnlNonVideo = (Panel)e.Item.FindControl("pnlNonVideo");
            var pnlVideo = (Panel)e.Item.FindControl("pnlVideo");

            if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
            {
                pnlVideo.Visible = true;
                VideoId = ConvertUtility.ToInt32(ds.Tables[3].Rows[0]["Video_Id"]);
            }
            else
            {
                pnlNonVideo.Visible = true;
            }
        }
    }
}
using System;
using System.Data;
using System.Web;
using log4net;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.Wap.UserControl
{

    public partial class Header : System.Web.UI.UserControl
    {
        protected string TinTucCss = "none";
        protected string DuLieuCss = "none";
        protected string VideoCssS = "none";
        protected string LiveCss = "none";
        readonly TinTucController _tinTucController = new TinTucController();

        protected void Page_Load(object sender, EventArgs e)
        {

            string url = HttpContext.Current.Request.RawUrl.ToLower();

            string[] arrUrl = url.Split('/');

            string display = ConvertUtility.ToString(Request.QueryString["display"]);

            if (display == "login" || url.Contains("gameshow.aspx") || url.Contains("cauhoi.aspx"))
            {
                pnlDangKy.Visible = false;
            }
            else if(Session["msisdn"] != null)
            {
                if (!string.IsNullOrEmpty(Session["msisdn"].ToString()) && Session["msisdn"].ToString() != "Khách")
                {
                    try
                    {
                        DataTable dt = GameShow.CheckActive(Session["msisdn"].ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            pnlDangKy.Visible = false;
                        }
                    }
                    catch
                    {
                        pnlDangKy.Visible = true;
                    }
                }
            }
            else
            {
                pnlDangKy.Visible = true;
            }

            if (url.Contains("wap") || url.ToLower().Contains("tintuc"))
                TinTucCss = "selected";
            else if (url.Contains("dulieu") && display == "livescore")
                LiveCss = "selected";
            else if (url.Contains("video"))
                VideoCssS = "selected";
            else if (url.Contains("dulieu") || arrUrl[0].ToLower() == "dulieu")
                DuLieuCss = "selected";

            //}

            if (!IsPostBack)
            {
                DesSecurity des = new DesSecurity();

                string cipher = Request.QueryString["p"];

                //Session.Clear();

                //if (AppEnv.GetSetting("TestFlag") == "1")
                //{
                //    Session["MSISDN"] = "Khách";
                //    Session["Telco"] = "3";
                //    Session["TransID"] = "8";
                //    Session["Status"] = "1";
                //}

                if (AppEnv.GetSetting("TestFlag") == "0")
                {
                    if (Session["MSISDN"] == null || ConvertUtility.ToString(Session["MSISDN"]) == "")
                    {
                        if (string.IsNullOrEmpty(cipher))
                        {
                            //string test = AppEnv.BuildUrlGetMSISDN();
                            Response.Redirect(AppEnv.BuildUrlGetMSISDN());
                        }
                        else
                        {
                            string cleartext = des.Des3Decrypt(cipher, AppEnv.GetSetting("Password"));
                            string[] count = cleartext.Split('|');
                            if (count.Length > 3)
                            {
                                string msisdn = string.Empty;
                                string status = string.Empty;
                                string transactionid = string.Empty;
                                string transactionidold = string.Empty;
                                GetDetailCharging(cleartext, ref msisdn, ref status, ref transactionid, ref transactionidold);

                                Session["MSISDN"] = msisdn;
                                Session["Status"] = status;
                                Session["TransID"] = transactionid;
                                Session["OldTransID"] = transactionidold;
                            }
                            else
                            {

                                string msisdn = string.Empty;
                                string telco = string.Empty;
                                string transactionid = string.Empty;

                                GetDetailUrl(cleartext, ref msisdn, ref telco, ref transactionid);



                                Session["MSISDN"] = msisdn;
                                Session["Telco"] = telco;
                                Session["TransID"] = transactionid;
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cipher))
                        {
                            string cleartext = des.Des3Decrypt(cipher, AppEnv.GetSetting("Password"));
                            string[] count = cleartext.Split('|');
                            if (count.Length > 3)
                            {
                                string msisdn = string.Empty;
                                string status = string.Empty;
                                string transactionid = string.Empty;
                                string transactionidold = string.Empty;
                                GetDetailCharging(cleartext, ref msisdn, ref status, ref transactionid, ref transactionidold);

                                Session["MSISDN"] = msisdn;
                                Session["Status"] = status;
                                Session["TransID"] = transactionid;
                                Session["OldTransID"] = transactionidold;
                            }
                        }
                    }
                }

                if (ConvertUtility.ToString(Session["MSISDN"]) != "")
                {
                    litMsisdn.Text = Session["MSISDN"].ToString();
                }
                else
                {
                    if (AppEnv.GetSetting("TestFlag") == "1")
                    {
                        Session["MSISDN"] = "Khách";   
                    }

                    litMsisdn.Text = "Khách";
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataSet ds = _tinTucController.GetHomeMarqueeNews();
            if (ds != null)
            {
                rptMarqueeNews.DataSource = ds.Tables[0];
                rptMarqueeNews.DataBind();
            }

        }


        protected void btnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string key = txtKey.Text;
            string url = UrlProcess.GetNewsSearchResultUrl(key.Replace(" ", "+"));
            Response.Redirect(url);
        }

        public static void GetDetailUrl(string plaintext, ref string msisdn, ref string telco, ref string transactionid)
        {
            try
            {
                if (!string.IsNullOrEmpty(plaintext))
                {
                    string[] arr = plaintext.Split('|');
                    msisdn = arr[0];
                    telco = arr[1];
                    transactionid = arr[2];
                }
                else
                {
                    msisdn = string.Empty;
                    telco = string.Empty;
                    transactionid = string.Empty;
                }
            }
            catch
            {
                msisdn = string.Empty;
                telco = string.Empty;
                transactionid = string.Empty;
            }
        }

        public static void GetDetailCharging(string plaintext, ref string msisdn, ref string status, ref string transactionid, ref string transactionidold)
        {
            try
            {
                if (!string.IsNullOrEmpty(plaintext))
                {
                    string[] arr = plaintext.Split('|');
                    msisdn = arr[0];
                    status = arr[1];
                    transactionid = arr[2];
                    transactionidold = arr[3];
                }
                else
                {
                    msisdn = string.Empty;
                    status = string.Empty;
                    transactionid = string.Empty;
                    transactionidold = string.Empty;
                }
            }
            catch
            {
                msisdn = string.Empty;
                status = string.Empty;
                transactionid = string.Empty;
                transactionidold = string.Empty;
            }
        }

        protected void btnDangKyCgBd_Click(object sender, EventArgs e)
        {
            string url = "/Wap/GameShow.aspx";

            if (Session["MSISDN"] != null && Session["MSISDN"].ToString() != "Khách")
            {

                string userId = Session["msisdn"].ToString();

                #region DK USER

                var entity = new GameShow.ViSport_S2_Registered_UsersInfo();
                entity.User_ID = userId;
                entity.Request_ID = "0";
                entity.Service_ID = "979";
                entity.Command_Code = "TP";
                entity.Service_Type = 1;
                entity.Charging_Count = 0;
                entity.FailedChargingTimes = 0;
                entity.RegisteredTime = DateTime.Now;
                entity.ExpiredTime = DateTime.Now.AddDays(1);
                entity.Registration_Channel = "WAP";
                entity.Status = 1;
                entity.Operator = "vnmobile";
                entity.Point = 2;

                string password = RandomActiveCode.RandomStringNumber(6);
                entity.Password = password;

                DataTable value = GameShow.InsertSportGameHeroRegisterUser(entity);
                if (value.Rows[0]["RETURN_ID"].ToString() == "0")
                {
                    string code1 = RandomActiveCode.Generate(8);
                    string code2 = RandomActiveCode.Generate(8);

                    GameShow.SportGameHeroLotteryCodeInsert(userId, code1);
                    GameShow.SportGameHeroLotteryCodeInsert(userId, code2);

                    #region GUI MT WelCome

                    string mtMessage = "Chuc mung ban da tham gia CTKM Chuyen gia bong da cua Vietnamobile. " +
                                       "Ban co 2 ma du thuong de co co hoi trung thuong 1 dien thoai Samsung galaxy S4." +
                                       "Moi ngay ban se duoc tra loi cau hoi de  nang cao co hoi trung thuong (5000d/ngay). " +
                                       "De kiem tra MDT truy cap: http://visport.vn De huy dvu soan: HUY TP gui 979. HT: 19001255";
                    AppEnv.SentMtPro(userId, mtMessage);

                    #endregion

                    //#region GUI MT Password

                    //mtMessage = "Tai khoan va mat khau su dung dich vu của Quy Khach la:  username: " + userId + ", password: " + password + 
                    //            ". Vui long truy cap website hoac wapsite http://visport.vn de su dung dich vu";

                    //AppEnv.SentMtPro(userId, mtMessage);


                    //#endregion

                    Session["regis"] = "OK";

                }
                else
                {
                    Session["unregis"] = "OK";
                }

                #endregion

            }
            else
            {
                Session["wifi"] = "OK";
            }

            Response.Redirect(url);
        }

    }
}
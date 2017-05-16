using System;
using System.Data;
using System.Web;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap.UserControlLow
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

            if (url.Contains("wap") || url.Contains("tintuc"))
                TinTucCss = "selected";
            else if (url.Contains("dulieu") && display == "livescore")
                LiveCss = "selected";
            else if (url.Contains("video"))
                VideoCssS = "selected";
            else if (url.Contains("dulieu") || arrUrl[0].ToLower() == "dulieu")
                DuLieuCss = "selected";


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
            string url = UrlProcess.GetNewsSearchResultLowUrl(key.Replace(" ", "+"));
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

    }
}
using System;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo
{
    public partial class getmsisdn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesSecurity des = new DesSecurity();
            string cipher = ConvertUtility.ToString(Request.QueryString["cipher"]);
            string telco = "0";
            string msisdn = string.Empty;
            string vms_transactionid = string.Empty;
            string vms_cpid = string.Empty;

            GetDetailUrl(des.Des3Decrypt(cipher, AppEnv.GetSetting("msisdnkey")), ref telco, ref msisdn);

            string t = Request.QueryString["t"];
            

            if (msisdn != string.Empty)
            {
                Session["msisdn"] = msisdn;
                Session["telco"] = Constant.T_Vietnamobile;

                TinTucController.WapUserLog(msisdn,0,string.Empty,3);
            }
            else
            {
                Session["msisdn"] = "Khách";
                Session["telco"] = Constant.T_Undefined;
            }

            if(t != null)
            {
                if(t == "1")
                {
                    Response.Redirect("http://visport.vn/Wap/TranCauVang.aspx");
                }
                else if(t == "2")
                {
                    Response.Redirect("http://visport.vn/Wap/GameShow.aspx");
                }
                else if(t == "3")
                {
                    Response.Redirect("http://visport.vn/worldcup.aspx");
                }
                else if(t == "4")
                {
                    Response.Redirect("http://visport.vn/wap/cauhoi.aspx");
                }
                else if (t == "5")
                {
                    Response.Redirect("http://visport.vn/Wap/Landing.aspx");
                }
                else if (t == "6")
                {
                    Response.Redirect("http://visport.vn/Wap/Landing1.aspx");
                }
                
            }

            Response.Redirect("/");
        }

        public void GetDetailUrl(string plaintext, ref string telco, ref string msisdn)
        {
            try
            {
                if (!string.IsNullOrEmpty(plaintext))
                {
                    string[] arr = plaintext.Split('|');
                    telco = arr[0];
                    msisdn = arr[1];
                    //vms_transactionid = arr[2];
                    //vms_cpid = arr[3];
                }
                else
                {
                    telco = "0";
                    msisdn = string.Empty;
                    //vms_transactionid = string.Empty;
                    //vms_cpid = string.Empty;
                }
            }
            catch
            {
                telco = "0";
                msisdn = string.Empty;
                //vms_transactionid = string.Empty;
                //vms_cpid = string.Empty;
            }


        }
    }
}
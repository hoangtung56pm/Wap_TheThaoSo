using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Vmgame;

namespace Wap_TheThaoSo.Wap
{
    public partial class Register_Vmgame : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //Session["msisdn"] = "841882406279";
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    string msisdn = Session["msisdn"].ToString();
                    DangKyVmGame(msisdn);
                }
            }
            Response.Redirect("/Wap/Default.aspx");
        }
        public static string DangKyVmGame(string msisdn)
        {
            var logger = LogManager.GetLogger("File");
            string reString = "";
            try
            {
                var vmGame = new Service_RegisS2();
                DateTime ResponseTime = DateTime.Now.AddMinutes(30);
                //DateTime ResponseTime =new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 45, 0);
                string value = vmGame.RegisterS2New(msisdn, ResponseTime);

                logger.Debug(" ");
                logger.Debug(" ");
                logger.Debug("-------------------- DK DV VMgame------------------------------");
                logger.Debug("Msisdn registered VmGame : " + msisdn);
                logger.Debug("Result VmGame : " + value);
                logger.Debug(" ");
                logger.Debug(" ");

                return value;
            }
            catch (Exception ex)
            {
                logger.Debug("-------------------- DK DV VMgame Error------------------------------");
                logger.Debug("Exception : " + ex.Message);
            }

            return reString;
        }
    }
}
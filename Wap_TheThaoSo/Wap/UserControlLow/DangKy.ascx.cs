using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap.UserControlLow
{
    public partial class DangKy : System.Web.UI.UserControl
    {

        protected int lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!Page.IsPostBack)
            {
                DataTable dtMsisdn = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                if (dtMsisdn.Rows.Count > 0)
                {
                    pnlDangKy.Visible = false;
                }
            }
        }

        protected void lnkReg_Click(object sender, EventArgs e)
        {
            if (Session["msisdn"].ToString() == "Khách")
            {
                string url = UrlProcess.GetSmsUrl(lang.ToString(), width);

                Response.Redirect(url);
            }

            string messageReturn = "";

            messageReturn = "1";

            if (messageReturn == "1")
            {
                Transaction.ViClipSubscriptionInsert(Session["msisdn"].ToString(), 1, "Addition", DateTime.Now, DateTime.Now.AddDays(7), "viSport");
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), AppEnv.GetSetting("Sub_Price"), "", "", AppEnv.GetSetting("Sub_Desc"), 5);
                Session["messageReturn"] = messageReturn;
                Response.Redirect(AppEnv.GetSetting("vnpreturnurlregisLow"));
            }
            else
            {
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), AppEnv.GetSetting("Sub_Price"), "", "", AppEnv.GetSetting("Sub_Desc"), 5, messageReturn);
                //Response.Redirect(Session["LastPage"].ToString());
            }
        }
    }
}
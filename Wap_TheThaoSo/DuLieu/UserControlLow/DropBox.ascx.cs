using System;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class DropBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string type = ConvertUtility.ToString(Request.QueryString["type"]);
                string display = ConvertUtility.ToString(Request.QueryString["display"]);
                if (display == "trandangda")
                    type = "3";
                else if (display == "dulieu")
                    type = "1";

                if (!string.IsNullOrEmpty(type))
                    dgrBox.SelectedValue = type;
            }
        }

        protected void dgrBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = dgrBox.SelectedValue;

            if (value == "0")
                Response.Redirect(UrlProcess.GetLivescoreLowUrl() + "&type=" + value);
            else if (value == "2")
                Response.Redirect(UrlProcess.GetTranDaDaLowUrl() + "&type=" + value);
            else if (value == "3")
                Response.Redirect(UrlProcess.GetTranDangDaLowUrl() + "&type=" + value);
            else
                Response.Redirect(UrlProcess.GetDuLieuHomeLowUrl() + "&type=" + value);
        }
    }
}
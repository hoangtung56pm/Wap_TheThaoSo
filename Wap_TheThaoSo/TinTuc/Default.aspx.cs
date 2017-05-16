using System;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.TinTuc
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEnv.GetMsisdn();
                ltrWidth.Text = "<meta content=\"width=" + Width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            switch (Display)
            {
                case "list":
                    plContent.Controls.Add(LoadControl("UserControl/Category.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;
                case "search":
                    plContent.Controls.Add(LoadControl("UserControl/SearchResult.ascx"));
                    break;
                case "login":
                    plContent.Controls.Add(LoadControl("UserControl/Login.ascx"));
                    break;
            }
        }
    }
}
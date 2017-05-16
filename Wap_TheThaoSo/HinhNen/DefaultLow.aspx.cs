using System;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Constant;

namespace Wap_TheThaoSo.HinhNen
{
    public partial class DefaultLow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            if (!IsPostBack)
            {
                AppEnv.GetMsisdn();
                if (Width == 0)
                {
                    Width = (int)Constant.DefaultScreen.Standard;
                }
                if (Request.QueryString["lang"] == "1")
                {
                }
                ltrWidth.Text = "<meta content=\"width=" + Width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

            }
            switch (Display)
            {
                case "hinhnen":
                    plContent.Controls.Add(LoadControl("UserControlLow/HinhNen.ascx"));
                    break;
                case "hinhnenn":
                    plContent.Controls.Add(LoadControl("UserControlLow/HinhNen_New.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControlLow/HinhNenChiTiet.ascx"));
                    break;
                case "detailn":
                    plContent.Controls.Add(LoadControl("UserControlLow/HinhNenChiTiet_New.ascx"));
                    break;
                case "search":
                    plContent.Controls.Add(LoadControl("UserControlLow/SearchResult.ascx"));
                    break;
            }
        }
    }
}
using System;

namespace Wap_TheThaoSo.Wap.UserControl
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected string NameLink;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //    int lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
        //    int width = ConvertUtility.ToInt32(Request.QueryString["w"]);

        //    if(lang == 0)
        //    {
        //        lblName.Text = "Có dấu";
        //        NameLink = UrlProcess.GetHomeUrl("1", width.ToString());
        //    }
        //    else
        //    {
        //        lblName.Text = "Khong dau";
        //        NameLink = UrlProcess.GetHomeUrl("0", width.ToString());
        //    }

        //}
    }
}
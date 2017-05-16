using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.UrlProcess;

namespace Wap_TheThaoSo.Wap
{
    public partial class DangKy : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["msisdn"] = "841882406279";
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    Transaction.DangKyViSport(Session["msisdn"].ToString());
                }
            }
            //if (Session["msisdn"].ToString() != "Khách")
            //{
            //    Transaction.DangKyViSport(Session["msisdn"].ToString());
            //}
            Response.Redirect("/Default.aspx");
        }
    }
}
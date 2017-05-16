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
    public partial class Register_Visport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["msisdn"] = "841882406279";
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    Transaction.DangKyViSport_TP1(Session["msisdn"].ToString());
                }
            }

            Response.Redirect("/Video/Default.aspx?lang=0&display=video&w=320");
        }
    }
}
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
    public partial class DKKM : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["msisdn"] = "841883980154";
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    Transaction.DangKyViSportKM(Session["msisdn"].ToString());
                }
            }
            
            Response.Redirect("/Wap/Default.aspx");
        }
    }
}
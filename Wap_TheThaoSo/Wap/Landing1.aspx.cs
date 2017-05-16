using log4net;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.VnmCharging;

namespace Wap_TheThaoSo.Wap
{
    public partial class Landing1 : BasePage
    {
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msisdn"] == null)
            {
                AppEnv.GetMsisdnWithParam("6");
            }
            if (!Page.IsPostBack)
            {
                if (Session["msisdn"].ToString() == "Khách")
                {
                    Response.Redirect("http://visport.vn/Wap/Default.aspx?lang=1&w=320");
                }
            }

        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
        }

        protected void btn_DangKy_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://wap.vietnamobile.com.vn/sub/DK.aspx?id=813");
        }

        protected void btn_Huy_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://wap.vietnamobile.com.vn");
        }
    }
}
using log4net;
using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap
{
    public partial class CauHoi_TheLe : BasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("http://visport.vn");
            if (!Page.IsPostBack)
            {
                
            }
        }

    
    }
}
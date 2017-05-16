using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wap_TheThaoSo.Wap.UserControlLow
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected string RawUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            RawUrl = HttpContext.Current.Request.RawUrl;
        }
    }
}
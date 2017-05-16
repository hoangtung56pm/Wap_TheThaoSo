using System;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.Wap
{
    public partial class DefaultLow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                AppEnv.GetMsisdn();
            }
        }
    }
}
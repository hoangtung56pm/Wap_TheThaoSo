using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class ChiTietCauThu : System.Web.UI.UserControl
    {

        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            int catId = ConvertUtility.ToInt32(Request.QueryString["catId"]);

            if (id > 0 && catId > 0)
            {
                DataTable dt = _duLieuController.WapTheThaoSoGetPlayerInfo(catId, id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptPlayerInfo.DataSource = dt;
                    rptPlayerInfo.DataBind();
                }
            }

        }
    }
}
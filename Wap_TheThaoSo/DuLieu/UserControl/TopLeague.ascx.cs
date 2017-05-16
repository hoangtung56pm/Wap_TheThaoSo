using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.UrlProcess;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class TopLeague : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected string DsGiaiDauLink;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            //base.OnPreRender(e);

            //DsGiaiDauLink = UrlProcess.GetDanhSachGiaiDau();

            //DataTable dt = _duLieuController.WapTheThaoSoGetAllLeagues();
            //if(dt != null && dt.Rows.Count > 0)
            //{
            //    rptTopLeague.DataSource = dt;
            //    rptTopLeague.DataBind();
            //}
            base.OnPreRender(e);

            DsGiaiDauLink = UrlProcess.GetDanhSachGiaiDau();

            DataTable dt = _duLieuController.WapTheThaoSoGetAllLeagues();
            if (dt != null && dt.Rows.Count > 0)
            {
                rptTopLeague.DataSource = dt;
                rptTopLeague.DataBind();
            }
        }

    }
}
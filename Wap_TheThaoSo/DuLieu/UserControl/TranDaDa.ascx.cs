using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class TranDaDa : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //DataTable dt = _duLieuController.WapTheThaoSoGetCompetition(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played));
            DataSet dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played));
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                rptParent.DataSource = dt;
                rptParent.ItemDataBound += rptParent_ItemDataBound;
                rptParent.DataBind();
            }

        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
            var currData = (DataRowView)e.Item.DataItem;

            int competitionId = ConvertUtility.ToInt32(currData["Id"]);

            DataTable dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played)).Tables[1];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] drM = dt.Select(" competition_id = " + competitionId + " ");
                rptMenuLevel2.DataSource = drM.CopyToDataTable();
                rptMenuLevel2.DataBind();
            }

            //DataSet ds = _duLieuController.WapTheThaoSoGetSchedulesLive(ConvertUtility.ToInt32(currData["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played), 1, 20);
            //if(ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    rptMenuLevel2.DataSource = ds.Tables[0];
            //    rptMenuLevel2.DataBind();
            //}
        }
    }
}
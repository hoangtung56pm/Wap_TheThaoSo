using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class TranDangDa : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //DataTable dt = _duLieuController.WapTheThaoSoGetCompetitionPlaying(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing));
            DataSet dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing));
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                rptParent.DataSource = dt;
                rptParent.ItemDataBound += rptParent_ItemDataBound;
                rptParent.DataBind();
            }
            else
            {
                divThongBao.Visible = true;
            }
        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
            var currData = (DataRowView)e.Item.DataItem;

            int competitionId = ConvertUtility.ToInt32(currData["Id"]);
            DataTable dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing)).Tables[1];

            //DataSet ds = _duLieuController.WapTheThaoSoGetSchedulesLivePlaying(ConvertUtility.ToInt32(currData["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing), 1, 20);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] drM = dt.Select(" competition_id = " + competitionId + " ");

                rptMenuLevel2.DataSource = drM.CopyToDataTable();
                rptMenuLevel2.ItemDataBound += rptChild_ItemDataBound;
                rptMenuLevel2.DataBind();
            }
        }

        void rptChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var litIconXanh = (Literal)e.Item.FindControl("litIconXanh");
            var currData = (DataRowView)e.Item.DataItem;

            if (currData["match_status"] != null)
            {
                if (currData["match_status"].ToString().ToLower() == "playing")
                {
                    litIconXanh.Text = "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
                }
            }

        }
        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    DataTable dt = _duLieuController.WapTheThaoSoGetCompetitionPlaying(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing));
        //    if (dt != null)
        //    {
        //        rptParent.DataSource = dt;
        //        rptParent.ItemDataBound += rptParent_ItemDataBound;
        //        rptParent.DataBind();
        //    }
        //    else
        //    {
        //        divThongBao.Visible = true;
        //    }
        //}

        //void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex < 0) return;

        //    var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
        //    var currData = (DataRowView)e.Item.DataItem;

        //    DataSet ds = _duLieuController.WapTheThaoSoGetSchedulesLivePlaying(ConvertUtility.ToInt32(currData["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Playing), 1, 20);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        rptMenuLevel2.DataSource = ds.Tables[0];
        //        rptMenuLevel2.ItemDataBound += rptChild_ItemDataBound;
        //        rptMenuLevel2.DataBind();
        //    }
        //}

        //void rptChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex < 0) return;

        //    var litIconXanh = (Literal)e.Item.FindControl("litIconXanh");
        //    var currData = (DataRowView)e.Item.DataItem;

        //   if (currData["Match_Period"].ToString() != "HT")
        //   {
        //       litIconXanh.Text = "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
        //   }
        //}

    }
}
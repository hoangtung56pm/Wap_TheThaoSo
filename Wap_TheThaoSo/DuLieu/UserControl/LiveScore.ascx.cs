using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class LiveScore : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //DataTable dt = _duLieuController.WapTheThaoSoGetCompetitionLiveScore();
            DataSet dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.AllMatch));
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                rptParent.DataSource = dt;
                rptParent.ItemDataBound += rptParent_ItemDataBound;
                rptParent.DataBind();
            }

            //DataTable dtFocusMatchs = _duLieuController.WapTheThaoSoGetMatchLiveScoreFocus();
            //if (dtFocusMatchs != null && dtFocusMatchs.Rows.Count > 0)
            //{
            //    pnlTranCauTamDiem.Visible = true;
            //}
        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
            var currData = (DataRowView)e.Item.DataItem;

            int competitionId = ConvertUtility.ToInt32(currData["Id"]);
            DataTable dt = _duLieuController.ApiTtsGetSchedulesMatch(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.AllMatch)).Tables[1];

            //DataTable dt = _duLieuController.WapTheThaoSoGetMatchLiveScore(ConvertUtility.ToInt32(currData["Id"]));
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

            if (currData["match_status"].ToString() == "Fixture")
            {
                litIconXanh.Text = ConvertUtility.ToDateTime(currData["match_day"]).ToString("dd/MM") + " " + currData["match_time"].ToString().Substring(0, 5);
            }
            else if (currData["match_status"].ToString() == "Played")
            {
                litIconXanh.Text = "FT";
            }
            else if (currData["match_status"].ToString() == "Playing")
            {

                litIconXanh.Text = currData["game_minute"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";

                //if (currData["Match_Period"].ToString() == "HT")
                //{
                //    litIconXanh.Text = "HT";
                //}
                //else if (!string.IsNullOrEmpty(currData["Minute_Extra"].ToString()))
                //{
                //    litIconXanh.Text = currData["Minute"] + "+" + currData["Minute_Extra"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
                //}
                //else
                //{
                //    litIconXanh.Text = currData["Minute"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
                //}
            }
            else if (currData["match_status"].ToString() == "Break")
            {
                litIconXanh.Text = "HT";
            }
            else if (currData["match_status"].ToString() == "Cancelled")
            {
                litIconXanh.Text = "Hủy";
            }
            else if (currData["match_status"].ToString() == "Postponed")
            {
                litIconXanh.Text = "Hoãn";
            }
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    DataTable dt = _duLieuController.WapTheThaoSoGetCompetitionLiveScore();
        //    if (dt != null)
        //    {
        //        rptParent.DataSource = dt;
        //        rptParent.ItemDataBound += rptParent_ItemDataBound;
        //        rptParent.DataBind();
        //    }

        //    DataTable dtHotMatch = _duLieuController.WapTheThaoSoGetMatchLiveScoreFocus();
        //    if (dtHotMatch != null && dtHotMatch.Rows.Count > 0)
        //    {
        //        pnlHotMatch.Visible = true;

        //        rptHotMatch.DataSource = dtHotMatch;
        //        rptHotMatch.ItemDataBound += rptChild_ItemDataBound;
        //        rptHotMatch.DataBind();
        //    }
        //    else
        //    {
        //        pnlHotMatch.Visible = false;
        //    }
        //}

        //void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex < 0) return;

        //    var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
        //    var currData = (DataRowView)e.Item.DataItem;

        //    DataTable dt = _duLieuController.WapTheThaoSoGetMatchLiveScore(ConvertUtility.ToInt32(currData["Id"]));
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        rptMenuLevel2.DataSource = dt;
        //        rptMenuLevel2.ItemDataBound += rptChild_ItemDataBound;
        //        rptMenuLevel2.DataBind();
        //    }
        //}

        //void rptChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex < 0) return;

        //    var litIconXanh = (Literal)e.Item.FindControl("litIconXanh");
        //    var currData = (DataRowView)e.Item.DataItem;

        //    if (currData["Status"].ToString() == "Fixture")
        //    {
        //        litIconXanh.Text = AppEnv.ConvertTime(currData["TimeDay"].ToString()) + "/" +
        //                           AppEnv.ConvertTime(currData["TimeMonth"].ToString()) + " " +
        //                           AppEnv.ConvertTime(currData["TimeHour"].ToString()) + ":" +
        //                           AppEnv.ConvertTime(currData["TimeMinute"].ToString());
        //    }
        //    else if (currData["Status"].ToString() == "Played")
        //    {
        //        litIconXanh.Text = "FT";
        //    }
        //    else if(currData["Status"].ToString() == "Playing")
        //    {
        //        if (currData["Match_Period"].ToString() == "HT")
        //        {
        //            litIconXanh.Text = "HT";
        //        }
        //        else if (!string.IsNullOrEmpty(currData["Minute_Extra"].ToString()))
        //        {
        //            litIconXanh.Text = currData["Minute"] + "+" + currData["Minute_Extra"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
        //        }
        //        else
        //        {
        //            litIconXanh.Text = currData["Minute"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
        //        }
        //    }
        //    else if (currData["Status"].ToString() == "Cancelled")
        //    {
        //        litIconXanh.Text = "Hủy";
        //    }
        //    else if (currData["Status"].ToString() == "Postponed")
        //    {
        //        litIconXanh.Text = "Hoãn";
        //    }
        //}

        //#region Public method
        
       

        //#endregion
    }
}
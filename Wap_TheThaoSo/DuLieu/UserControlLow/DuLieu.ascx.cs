using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class DuLieu : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = _duLieuController.WapTheThaoSoGetCompetition(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Fixture));
            if (dt != null && dt.Rows.Count > 0)
            {
                //IList<DataRow> competitionList = new List<DataRow>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    IList<DataRow> matchList = _duLieuController.WapTheThaoSoGetSchedulesLive(ConvertUtility.ToInt32(dr["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Fixture), 1, 20)
                //                    .Tables[0].Select("Team_A_Code <> '' AND Team_B_Code <> '' ").ToList();

                //    if (matchList.Count > 0)
                //    {
                //        competitionList.Add(dr);
                //    }
                //}

                //if(competitionList.Count > 0)
                //{
                    rptParent.DataSource = dt;
                    rptParent.ItemDataBound += rptParent_ItemDataBound;
                    rptParent.DataBind();
                //}
            }

            DataTable dtHotMatch = _duLieuController.WapTheThaoSoGetMatchLiveScoreFocus();
            if (dtHotMatch != null && dtHotMatch.Rows.Count > 0)
            {
                pnlHotMatch.Visible = true;

                rptHotMatch.DataSource = dtHotMatch;
                rptHotMatch.ItemDataBound += rptHotMatch_ItemDataBound;
                rptHotMatch.DataBind();
            }
            else
            {
                pnlHotMatch.Visible = false;
            }

        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
            var currData = (DataRowView)e.Item.DataItem;

            DataSet ds = _duLieuController.WapTheThaoSoGetSchedulesLive(ConvertUtility.ToInt32(currData["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Fixture), 1, 20);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //IList<DataRow> dtList = ds.Tables[0].Select("Team_A_Code <> '' AND Team_B_Code <> '' ").ToList();
                //if(dtList.Count > 0)
                //{
                    rptMenuLevel2.DataSource = ds.Tables[0];
                    rptMenuLevel2.DataBind();
                //}
            }
        }

        void rptHotMatch_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var litIconXanh = (Literal)e.Item.FindControl("litIconXanh");
            var currData = (DataRowView)e.Item.DataItem;

            if (currData["Status"].ToString() == "Fixture")
            {
                litIconXanh.Text = AppEnv.ConvertTime(currData["TimeDay"].ToString()) + "/" +
                                   AppEnv.ConvertTime(currData["TimeMonth"].ToString()) + " " +
                                   AppEnv.ConvertTime(currData["TimeHour"].ToString()) + ":" +
                                   AppEnv.ConvertTime(currData["TimeMinute"].ToString());
            }
            else if (currData["Status"].ToString() == "Played")
            {
                litIconXanh.Text = "FT";
            }
            else if (currData["Status"].ToString() == "Playing")
            {
                if (currData["Match_Period"].ToString() == "HT")
                {
                    litIconXanh.Text = "HT";
                }
                else if (!string.IsNullOrEmpty(currData["Minute_Extra"].ToString()))
                {
                    litIconXanh.Text = currData["Minute"] + "+" + currData["Minute_Extra"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
                }
                else
                {
                    litIconXanh.Text = currData["Minute"] + "'<img alt=\"\" class=\"margin-top3px\" src=\"/layout/images/icon-xanh.png\" />";
                }
            }
            else if (currData["Status"].ToString() == "Cancelled")
            {
                litIconXanh.Text = "Hủy";
            }
            else if (currData["Status"].ToString() == "Postponed")
            {
                litIconXanh.Text = "Hoãn";
            }
        }

    }
}
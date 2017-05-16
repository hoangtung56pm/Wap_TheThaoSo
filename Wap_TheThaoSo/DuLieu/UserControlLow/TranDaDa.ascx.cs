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
    public partial class TranDaDa : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = _duLieuController.WapTheThaoSoGetCompetition(ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played));
            if (dt != null && dt.Rows.Count > 0)
            {
                //IList<DataRow> competitionList = new List<DataRow>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    IList<DataRow> matchList = _duLieuController.WapTheThaoSoGetSchedulesLive(ConvertUtility.ToInt32(dr["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played), 1, 20).Tables[0].Select("Team_A_Code <> '' AND Team_B_Code <> '' ").ToList();

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

        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");
            var currData = (DataRowView)e.Item.DataItem;

            DataSet ds = _duLieuController.WapTheThaoSoGetSchedulesLive(ConvertUtility.ToInt32(currData["Id"]), ConvertUtility.ToInt32(AppEnv.CompetetionStatus.Played), 1, 20);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //IList<DataRow> matchList = ds.Tables[0].Select("Team_A_Code <> '' AND Team_B_Code <> '' ").ToList();
                //if(matchList.Count > 0)
                //{
                    rptMenuLevel2.DataSource = ds.Tables[0];
                    rptMenuLevel2.DataBind();
                //}
            }
        }
    }
}
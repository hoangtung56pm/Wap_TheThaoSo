using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow.Bonus
{
    public partial class ChiTietTranDau : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected string TeamA;
        protected string TeamB;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoPhongDo(id);
                if (ds != null)
                {
                    rptTeamInfo.DataSource = ds.Tables[0];
                    rptTeamInfo.DataBind();

                    TeamA = ds.Tables[0].Rows[0]["Team_A_Name"].ToString();
                    TeamB = ds.Tables[0].Rows[0]["Team_B_Name"].ToString();

                    rptInfoLink.DataSource = ds.Tables[0];
                    rptInfoLink.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        rptTeamA.DataSource = ds.Tables[1];
                        rptTeamA.DataBind();
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        rptTeamB.DataSource = ds.Tables[2];
                        rptTeamB.DataBind();
                    }
                }
            }
        }
    }
}
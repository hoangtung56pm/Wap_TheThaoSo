using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class ChiTietTranDau_TyLe : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchOdd(id);
                if (ds != null)
                {
                    string status = string.Empty;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptTeamInfo.DataSource = ds.Tables[0];
                        rptTeamInfo.DataBind();

                        rptInfoLink.DataSource = ds.Tables[0];
                        rptInfoLink.DataBind();

                        status = ds.Tables[0].Rows[0]["Status"].ToString();
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        rptTyle.DataSource = ds.Tables[1];
                        rptTyle.DataBind();

                        if (!string.IsNullOrEmpty(status) && status != "Played")
                        {
                            rptUpdateDate.DataSource = ds.Tables[1];
                            rptUpdateDate.DataBind();
                        }
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        rptTaixiu.DataSource = ds.Tables[2];
                        rptTaixiu.DataBind();
                    }
                }
            }
        }
    }
}
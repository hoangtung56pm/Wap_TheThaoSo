using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class DanhSachGiaiDau_ChiTiet : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected string DsGiaiDauLink;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                int areaId = ConvertUtility.ToInt32(Request.QueryString["ar"]);

                if (id > 0)
                {
                    DataTable dt;

                    int selected = areaId;

                    if (id == 2)
                    {
                        lblName.Text = "Vô địch quốc gia và cúp Quốc gia";
                        dt = _duLieuController.WapTheThaoSoGetAllCountry();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dgrCategory.Items.Clear();
                            dgrCategory.DataSource = dt;
                            dgrCategory.DataTextField = "Name";
                            dgrCategory.DataValueField = "Id";
                            dgrCategory.DataBind();

                            if (selected > 0)
                                dgrCategory.SelectedValue = selected.ToString();
                            else
                                dgrCategory.SelectedValue = ConvertUtility.ToString(AppEnv.GetSetting("England"));
                        }
                    }
                    else if (id == 1)
                    {
                        lblName.Text = "Châu lục";
                        dt = _duLieuController.WapTheThaoSoGetAreaByParentId(1);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dgrCategory.Items.Clear();
                            dgrCategory.DataSource = dt;
                            dgrCategory.DataTextField = "Name";
                            dgrCategory.DataValueField = "Id";
                            dgrCategory.DataBind();

                            if (selected > 0)
                                dgrCategory.SelectedValue = selected.ToString();
                            else
                                dgrCategory.SelectedValue = ConvertUtility.ToString(AppEnv.GetSetting("Asia"));
                        }
                    }
                    else if (id == 3)
                    {
                        lblName.Text = "Thế giới";
                        dt = _duLieuController.WapTheThaoSoGetAreaByParentId(0);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dgrCategory.Items.Clear();
                            dgrCategory.DataSource = dt;
                            dgrCategory.DataTextField = "Name";
                            dgrCategory.DataValueField = "Id";
                            dgrCategory.DataBind();
                        }
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DsGiaiDauLink = UrlProcess.GetDanhSachGiaiDauLow();

            int catId = ConvertUtility.ToInt32(dgrCategory.SelectedValue);
            if (catId > 0)
            {
                DataTable dtLeague = _duLieuController.WapTheThaoSoGetCompetitionByAreaId(catId);
                if (dtLeague != null && dtLeague.Rows.Count > 0)
                {
                    rptLeague.DataSource = dtLeague;
                    rptLeague.DataBind();
                }
            }
        }

        protected void dgrCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            int areaId = ConvertUtility.ToInt32(dgrCategory.SelectedValue);
            string url = UrlProcess.GetDanhSachGiaiDauChiTietLow(id) + "&ar=" + areaId;

            Response.Redirect(url);
        }
    }
}
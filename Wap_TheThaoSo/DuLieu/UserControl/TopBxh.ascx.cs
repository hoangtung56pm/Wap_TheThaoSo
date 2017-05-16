using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class TopBxh : BaseControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected string BxhLink;
        protected string TopGhiBanLink;
        protected string CalendarLink;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                if (catid > 0)
                {
                    //DataTable dtYear = _duLieuController.WapTheThaoSoGetSeasonYear(catid);
                    //if (dtYear != null)
                    //{
                    //    dgrSeason.DataSource = dtYear;
                    //    dgrSeason.DataTextField = "Name";
                    //    dgrSeason.DataValueField = "Id";
                    //    dgrSeason.DataBind();

                    //    if(!string.IsNullOrEmpty(Request.QueryString["seasonId"]))
                    //    {
                    //        dgrSeason.SelectedValue = Request.QueryString["seasonId"];
                    //    }
                    //}

                    DataTable dtYear = _duLieuController.WapTheThaoSoGetSeasonYear(catid);
                    if (dtYear != null)
                    {
                        dgrSeason.DataSource = dtYear;
                        dgrSeason.DataTextField = "title";
                        dgrSeason.DataValueField = "season_id";
                        dgrSeason.DataBind();

                        if (!string.IsNullOrEmpty(Request.QueryString["seasonId"]))
                        {
                            dgrSeason.SelectedValue = Request.QueryString["seasonId"];
                        }
                    }

                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int seasonId = ConvertUtility.ToInt32(dgrSeason.SelectedValue);
            int competitionId = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (competitionId > 0)
            {
                BxhLink = UrlProcess.GetTopBxhUrl(competitionId) + "&seasonId=" + seasonId;
                TopGhiBanLink = UrlProcess.GetTopGhiBanUrl(competitionId) + "&seasonId=" + seasonId;
                CalendarLink = UrlProcess.GetLichThiDau(competitionId) + "&seasonId=" + seasonId;

                DataSet ds = _duLieuController.WapTheThaoSoGetBxhByCompetitionAndSeason(competitionId, seasonId);
                if (ds != null)
                {

                    #region Tran Cau Sang Nhat

                    //Tran Cau Sang Nhat cho Cac Giai Chinh

                    //if (competitionId == 8) // Anh
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=8F100B80-CDC2-4983-A20A-95E6D05392BA";
                    //}
                    //else if (competitionId == 7) // Tay Ban Nha
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D49D7438-863E-432F-BB55-37B5CE7916E0";
                    //}
                    //else if (competitionId == 13) // Italia
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D73803EA-CC9F-42A3-B0BC-1CC80EFE1E74";
                    //}
                    //else if (competitionId == 9) // Duc
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=2D08173B-7221-4C73-A783-4505F1C5A63B";
                    //}
                    //else if (competitionId == 16) // Phap
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=4519653E-F1A6-4DA7-84B8-56E352C58C1B";
                    //}
                    //else if (competitionId == 10) // C1
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=F6F9038B-EE68-4E50-BF50-91C8308B3044";
                    //}
                    //else if (competitionId == 18) // Europa league
                    //{
                    //    divTranCauSangNhat.Visible = true;
                    //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=B2172860-8127-4A94-9CCE-66DA9B04B62B";
                    //}

                    //End Tran Cau Sang Nhat cho Cac Giai Chinh

                    #endregion

                    rptInfo.DataSource = ds.Tables[0];
                    rptInfo.DataBind();

                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        rptBxh.DataSource = ds.Tables[1];
                        rptBxh.DataBind();
                    }
                }
            }
        }

        protected void dgrSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class Calendar : BaseControl
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

            int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (catid > 0)
            {
                LoadData(catid);
            }


            //int competitionId = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            //int seasonId = ConvertUtility.ToInt32(dgrSeason.SelectedValue);

            //DataTable dtYear = _duLieuController.WapTheThaoSoGetSeasonYear(competitionId);
            //int preSeasonId = 0;
            //preSeasonId = ConvertUtility.ToInt32(dtYear.Rows[1]["Id"]);

            //DataTable dtCurrentRound;
            //DataSet dataSet = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId);
            //if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            //{
            //    dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId).Tables[1];
            //}
            //else
            //{
            //    seasonId = preSeasonId;
            //    dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId).Tables[1];
            //}

            //string week = dgrWeek.SelectedValue;

            //if(dtCurrentRound != null && dtCurrentRound.Rows.Count > 0)
            //{
            //    if (week == "0")
            //        week = dtCurrentRound.Rows[0]["CurrentRound"].ToString();
            //}

            //if(competitionId > 0)
            //{
            //    BxhLink = UrlProcess.GetTopBxhUrl(competitionId) + "&seasonId=" + seasonId;
            //    TopGhiBanLink = UrlProcess.GetTopGhiBanUrl(competitionId) + "&seasonId=" + seasonId;
            //    CalendarLink = UrlProcess.GetLichThiDau(competitionId) + "&seasonId=" + seasonId;

            //    DataSet ds = _duLieuController.WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek(competitionId,
            //                                                                                            seasonId, week);
            //    if(ds != null)
            //    {

            //        #region Tran Cau Sang Nhat

            //        //Tran Cau Sang Nhat cho Cac Giai Chinh

            //        if (competitionId == 8) // Anh
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=8F100B80-CDC2-4983-A20A-95E6D05392BA";
            //        }
            //        else if (competitionId == 7) // Tay Ban Nha
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D49D7438-863E-432F-BB55-37B5CE7916E0";
            //        }
            //        else if (competitionId == 13) // Italia
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D73803EA-CC9F-42A3-B0BC-1CC80EFE1E74";
            //        }
            //        else if (competitionId == 9) // Duc
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=2D08173B-7221-4C73-A783-4505F1C5A63B";
            //        }
            //        else if (competitionId == 16) // Phap
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=4519653E-F1A6-4DA7-84B8-56E352C58C1B";
            //        }
            //        else if (competitionId == 10) // C1
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=F6F9038B-EE68-4E50-BF50-91C8308B3044";
            //        }
            //        else if (competitionId == 18) // Europa league
            //        {
            //            divTranCauSangNhat.Visible = true;
            //            litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //            lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=B2172860-8127-4A94-9CCE-66DA9B04B62B";
            //        }

            //        //End Tran Cau Sang Nhat cho Cac Giai Chinh

            //        #endregion

            //        rptInfo.DataSource = ds.Tables[0];
            //        rptInfo.DataBind();

            //        if(ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            //        {
            //            rptChild.DataSource = ds.Tables[1];
            //            rptChild.DataBind();
            //        }
            //    }
            //}

        }

        protected void dgrSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            string seasonId = dgrSeason.SelectedValue;

            string url = UrlProcess.GetLichThiDau(catid) + "&seasonId=" + seasonId;
            Response.Redirect(url);
        }

        protected void dgrWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            string seasonId = dgrSeason.SelectedValue;
            string url;
            string round = dgrWeek.SelectedValue;
            if (!string.IsNullOrEmpty(round))
            {
                url = UrlProcess.GetLichThiDau(catid) + "&seasonId=" + seasonId + "&r=" + round;
            }
            else
            {
                url = UrlProcess.GetLichThiDau(catid) + "&seasonId=" + seasonId;
            }

            Response.Redirect(url);
        }

        public void LoadData(int catid)
        {
            int seasonId = ConvertUtility.ToInt32(dgrSeason.SelectedValue);
            DataSet dataSet = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId);
            if (dataSet != null)
            {
                DataTable dt = dataSet.Tables[0];
                DataTable dtcuRound = dataSet.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    dgrWeek.Items.Clear();
                    dgrWeek.Items.Add(new ListItem("--Chọn vòng--", "0"));
                    dgrWeek.AppendDataBoundItems = true;


                    dgrWeek.DataSource = dt;
                    dgrWeek.DataTextField = "round_name";
                    dgrWeek.DataValueField = "round_id";
                    dgrWeek.DataBind();

                    int round = ConvertUtility.ToInt32(Request.QueryString["r"]);
                    if (round > 0)
                    {
                        dgrWeek.SelectedValue = round.ToString();
                    }
                    else
                    {
                        if (dtcuRound.Rows.Count > 0)
                        {
                            string r = ConvertUtility.ToString(dtcuRound.Rows[0]["current_round"]);
                            if (!string.IsNullOrEmpty(r))
                            {
                                dgrWeek.SelectedValue = r;
                            }
                            else
                            {
                                dgrWeek.SelectedIndex = dgrWeek.Items.Count - 1;
                            }
                        }
                    }

                }
                else
                {
                    dgrWeek.Visible = false;
                }

                BxhLink = UrlProcess.GetTopBxhUrl(catid) + "&seasonId=" + seasonId;
                TopGhiBanLink = UrlProcess.GetTopGhiBanUrl(catid) + "&seasonId=" + seasonId;
                CalendarLink = UrlProcess.GetLichThiDau(catid) + "&seasonId=" + seasonId;

            }

            DataSet dtMaches = _duLieuController.ApiTtsGetCompetitionCalendar(catid, seasonId, ConvertUtility.ToInt32(dgrWeek.SelectedValue));
            DataTable dtLeague = dtMaches.Tables[0];
            DataTable dtMatch = dtMaches.Tables[1];
            if (dtMatch.Rows.Count > 0)
            {
                rptChild.DataSource = dtMatch;
                rptChild.DataBind();

                rptInfo.DataSource = dtLeague;
                rptInfo.DataBind();

            }
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
        //        int preSeasonId = 0;

        //        if (catid > 0)
        //        {
        //            DataTable dtYear = _duLieuController.WapTheThaoSoGetSeasonYear(catid);
        //            if (dtYear != null)
        //            {
        //                dgrSeason.DataSource = dtYear;
        //                dgrSeason.DataTextField = "Name";
        //                dgrSeason.DataValueField = "Id";
        //                dgrSeason.DataBind();

        //                if (!string.IsNullOrEmpty(Request.QueryString["seasonId"]))
        //                {
        //                    dgrSeason.SelectedValue = Request.QueryString["seasonId"];
        //                }

        //                preSeasonId = ConvertUtility.ToInt32(dtYear.Rows[1]["Id"]);
        //            }

        //            int seasonId = ConvertUtility.ToInt32(dgrSeason.SelectedValue);


        //            DataTable dtWeek;
        //            DataTable dtCurrentRound;

        //            //dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId).Tables[1];

        //            DataSet dataSet = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId);
        //            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
        //            {
        //                dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId).Tables[1];
        //            }
        //            else
        //            {
        //                seasonId = preSeasonId;
        //                dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId).Tables[1];
        //            }

        //            string selected = string.Empty;
        //            if (dtCurrentRound != null && dtCurrentRound.Rows.Count > 0)
        //                selected = !string.IsNullOrEmpty(dtCurrentRound.Rows[0]["CurrentRound"].ToString()) ? dtCurrentRound.Rows[0]["CurrentRound"].ToString() : dtCurrentRound.Rows[0]["Parent_Round_ID"].ToString();

        //            //if (dtCurrentRound != null && !string.IsNullOrEmpty(dtCurrentRound.Rows[0]["CurrentRound"].ToString()))
        //            if (dtCurrentRound != null && dtCurrentRound.Rows.Count > 0)
        //            {
        //                dtWeek = _duLieuController.WapTheThaoSoGetCompetitionWeek(catid, seasonId).Tables[0];
        //                if (dtWeek != null && dtWeek.Rows.Count > 0)
        //                {
        //                    dgrWeek.Items.Clear();
        //                    dgrWeek.Items.Add(new ListItem("--Chọn vòng--", "0"));
        //                    dgrWeek.AppendDataBoundItems = true;


        //                    dgrWeek.DataSource = dtWeek;
        //                    dgrWeek.DataTextField = "GameWeekName";
        //                    dgrWeek.DataValueField = "GameWeekId";
        //                    dgrWeek.DataBind();
        //                }
        //                else
        //                {
        //                    dgrWeek.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                dtWeek = _duLieuController.WapTheThaoSoGetCompetitionCalendar(catid, seasonId);
        //                if (dtWeek != null && dtWeek.Rows.Count > 0)
        //                {
        //                    dgrWeek.Items.Clear();
        //                    dgrWeek.Items.Add(new ListItem("--Chọn vòng--", "0"));
        //                    dgrWeek.AppendDataBoundItems = true;


        //                    dgrWeek.DataSource = dtWeek;
        //                    dgrWeek.DataTextField = "Name";
        //                    dgrWeek.DataValueField = "Id";
        //                    dgrWeek.DataBind();
        //                }
        //                else
        //                {
        //                    dgrWeek.Visible = false;
        //                }
        //            }

        //            if (catid == 72)
        //                dgrWeek.SelectedValue = "12929";
        //            else
        //                dgrWeek.SelectedValue = selected;
        //        }
        //    }
        //}

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);



        //    int competitionId = ConvertUtility.ToInt32(Request.QueryString["catid"]);
        //    int seasonId = ConvertUtility.ToInt32(dgrSeason.SelectedValue);

        //    DataTable dtYear = _duLieuController.WapTheThaoSoGetSeasonYear(competitionId);
        //    int preSeasonId = 0;
        //    preSeasonId = ConvertUtility.ToInt32(dtYear.Rows[1]["Id"]);

        //    //DataTable dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId).Tables[1];

        //    DataTable dtCurrentRound;
        //    DataSet dataSet = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId);
        //    if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId).Tables[1];
        //    }
        //    else
        //    {
        //        seasonId = preSeasonId;
        //        dtCurrentRound = _duLieuController.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId).Tables[1];
        //    }

        //    string week = dgrWeek.SelectedValue;

        //    if (dtCurrentRound != null && dtCurrentRound.Rows.Count > 0)
        //    {
        //        if (week == "0")
        //            week = dtCurrentRound.Rows[0]["CurrentRound"].ToString();
        //    }

        //    if (competitionId > 0)
        //    {
        //        BxhLink = UrlProcess.GetTopBxhUrl(competitionId) + "&seasonId=" + seasonId;
        //        TopGhiBanLink = UrlProcess.GetTopGhiBanUrl(competitionId) + "&seasonId=" + seasonId;
        //        CalendarLink = UrlProcess.GetLichThiDau(competitionId) + "&seasonId=" + seasonId;

        //        DataSet ds = _duLieuController.WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek(competitionId,
        //                                                                                                seasonId, week);
        //        if (ds != null)
        //        {

        //            //#region Tran Cau Sang Nhat

        //            ////Tran Cau Sang Nhat cho Cac Giai Chinh

        //            //if (competitionId == 8) // Anh
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=8F100B80-CDC2-4983-A20A-95E6D05392BA";
        //            //}
        //            //else if (competitionId == 7) // Tay Ban Nha
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D49D7438-863E-432F-BB55-37B5CE7916E0";
        //            //}
        //            //else if (competitionId == 13) // Italia
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=D73803EA-CC9F-42A3-B0BC-1CC80EFE1E74";
        //            //}
        //            //else if (competitionId == 9) // Duc
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=2D08173B-7221-4C73-A783-4505F1C5A63B";
        //            //}
        //            //else if (competitionId == 16) // Phap
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=4519653E-F1A6-4DA7-84B8-56E352C58C1B";
        //            //}
        //            //else if (competitionId == 10) // C1
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=F6F9038B-EE68-4E50-BF50-91C8308B3044";
        //            //}
        //            //else if (competitionId == 18) // Europa league
        //            //{
        //            //    divTranCauSangNhat.Visible = true;
        //            //    litName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //            //    lnkBamDay.NavigateUrl = "/DuLieu/Default.aspx?display=tuvan&w=" + Lang + "&id=B2172860-8127-4A94-9CCE-66DA9B04B62B";
        //            //}

        //            ////End Tran Cau Sang Nhat cho Cac Giai Chinh

        //            //#endregion

        //            rptInfo.DataSource = ds.Tables[0];
        //            rptInfo.DataBind();

        //            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        //            {
        //                rptChild.DataSource = ds.Tables[1];
        //                rptChild.DataBind();
        //            }
        //        }
        //    }

        //}


        //protected void dgrSeason_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
        //    string seasonId = dgrSeason.SelectedValue;

        //    string url = UrlProcess.GetLichThiDau(catid) + "&seasonId=" + seasonId;
        //    Response.Redirect(url);
        //}

        //protected void dgrWeek_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

    }
}
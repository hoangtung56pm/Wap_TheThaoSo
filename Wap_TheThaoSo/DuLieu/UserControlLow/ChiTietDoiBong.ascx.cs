using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class ChiTietDoiBong : BaseControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected string Coach;

        private const int PageSize = 5;
        private const int PageNumber = 5;
        private int _curpageMatch = 1;
        private int _curpageNews = 1;
        private int _curpageVideo = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mpage"]))
                    _curpageMatch = ConvertUtility.ToInt32(Request.QueryString["mpage"]);
                else if (!string.IsNullOrEmpty(Request.QueryString["npage"]))
                    _curpageNews = ConvertUtility.ToInt32(Request.QueryString["npage"]);
                else if (!string.IsNullOrEmpty(Request.QueryString["vpage"]))
                    _curpageVideo = ConvertUtility.ToInt32(Request.QueryString["vpage"]);

                DataSet ds = _duLieuController.WapTheThaoSoGetTeamInfo(id);

                DataSet dsLastestMatch = _duLieuController.WapTheThaoSoGetTeamLastestMatch(id, _curpageMatch, PageSize);

                DataSet dsNews = _duLieuController.WapTheThaoSoGetTeamLastestNews(id, _curpageNews, PageSize);

                DataSet dsVideoId = _duLieuController.WapTheThaoSoGetTeamInfoLastestVideoId(id, _curpageVideo, PageSize);

                if (ds != null)
                {
                    rptTeamInfo.DataSource = ds.Tables[0];
                    rptTeamInfo.DataBind();

                    try
                    {
                        Coach = ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Name"].ToString();
                    }
                    catch (Exception)
                    {
                        Coach = "";
                    }
                    
                    DataSet dsDoiHinh = ConvertUtility.SplitDataTable(ds.Tables[1], 50);

                    DataRow[] lstGoalkeeper = dsDoiHinh.Tables[0].Select("Position = 'Goalkeeper'");
                    if (lstGoalkeeper.Length > 0)
                    {
                        rptGoalkeeper.DataSource = lstGoalkeeper.CopyToDataTable();
                        rptGoalkeeper.DataBind();
                    }

                    DataRow[] lstDefender = dsDoiHinh.Tables[0].Select("Position = 'Defender'");
                    if (lstDefender.Length > 0)
                    {
                        rptDefender.DataSource = lstDefender.CopyToDataTable();
                        rptDefender.DataBind();
                    }

                    DataRow[] lstMidfielder = dsDoiHinh.Tables[0].Select("Position = 'Midfielder'");
                    if (lstMidfielder.Length > 0)
                    {
                        rptMidfielder.DataSource = lstMidfielder.CopyToDataTable();
                        rptMidfielder.DataBind();
                    }

                    DataRow[] lstAttacker = dsDoiHinh.Tables[0].Select("Position = 'Attacker'");
                    if (lstAttacker.Length > 0)
                    {
                        rptAttacker.DataSource = lstAttacker.CopyToDataTable();
                        rptAttacker.DataBind();
                    }


                }

                #region Match

                if (dsLastestMatch != null)
                {
                    rptLastestMatch.DataSource = dsLastestMatch.Tables[0];
                    rptLastestMatch.DataBind();

                    MatchPagging1.totalrecord = ConvertUtility.ToInt32(dsLastestMatch.Tables[1].Rows[0][0]);
                    MatchPagging1.pagesize = PageSize;
                    MatchPagging1.numberpage = PageNumber;
                    MatchPagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&id=" + id;
                    MatchPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&id=" + id + "&mpage=";
                }

                #endregion

                #region News

                if (dsNews != null)
                {
                    rptNews.DataSource = dsNews.Tables[0];
                    rptNews.DataBind();

                    NewsPagging1.totalrecord = ConvertUtility.ToInt32(dsNews.Tables[1].Rows[0][0]);
                    NewsPagging1.pagesize = PageSize;
                    NewsPagging1.numberpage = PageNumber;
                    NewsPagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&id=" + id;
                    NewsPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&id=" + id + "&npage=";

                    divNews.Visible = true;
                }

                #endregion

                #region Video

                if (dsVideoId != null)
                {
                    string videoIds = string.Empty;
                    foreach (DataRow item in dsVideoId.Tables[0].Rows)
                    {
                        videoIds = videoIds + "," + item["Video_Id"];
                    }

                    DataTable dtVideo = _duLieuController.WapTheThaoSoGetTeamInforLastestVideoContent(videoIds);
                    rptlastestVideo.DataSource = dtVideo;
                    rptlastestVideo.DataBind();

                    VideoPagging1.totalrecord = ConvertUtility.ToInt32(dsVideoId.Tables[1].Rows[0][0]);
                    VideoPagging1.pagesize = PageSize;
                    VideoPagging1.numberpage = PageNumber;
                    VideoPagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&id=" + id;
                    VideoPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&id=" + id + "&vpage=";

                    divVideos.Visible = true;

                }

                #endregion


            }
        }

    }
}
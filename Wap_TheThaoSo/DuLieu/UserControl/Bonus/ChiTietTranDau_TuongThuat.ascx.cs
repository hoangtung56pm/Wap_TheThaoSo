using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using log4net;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl.Bonus
{
    public partial class ChiTietTranDau_TuongThuat : System.Web.UI.UserControl
    {
        private readonly DuLieuController _duLieuController = new DuLieuController();
        private readonly VideoController _videoController = new VideoController();
        protected int VideoId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (id > 0)
            {
                //DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);
                DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);
                if (ds != null)
                {
                    string status = string.Empty;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptTeamInfo.DataSource = ds.Tables[0];
                        rptTeamInfo.DataBind();

                        rptInfoLink.DataSource = ds.Tables[0];
                        rptInfoLink.ItemDataBound += rptInfoLink_ItemDataBound;
                        rptInfoLink.DataBind();

                        status = ds.Tables[0].Rows[0]["Status"].ToString();
                    }


                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        //if (ds.Tables[1].Rows[0]["Content"].ToString() != "Trận đấu bắt đầu")
                        //{
                        //    DataRow dr = ds.Tables[1].NewRow();
                        //    dr["Match_ID"] = id;
                        //    dr["Time"] = 1;
                        //    dr["Minute_Extra"] = 0;
                        //    dr["Content"] = "Trận đấu bắt đầu";
                        //    dr["Code"] = id;

                        //    ds.Tables[1].Rows.InsertAt(dr, 0);
                        //}

                        //if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        //{
                        //    status = ds.Tables[2].Rows[0]["Status"].ToString();
                        //    if (status.ToLower() == "played")
                        //    {
                        //        if (ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Content"].ToString() != "Trận đấu kết thúc !!!")
                        //        {
                        //            DataRow drLast = ds.Tables[1].NewRow();
                        //            drLast["Match_ID"] = id;
                        //            drLast["Time"] = "90";
                        //            drLast["Minute_Extra"] = ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Minute_Extra"];
                        //            drLast["Content"] = "Trận đấu kết thúc !!!";
                        //            drLast["Code"] = id;

                        //            ds.Tables[1].Rows.InsertAt(drLast, ds.Tables[1].Rows.Count);
                        //        }
                        //    }
                        //}

                        DataRow[] drEvents = ds.Tables[1].Select(" type not in ('lineup','subs_on_bench','assist') ", " minute ASC ", DataViewRowState.OriginalRows);
                        if (drEvents.Length>0)
                        {
                            rptCommentary.DataSource = drEvents.CopyToDataTable();
                            rptCommentary.ItemDataBound += rptCommentary_ItemDataBound;
                            rptCommentary.DataBind();
                        }

                    }
                    else
                    {
                        if (status == "Fixture")
                        {
                            divThongBao.Visible = true;
                        }
                    }
                }
            }
        }

        void rptCommentary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var litImg = (Literal)e.Item.FindControl("litImage");
            var extraTIme = (Literal)e.Item.FindControl("litExtraTime");
            var currData = (DataRowView)e.Item.DataItem;


            if (extraTIme != null)
            {
                int extra = ConvertUtility.ToInt32(currData["game_minute_extra"]);
                if (extra > 0)
                {
                    extraTIme.Text = "+" + extra;
                }
            }

            if (litImg != null)
            {
                if (currData["type"].ToString() == "goal")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/icon-bong.png\">";
                }
                else if (currData["type"].ToString() == "yellow_card")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/YC.png\">";
                }
                else if (currData["type"].ToString() == "yellow_red_card")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/Y2C.png\">";
                }
                else if (currData["type"].ToString() == "substitute_in")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/in.png\">";
                }
                else if (currData["type"].ToString() == "substitute_out")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/out.png\">";
                }
                else if (currData["type"].ToString() == "penalty_goal")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/PG.png\">";
                }
                else if (currData["type"].ToString() == "red_card")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/red-card.jpg\">";
                }
                else if (currData["type"].ToString() == "own_goal")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/ball1.png\">";
                }
            }

        }

        protected void rptInfoLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);

            if (e.Item.ItemIndex < 0) return;

            var pnlNonVideo = (Panel)e.Item.FindControl("pnlNonVideo");
            var pnlVideo = (Panel)e.Item.FindControl("pnlVideo");

            //if (ds.Tables[3] != null)
            //{
            //    if (ds.Tables[3].Rows.Count > 0)
            //    {
            //        pnlVideo.Visible = true;
            //        VideoId = ConvertUtility.ToInt32(ds.Tables[3].Rows[0]["Video_Id"]);
            //    }
            //}
            //else
            //{
            pnlNonVideo.Visible = true;
            //}
        }

        protected string GetVideoLink()
        {
            DataSet ds = _videoController.GetVideoDetail(VideoId, 1, 1);

            string str = string.Empty;

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                str = AppEnv.GetViewLink(dt.Rows[0]["SmartPhonePath"].ToString(), dt.Rows[0]["MobilePath"].ToString());
            }

            return str;
        }
    }
}
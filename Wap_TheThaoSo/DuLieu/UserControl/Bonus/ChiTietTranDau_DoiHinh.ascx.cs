using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl.Bonus
{
    public partial class ChiTietTranDau_DoiHinh : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        readonly VideoController _videoController = new VideoController();

        protected string TeamA;
        protected string TeamB;
        protected string CoachA;
        protected string CoachB;
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
                //DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id);
                DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptTeamInfo.DataSource = ds.Tables[0];
                        rptTeamInfo.DataBind();

                        TeamA = ds.Tables[0].Rows[0]["Team_A_Code"].ToString();
                        TeamB = ds.Tables[0].Rows[0]["Team_B_Code"].ToString();

                        int teamAid = ConvertUtility.ToInt32(ds.Tables[0].Rows[0]["Team_A_Id"].ToString());
                        int teamBid = ConvertUtility.ToInt32(ds.Tables[0].Rows[0]["Team_B_Id"].ToString());

                        //if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        //    CoachA = ds.Tables[2].Rows[0]["Name"].ToString();

                        //if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        //    CoachB = ds.Tables[3].Rows[0]["Name"].ToString();

                        rptInfoLink.DataSource = ds.Tables[0];
                        rptInfoLink.ItemDataBound += rptInfoLink_ItemDataBound;
                        rptInfoLink.DataBind();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            IList<DataRow> l1 = ds.Tables[1].Select(" Team_Id = " + teamAid + " AND type = 'lineup' ").ToList();
                            IList<DataRow> sub1 = ds.Tables[1].Select(" Team_Id = " + teamAid + " AND type = 'subs_on_bench' ").ToList();

                            IList<DataRow> l2 = ds.Tables[1].Select(" Team_Id = " + teamBid + " AND type = 'lineup' ").ToList();
                            IList<DataRow> sub2 = ds.Tables[1].Select(" Team_Id = " + teamBid + " AND type = 'subs_on_bench' ").ToList();

                            if (l1.Count > 0)
                            {
                                rptL1.DataSource = l1.CopyToDataTable();
                                rptL1.ItemDataBound += rptL1_ItemDataBound;
                                rptL1.DataBind();
                            }

                            if (sub1.Count > 0)
                            {
                                rptSub1.DataSource = sub1.CopyToDataTable();
                                rptSub1.ItemDataBound += rptSub1_ItemDataBound;
                                rptSub1.DataBind();
                            }
                            else
                            {
                                IList<DataRow> sub11 = ds.Tables[1].Select("Team_id = " + teamAid + " AND type = 'substitute_in' ").ToList();
                                if (sub11.Count > 0)
                                {
                                    rptSub1.DataSource = sub11.CopyToDataTable();
                                    rptSub1.ItemDataBound += rptSub1_ItemDataBound;
                                    rptSub1.DataBind();
                                }
                            }

                            if (l2.Count > 0)
                            {
                                rptL2.DataSource = l2.CopyToDataTable();
                                rptL2.ItemDataBound += rptL2_ItemDataBound;
                                rptL2.DataBind();
                            }

                            if (sub2.Count > 0)
                            {
                                rptSub2.DataSource = sub2.CopyToDataTable();
                                rptSub2.ItemDataBound += rptSub2_ItemDataBound;
                                rptSub2.DataBind();
                            }
                            else
                            {
                                IList<DataRow> sub22 = ds.Tables[1].Select("Team_id = " + teamBid + " AND type = 'substitute_in' ").ToList();
                                if (sub22.Count > 0)
                                {
                                    rptSub2.DataSource = sub22.CopyToDataTable();
                                    rptSub2.ItemDataBound += rptSub2_ItemDataBound;
                                    rptSub2.DataBind();
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void rptInfoLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            //DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id);
            //DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);

            //if (e.Item.ItemIndex < 0) return;

            //var pnlNonVideo = (Panel)e.Item.FindControl("pnlNonVideo");
            //var pnlVideo = (Panel)e.Item.FindControl("pnlVideo");

            //if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
            //{
            //    pnlVideo.Visible = true;
            //    VideoId = ConvertUtility.ToInt32(ds.Tables[5].Rows[0]["Video_Id"]);
            //}
            //else
            //{
            //    pnlNonVideo.Visible = true;
            //}
        }

        void rptL1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            //if (e.Item.ItemIndex < 0) return;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;
                //DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];

                DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);

                DataTable dt0 = ds.Tables[0];
                int teamAid = ConvertUtility.ToInt32(dt0.Rows[0]["Team_A_Id"].ToString());
                int teamBid = ConvertUtility.ToInt32(dt0.Rows[0]["Team_B_Id"].ToString());

                DataTable dt = ds.Tables[1];

                IList<DataRow> countSo = dt.Select("Team_id = " + teamAid + " AND type = 'substitute_out' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamAid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamAid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamAid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamAid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                //DataTable dtEvent = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[4];
                DataTable dtEvent = ds.Tables[1];

                string img = string.Empty;

                if (countSo.Count > 0)
                {
                    DataRow dr = dtEvent.Select(" type = 'substitute_out' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/out.png\" />" + dr["game_minute"] + "'";
                }

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select(" type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {

                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

        }

        void rptSub1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);

            DataTable dt = ds.Tables[1];
            DataTable dtEvent = ds.Tables[1];
            DataTable dt0 = ds.Tables[0];
            int teamAid = ConvertUtility.ToInt32(dt0.Rows[0]["Team_A_Id"].ToString());

            if (e.Item.ItemType == ListItemType.Item)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;
                IList<DataRow> countSi = dt.Select("Team_id = " + teamAid + " AND type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamAid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamAid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamAid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamAid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"lineheight height40px padding-left15px\">";
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team_id = 1 AND type = 'substitute_out' ");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["matchName"] + " " + dr["game_minute"] + "'";
                        litThay.Text += "</div>";
                    }
                }
                else
                {
                    litStartDiv.Text = "<div class=\"lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

            if (e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;
                //DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
                IList<DataRow> countSi = dt.Select("Team_id = " + teamAid + " AND type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamAid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamAid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamAid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamAid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamAid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height40px padding-left15px\">";
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team_id = " + teamAid + " AND type = 'substitute_out' ");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["matchName"] + " " + dr["game_minute"] + "'";
                        litThay.Text += "</div>";
                    }
                }
                else
                {
                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

        }

        void rptL2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            //if (e.Item.ItemIndex < 0) return;
            DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);
            DataTable dt0 = ds.Tables[0];

            int teamBid = ConvertUtility.ToInt32(dt0.Rows[0]["Team_B_Id"].ToString());

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;
                DataTable dt = ds.Tables[1];
                IList<DataRow> countSo = dt.Select("Team_id = " + teamBid + " AND type = 'substitute_out' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamBid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamBid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamBid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamBid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                DataTable dtEvent = ds.Tables[1];

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countSo.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'substitute_out' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/out.png\" />" + dr["game_minute"] + "'";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

        }

        void rptSub2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            DataSet ds = _duLieuController.ApiTtsGetMatchInfoTuongThuat(id);
            DataTable dt0 = ds.Tables[0];

            int teamBid = ConvertUtility.ToInt32(dt0.Rows[0]["Team_B_Id"].ToString());

            DataTable dt = ds.Tables[1];
            DataTable dtEvent = ds.Tables[1];

            if (e.Item.ItemType == ListItemType.Item)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;

                IList<DataRow> countSi = dt.Select("Team_id = " + teamBid + " AND type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamBid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamBid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamBid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamBid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"lineheight height40px padding-left15px\">";

                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team_id = " + teamBid + " AND type = 'substitute_out' ");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["matchName"] + " " + dr["game_minute"] + "'";
                        litThay.Text += "</div>";
                    }

                }
                else
                {
                    litStartDiv.Text = "<div class=\"lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }


            if (e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;
                //DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
                IList<DataRow> countSi = dt.Select("Team_id = " + teamBid + " AND type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countG = dt.Select("Team_id = " + teamBid + " AND type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countPg = dt.Select("Team_id = " + teamBid + " AND type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countYc = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countRc = dt.Select("Team_id = " + teamBid + " AND type = 'red_card' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countOg = dt.Select("Team_id = " + teamBid + " AND type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                IList<DataRow> countY2C = dt.Select("Team_id = " + teamBid + " AND type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["game_minute"] + "'";
                }

                if (countSi.Count > 0)
                {

                    DataRow dr = dtEvent.Select("type = 'substitute_in' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height40px padding-left15px\">";

                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team_id = " + teamBid + " AND type = 'substitute_out' ");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["matchName"] + " " + dr["game_minute"] + "'";
                        litThay.Text += "</div>";
                    }

                }
                else
                {
                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'own_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("type = 'penalty_goal' AND player_id = '" + currData["player_id"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["game_minute"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'yellow_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["game_minute"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("type = 'red_card' AND player_id = '" + currData["player_id"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["game_minute"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

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
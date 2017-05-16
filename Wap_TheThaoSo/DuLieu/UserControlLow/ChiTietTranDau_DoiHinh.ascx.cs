using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class ChiTietTranDau_DoiHinh : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();

        protected string TeamA;
        protected string TeamB;
        protected string CoachA;
        protected string CoachB;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (id > 0)
            {
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id);
                if (ds != null)
                {
                    rptTeamInfo.DataSource = ds.Tables[0];
                    rptTeamInfo.DataBind();

                    TeamA = ds.Tables[0].Rows[0]["Team_A_Name"].ToString();
                    TeamB = ds.Tables[0].Rows[0]["Team_B_Name"].ToString();

                    if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        CoachA = ds.Tables[2].Rows[0]["Name"].ToString();

                    if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        CoachB = ds.Tables[3].Rows[0]["Name"].ToString();

                    rptInfoLink.DataSource = ds.Tables[0];
                    rptInfoLink.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        IList<DataRow> l1 = ds.Tables[1].Select("Team = 1 AND Code = 'L' ").ToList();
                        IList<DataRow> sub1 = ds.Tables[1].Select("Team = 1 AND Code = 'SUB' ").ToList();

                        IList<DataRow> l2 = ds.Tables[1].Select("Team = 2 AND Code = 'L' ").ToList();
                        IList<DataRow> sub2 = ds.Tables[1].Select("Team = 2 AND Code = 'SUB' ").ToList();

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
                            IList<DataRow> sub11 = ds.Tables[1].Select("Team = 1 AND Code = 'SI' ").ToList();
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
                            IList<DataRow> sub22 = ds.Tables[1].Select("Team = 2 AND Code = 'SI' ").ToList();
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


        void rptL1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            //if (e.Item.ItemIndex < 0) return;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;
                DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
                IList<DataRow> countSo = dt.Select("Team = 1 AND Code = 'SO' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 1 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 1 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 1 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 1 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 1 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 1 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                DataTable dtEvent = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[4];


                string img = string.Empty;

                if (countSo.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'SO' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/out.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {

                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
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
            DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
            DataTable dtEvent = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[4];

            if (e.Item.ItemType == ListItemType.Item)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;
                IList<DataRow> countSi = dt.Select("Team = 1 AND Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 1 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 1 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 1 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 1 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 1 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 1 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"lineheight height40px padding-left15px\">";
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team = 1 AND Code = 'SO' AND SameCode = '" + countSi[0]["SameCode"] + "'");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["Person"] + " " + dr["MinuteTime"] + "'";
                        litThay.Text += "</div>";
                    }
                }
                else
                {
                    litStartDiv.Text = "<div class=\"lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
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
                IList<DataRow> countSi = dt.Select("Team = 1 AND Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 1 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 1 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 1 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 1 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 1 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 1 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height40px padding-left15px\">";
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team = 1 AND Code = 'SO' AND SameCode = '" + countSi[0]["SameCode"] + "'");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["Person"] + " " + dr["MinuteTime"] + "'";
                        litThay.Text += "</div>";
                    }
                }
                else
                {
                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
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

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;
                DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
                IList<DataRow> countSo = dt.Select("Team = 2 AND Code = 'SO' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 2 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 2 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 2 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 2 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 2 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 2 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                DataTable dtEvent = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[4];

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countSo.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'SO' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/out.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
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
            DataTable dt = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[1];
            DataTable dtEvent = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id).Tables[4];

            if (e.Item.ItemType == ListItemType.Item)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");
                var litThay = (Literal)e.Item.FindControl("litThay");
                var litStartDiv = (Literal)e.Item.FindControl("litStartDiv");

                var currData = (DataRowView)e.Item.DataItem;

                IList<DataRow> countSi = dt.Select("Team = 2 AND Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 2 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 2 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 2 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 2 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 2 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 2 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countSi.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"lineheight height40px padding-left15px\">";

                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team = 2 AND Code = 'SO' AND SameCode = '" + countSi[0]["SameCode"] + "'");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["Person"] + " " + dr["MinuteTime"] + "'";
                        litThay.Text += "</div>";
                    }

                }
                else
                {
                    litStartDiv.Text = "<div class=\"lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
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
                IList<DataRow> countSi = dt.Select("Team = 2 AND Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countG = dt.Select("Team = 2 AND Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countPg = dt.Select("Team = 2 AND Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countYc = dt.Select("Team = 2 AND Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countRc = dt.Select("Team = 2 AND Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countOg = dt.Select("Team = 2 AND Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                IList<DataRow> countY2C = dt.Select("Team = 2 AND Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'");

                string img = string.Empty;

                if (countY2C.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'Y2C' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countSi.Count > 0)
                {

                    DataRow dr = dtEvent.Select("Code = 'SI' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();

                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height40px padding-left15px\">";

                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/in.png\" />";
                    IList<DataRow> personL = dt.Select("Team = 2 AND Code = 'SO' AND SameCode = '" + countSi[0]["SameCode"] + "'");
                    if (personL.Count > 0)
                    {
                        litThay.Text = "<div class=\"clear0px\"></div><div class=\"font10px color-xam737373 padding-left30px\">";
                        litThay.Text += "thay " + personL[0]["Person"] + " " + dr["MinuteTime"] + "'";
                        litThay.Text += "</div>";
                    }

                }
                else
                {
                    litStartDiv.Text = "<div class=\"background-xam-F4F4F4 lineheight height25px padding-left15px\">";
                }

                if (countOg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'OG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countOg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countG.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'G' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countG.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countPg.Count > 0)
                {
                    IList<DataRow> dr = dtEvent.Select("Code = 'PG' AND Person_ID = '" + currData["Person_ID"] + "'");
                    for (int i = 0; i < countPg.Count; i++)
                    {
                        img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr[i]["MinuteTime"] + "'";
                    }
                }

                if (countYc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'YC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                }

                if (countRc.Count > 0)
                {
                    DataRow dr = dtEvent.Select("Code = 'RC' AND Person_ID = '" + currData["Person_ID"] + "'").FirstOrDefault();
                    img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
                }

                if (litImage != null)
                {
                    litImage.Text = img;
                }
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl.Bonus
{
    public partial class ChiTietTranDauKetThuc : System.Web.UI.UserControl
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
                rptParent.DataSource = ds.Tables[0];
                rptParent.ItemDataBound += rptParent_ItemDataBound;
                rptParent.DataBind();

                TeamA = ds.Tables[0].Rows[0]["Team_A_Name"].ToString();
                TeamB = ds.Tables[0].Rows[0]["Team_B_Name"].ToString();

                string teamAId = ds.Tables[0].Rows[0]["Team_A_ID"].ToString();
                string teamBId = ds.Tables[0].Rows[0]["Team_B_ID"].ToString();

                if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                    CoachA = ds.Tables[2].Rows[0]["Name"].ToString();

                if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                    CoachB = ds.Tables[3].Rows[0]["Name"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    IList<DataRow> l1 = ds.Tables[4].Select(" Code IN ('G','YC','PG','RC','OG','Y2C') ").ToList();

                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("Team_A_Id", typeof(string));
                    dtTemp.Columns.Add("Person_Id", typeof(int));
                    dtTemp.Columns.Add("National", typeof(string));
                    dtTemp.Columns.Add("ShirtNumber", typeof(string));
                    dtTemp.Columns.Add("Person", typeof(string));
                    dtTemp.Columns.Add("Team_B_Id", typeof(string));
                    dtTemp.Columns.Add("MinuteTime", typeof(string));
                    dtTemp.Columns.Add("Event", typeof(string));

                    foreach (var dataRow in l1)
                    {
                        DataRow dr = dtTemp.NewRow();

                        dr["Team_A_Id"] = dataRow["Team_ID"];
                        dr["Person_Id"] = dataRow["Person_Id"];
                        DataRow l2 = ds.Tables[1].Select("Person_Id = " + dataRow["Person_Id"]).FirstOrDefault();

                        dr["National"] = l2["National"];
                        dr["ShirtNumber"] = l2["ShirtNumber"];
                        dr["Person"] = l2["Person"];
                        dr["MinuteTime"] = dataRow["MinuteTime"];

                        string code = dataRow["Code"].ToString();

                        IList<DataRow> countG = new List<DataRow>();
                        IList<DataRow> countPg = new List<DataRow>();
                        IList<DataRow> countRc = new List<DataRow>();
                        IList<DataRow> countOg = new List<DataRow>();
                        IList<DataRow> countYc = new List<DataRow>();
                        IList<DataRow> countY2C = new List<DataRow>();

                        if (code == "G")
                            countG = ds.Tables[4].Select("Code = 'G' AND Person_ID = '" + dr["Person_ID"] + "'  AND MinuteTime='" + dr["MinuteTime"] + "'");
                        else if (code == "PG")
                            countPg = ds.Tables[4].Select("Code = 'PG' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        else if (code == "RC")
                            countRc = ds.Tables[4].Select("Code = 'RC' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        else if (code == "OG")
                            countOg = ds.Tables[4].Select("Code = 'OG' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        else if (code == "YC")
                            countYc = ds.Tables[4].Select("Code = 'YC' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        else if (code == "Y2C")
                            countY2C = ds.Tables[4].Select("Code = 'Y2C' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");


                        //IList<DataRow> countG = ds.Tables[4].Select("Code = 'G' AND Person_ID = '" + dr["Person_ID"] + "'  AND MinuteTime='" + dr["MinuteTime"] + "'");
                        //IList<DataRow> countPg = ds.Tables[4].Select("Code = 'PG' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        //IList<DataRow> countRc = ds.Tables[4].Select("Code = 'RC' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");

                        //IList<DataRow> countOg = ds.Tables[4].Select("Code = 'OG' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");
                        //IList<DataRow> countYc = ds.Tables[4].Select("Code = 'YC' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");

                        //IList<DataRow> countY2C = ds.Tables[4].Select("Code = 'Y2C' AND Person_ID = '" + dr["Person_ID"] + "' AND MinuteTime='" + dr["MinuteTime"] + "'");

                        string img = string.Empty;

                        if (countY2C.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/Y2C.png\" />" + dr["MinuteTime"] + "'";
                        }

                        if (countOg.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/ball1.png\" />" + dr["MinuteTime"] + "'";
                        }

                        if (countG.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/icon-bong.png\" />" + dr["MinuteTime"] + "'";
                        }

                        if (countPg.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/PG.png\" />" + dr["MinuteTime"] + "'";
                        }

                        if (countYc.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/YC.png\" />" + dr["MinuteTime"] + "'";
                        }

                        if (countRc.Count > 0)
                        {
                            img = img + " <img alt=\"\" class=\"padding-top2px\" src=\"/layout/images/red-card.jpg\" />" + dr["MinuteTime"] + "'";
                        }

                        dr["Event"] = img;

                        dr["Team_B_Id"] = dataRow["Team_ID"];


                        dtTemp.Rows.Add(dr);
                    }

                    DataTable dt1 = dtTemp.Clone();
                    DataTable dt2 = dtTemp.Clone();

                    foreach (DataRow item in dtTemp.Rows)
                    {
                        DataRow row = dt1.NewRow();

                        if (item["Team_A_Id"].ToString() == teamAId)
                        {
                            row["Team_A_Id"] = teamAId;
                            row["Person_Id"] = item["Person_Id"];
                            row["National"] = item["National"];
                            row["ShirtNumber"] = item["ShirtNumber"];
                            row["Person"] = item["Person"];
                            row["MinuteTime"] = item["MinuteTime"];
                            row["Event"] = item["Event"];
                        }
                        else
                        {
                            row["Team_A_Id"] = teamAId;
                            row["Person_Id"] = 0;
                            row["National"] = "";
                            row["ShirtNumber"] = "";
                            row["Person"] = "";
                            row["MinuteTime"] = item["MinuteTime"];
                            row["Event"] = "";
                        }

                        DataRow row1 = dt2.NewRow();

                        if (item["Team_A_Id"].ToString() == teamBId)
                        {
                            row1["Team_B_Id"] = teamBId;
                            row1["Person_Id"] = item["Person_Id"];
                            row1["National"] = item["National"];
                            row1["ShirtNumber"] = item["ShirtNumber"];
                            row1["Person"] = item["Person"];
                            row1["MinuteTime"] = item["MinuteTime"];
                            row1["Event"] = item["Event"];
                        }
                        else
                        {
                            row1["Team_B_Id"] = teamBId;
                            row1["Person_Id"] = 0;
                            row1["National"] = "";
                            row1["ShirtNumber"] = "";
                            row1["Person"] = "";
                            row1["MinuteTime"] = item["MinuteTime"];
                            row1["Event"] = "";
                        }

                        dt1.Rows.Add(row);
                        dt2.Rows.Add(row1);
                    }

                    if (dt1.Rows.Count > 0)
                    {
                        DataView dataView1 = dt1.DefaultView;
                        dataView1.Sort = "MinuteTime";
                        rptL1.DataSource = dataView1;
                        rptL1.ItemDataBound += rptL1_ItemDataBound;
                        rptL1.DataBind();
                    }

                    if (dt2.Rows.Count > 0)
                    {
                        DataView dataView2 = dt2.DefaultView;
                        dataView2.Sort = "MinuteTime";
                        rptL2.DataSource = dataView2;
                        rptL2.ItemDataBound += rptL2_ItemDataBound;
                        rptL2.DataBind();
                    }
                }
            }
        }

        void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var rptMenuLevel2 = (Repeater)e.Item.FindControl("rptChild");

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoDoiHinh(id);

            rptMenuLevel2.DataSource = ds.Tables[0];
            rptMenuLevel2.DataBind();
        }

        void rptL1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;

                if (litImage != null)
                {
                    litImage.Text = currData["Event"].ToString();
                }
            }
        }

        void rptL2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var litImage = (Literal)e.Item.FindControl("litImage");

                var currData = (DataRowView)e.Item.DataItem;

                if (litImage != null)
                {
                    litImage.Text = currData["Event"].ToString();
                }
            }

        }

    }
}
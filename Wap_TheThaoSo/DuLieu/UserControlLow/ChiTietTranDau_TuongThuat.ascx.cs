using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControlLow
{
    public partial class ChiTietTranDau_TuongThuat : System.Web.UI.UserControl
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
                DataSet ds = _duLieuController.WapTheThaoSoGetMatchInfoTuongThuat(id);
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

                        if (ds.Tables[1].Rows[0]["Content"].ToString() != "Trận đấu bắt đầu")
                        {
                            DataRow dr = ds.Tables[1].NewRow();
                            dr["Match_ID"] = id;
                            dr["Time"] = 1;
                            dr["Minute_Extra"] = 0;
                            dr["Content"] = "Trận đấu bắt đầu";
                            dr["Code"] = id;

                            ds.Tables[1].Rows.InsertAt(dr, 0);
                        }

                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            status = ds.Tables[2].Rows[0]["Status"].ToString();
                            if (status.ToLower() == "played")
                            {
                                if (ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Content"].ToString() != "Trận đấu kết thúc !!!")
                                {
                                    DataRow drLast = ds.Tables[1].NewRow();
                                    drLast["Match_ID"] = id;
                                    drLast["Time"] = "90";
                                    drLast["Minute_Extra"] = ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1]["Minute_Extra"];
                                    drLast["Content"] = "Trận đấu kết thúc !!!";
                                    drLast["Code"] = id;

                                    ds.Tables[1].Rows.InsertAt(drLast, ds.Tables[1].Rows.Count);
                                }
                            }
                        }


                        rptCommentary.DataSource = ds.Tables[1];
                        rptCommentary.ItemDataBound += rptCommentary_ItemDataBound;
                        rptCommentary.DataBind();
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
                int extra = ConvertUtility.ToInt32(currData["Minute_Extra"]);
                if (extra > 0)
                {
                    extraTIme.Text = "+" + extra;
                }
            }

            if (litImg != null)
            {
                if (currData["Code"].ToString() == "G")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/icon-bong.png\">";
                }
                else if (currData["Code"].ToString() == "YC")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/YC.png\">";
                }
                else if (currData["Code"].ToString() == "Y2C")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/Y2C.png\">";
                }
                else if (currData["Code"].ToString() == "SI")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/in.png\">";
                }
                else if (currData["Code"].ToString() == "PG")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/PG.png\">";
                }
                else if (currData["Code"].ToString() == "RC")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/red-card.png\">";
                }
                else if (currData["Code"].ToString() == "OG")
                {
                    litImg.Text = "<img class=\"margin-top5px\" src=\"/layout/images/ball1.png\">";
                }
            }

        }
    }
}
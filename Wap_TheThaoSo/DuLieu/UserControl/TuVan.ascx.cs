using System;
using System.Data;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class TuVan : BaseControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string id = ConvertUtility.ToString(Request.QueryString["id"]);
            width = ConvertUtility.ToString(Request.QueryString["w"]);

            DataSet ds = _duLieuController.WapTheThaoSoGet87ServiceLists();
            if(ds != null)
            {
                rptTuVan.DataSource = ds.Tables[0];
                rptTuVan.ItemDataBound += rptTuVan_ItemDataBound;
                rptTuVan.DataBind();
            }

            DataTable dtTip = _duLieuController.WapTheThaoSoGetTipList();
            if (dtTip != null && dtTip.Rows.Count > 0)
            {
                rptTip.DataSource = dtTip;
                rptTip.DataBind();
            }

            if(!string.IsNullOrEmpty(id))
            {
                DataTable dt = _duLieuController.WapTheThaoSoGet87Content(id);
                
                if(dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["IsFull"].ToString() == "0")
                    {
                        rptContent.DataSource = dt;
                        rptContent.DataBind();
                    }
                    else
                    {
                        string url = "/DuLieu/TuVanDacBiet.aspx?id=" + id + "&lang=" + Lang + "&w=" + Width;
                        Response.Redirect(url);
                    }
                }
            }
        }

        void rptTuVan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            var ltrUrl = (Literal)e.Item.FindControl("ltrUrl");

            var currData = (DataRowView)e.Item.DataItem;
            DataTable dtcheck = _duLieuController.WapTheThaoSoGet87Content(currData["ServiceId"].ToString());

            if (currData["Game87_Id"].ToString() == "4") //Tran cau vang
            {
                if (ConvertUtility.ToBoolean(currData["IsFull"]))
                {
                    string url = "/DuLieu/TuVanDacBiet.aspx?id=" + currData["ServiceId"] + "&lang=" + Lang + "&w=" + Width;
                    ltrUrl.Text = "<a class=\"yellow\" href=" + url + ">" + currData["ServiceName"] + " </a>";
                }
                else
                {
                    ltrUrl.Text = "<a class=\"yellow\" href=" + currData["Link"] + ">" + currData["ServiceName"] + " </a>";
                }
            }
            else
            {
                string url = "/DuLieu/TuVanDacBiet.aspx?id=" + currData["ServiceId"] + "&lang=" + Lang + "&w=" + Width;
                if (ConvertUtility.ToBoolean(dtcheck.Rows[0]["IsFull"]))
                {
                    ltrUrl.Text = "<a style=\"color:#0033FF;\" href=" + url + ">" + currData["ServiceName"] + " </a> ";
                }
                else
                {
                    ltrUrl.Text = "<a href=\"#\">" + currData["ServiceName"] + "(đang cập nhật) </a>";
                }
            }
        }

    }
}
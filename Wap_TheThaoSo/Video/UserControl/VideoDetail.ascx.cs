using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Video.UserControl
{
    public partial class VideoDetail : BaseControl
    {
        readonly VideoController _videoController = new VideoController();
        private const int PageSize = 10;
        private const int PageNumber = 5;
        private int _curpage = 1;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (id > 0)
            {
                DataSet ds = _videoController.GetVideoDetail(id, _curpage, PageSize);
                //DataSet ds = _videoController.GetVideoDetailW4A("viettel",id,_curpage,PageSize);

                if (ds != null)
                {
                    rptContentTop.DataSource = ds.Tables[0];
                    rptContentTop.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        rptContentBottom.DataSource = ds.Tables[1];
                        rptContentBottom.DataBind();

                        Pagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[2].Rows[0][0]);
                        Pagging1.pagesize = PageSize;
                        Pagging1.numberpage = PageNumber;
                        Pagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&id=" + id;
                        Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&id=" + id + "&cpage=";
                    }
                }
            }

            if (Session["msisdn"] != null)
            {
                DataTable dt = TransactionController.GetRegisterInfo(Session["msisdn"].ToString());
                if (dt.Rows.Count > 0 && ConvertUtility.ToDateTime(dt.Rows[0]["ExpiredTime"].ToString()) >= DateTime.Now)
                {
                    Price = "0đ";
                }
                else
                {
                    Price = AppEnv.GetSetting("videoprice") + "đ";
                }
            }
        }
    }
}
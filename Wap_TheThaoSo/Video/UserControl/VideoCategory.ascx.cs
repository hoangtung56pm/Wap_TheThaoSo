using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Video.UserControl
{
    public partial class VideoCategory : BaseControl
    {

        readonly VideoController _videoController = new VideoController();
        private const int PageSize = 10;
        private const int PageNumber = 5;
        private int _curpage = 1;
        protected string CateName;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            int catId = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (catId > 0)
            {
                DataSet ds = _videoController.GetVideoByCategoryId(catId, _curpage, PageSize);
                //DataSet ds = _videoController.GetLastestVideoW4A("viettel", 11, 0, 1, _curpage, PageSize); //11 : Bong da

                if (ds != null)
                {
                    rptContentBottom.DataSource = ds.Tables[0];
                    rptContentBottom.DataBind();

                    CateName = ds.Tables[0].Rows[0]["CategoryName"].ToString();

                    Pagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0][0]);
                    Pagging1.pagesize = PageSize;
                    Pagging1.numberpage = PageNumber;
                    Pagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID;
                    Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID + "&cpage=";
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
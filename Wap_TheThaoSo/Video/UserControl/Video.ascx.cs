using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Video.UserControl
{
    public partial class Video : BaseControl
    {
        readonly VideoController _videoController = new VideoController();
        private const int PageSize = 10;
        private const int PageNumber = 5;
        private int _curpage = 1;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            DataSet ds = _videoController.GetLastestVideo(_curpage, PageSize);
            //DataSet ds = _videoController.GetLastestVideoW4A("viettel",11,0,1,_curpage,PageSize); //11 : Bong da

            if (ds != null)
            {
                IList<DataRow> contentTop = ds.Tables[0].Select().Skip(0).Take(1).ToList();
                IList<DataRow> bottomTop = ds.Tables[0].Select().Skip(1).Take(9).ToList();

                rptContentTop.DataSource = contentTop.CopyToDataTable();
                rptContentTop.DataBind();

                rptContentBottom.DataSource = bottomTop.CopyToDataTable();
                rptContentBottom.DataBind();

                Pagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0][0]);
                Pagging1.pagesize = PageSize;
                Pagging1.numberpage = PageNumber;
                Pagging1.defaultparam = "?display=" + Display + "&w=" + Width;
                Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&cpage=";
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
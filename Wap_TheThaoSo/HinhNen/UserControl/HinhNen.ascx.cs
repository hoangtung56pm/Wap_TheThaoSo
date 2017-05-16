using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.HinhNen;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.HinhNen.UserControl
{
    public partial class HinhNen : BaseControl
    {
        readonly HinhNenController _videoController = new HinhNenController();
        private const int PageSize = 6;
        private const int PageNumber = 5;
        private int _curpageTai = 1;
        private int _curpageMoi = 1;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["dpage"]))
            {
                _curpageTai = ConvertUtility.ToInt32(Request.QueryString["dpage"]);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["npage"]))
            {
                _curpageMoi = ConvertUtility.ToInt32(Request.QueryString["npage"]);
            }

            string telco = "viettel";
            if(Session["Telco"] != null)
            {
               telco = AppEnv.GetTelco(Session["Telco"].ToString());
            }

            DataSet dsDownload = _videoController.GetWallPaperByCategoryId(telco, 11, 1, _curpageTai, PageSize, "Download");
            DataSet dsNew = _videoController.GetWallPaperByCategoryId(telco, 11, 1, _curpageMoi, PageSize, "Priority");

            if (dsDownload != null)
            {
                rptTaiNhieuNhat.DataSource = dsDownload.Tables[0];
                rptTaiNhieuNhat.DataBind();

                DownloadPagging1.totalrecord = ConvertUtility.ToInt32(dsDownload.Tables[1].Rows[0][0]);
                DownloadPagging1.pagesize = PageSize;
                DownloadPagging1.numberpage = PageNumber;
                DownloadPagging1.defaultparam = "?display=" + Display + "&w=" + Width;
                DownloadPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&dpage=";
            }


            if (dsNew != null)
            {
                rptMoiCapNhat.DataSource = dsNew.Tables[0];
                rptMoiCapNhat.DataBind();

                NewPagging1.totalrecord = ConvertUtility.ToInt32(dsNew.Tables[1].Rows[0][0]);
                NewPagging1.pagesize = PageSize;
                NewPagging1.numberpage = PageNumber;
                NewPagging1.defaultparam = "?display=" + Display + "&w=" + Width;
                NewPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&npage=";
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
                    Price = AppEnv.GetSetting("wallprice") + "đ";
                }
            }
        }
    }
}
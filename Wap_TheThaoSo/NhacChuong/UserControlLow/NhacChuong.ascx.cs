using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.NhacChuong;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.NhacChuong.UserControlLow
{
    public partial class NhacChuong : BaseControl
    {
        readonly NhacChuongController _nhachuongController = new NhacChuongController();
        private const int PageSize = 6;
        private const int PageNumber = 5;
        private int _curpageMoi = 1;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["npage"]))
            {
                _curpageMoi = ConvertUtility.ToInt32(Request.QueryString["npage"]);
            }

            
            string telco = "viettel";
            if (Session["Telco"] != null)
            {
                telco = AppEnv.GetTelco(Session["Telco"].ToString());
            }
            DataSet dsNew = _nhachuongController.GetRingToneByAlbumId(52, telco, _curpageMoi, 10);

            //if (dsDownload != null)
            //{
            //    rptTaiNhieuNhat.DataSource = dsDownload.Tables[0];
            //    rptTaiNhieuNhat.DataBind();

            //    DownloadPagging1.totalrecord = ConvertUtility.ToInt32(dsDownload.Tables[1].Rows[0][0]);
            //    DownloadPagging1.pagesize = PageSize;
            //    DownloadPagging1.numberpage = PageNumber;
            //    DownloadPagging1.defaultparam = "?display=" + Display + "&w=" + Width;
            //    DownloadPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&dpage=";
            //}


            if (dsNew != null)
            {
                rptMoiNhat.DataSource = dsNew.Tables[0];
                rptMoiNhat.DataBind();

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
                    Price = AppEnv.GetSetting("ringtoneprice") + "đ";
                }
            }
        }

    }
}
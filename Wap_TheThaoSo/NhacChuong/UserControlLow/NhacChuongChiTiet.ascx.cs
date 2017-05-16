using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.NhacChuong;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.NhacChuong.UserControlLow
{
    public partial class NhacChuongChiTiet : BaseControl
    {
        readonly NhacChuongController _nhachuongController = new NhacChuongController();
        private const int PageSize = 8;
        private const int PageNumber = 5;
        private int _curpageMoi = 1;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["npage"]))
            {
                _curpageMoi = ConvertUtility.ToInt32(Request.QueryString["npage"]);
            }

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                string telco = "viettel";
                if (Session["Telco"] != null)
                {
                    telco = AppEnv.GetTelco(Session["Telco"].ToString());
                }
                DataSet ds = _nhachuongController.GetRingToneDetail(telco, id, _curpageMoi, PageSize);

                if (ds != null)
                {
                    rptInfor.DataSource = ds.Tables[0];
                    rptInfor.DataBind();

                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        rptNhacChuongMoiNhat.DataSource = ds.Tables[1];
                        rptNhacChuongMoiNhat.DataBind();

                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            NewPagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[2].Rows[0][0]);
                            NewPagging1.pagesize = PageSize;
                            NewPagging1.numberpage = PageNumber;
                            NewPagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&id=" + id;
                            NewPagging1.queryparam = "?display=" + Display + "&w=" + Width + "&id=" + id + "&npage=";
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
                        Price = AppEnv.GetSetting("ringtoneprice") + "đ";
                    }
                }

            }
        }

    }
}
using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.HinhNen;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.HinhNen.UserControlLow
{
    public partial class HinhNen_New : BaseControl
    {
        readonly HinhNenController _hinhnenController = new HinhNenController();
        private const int PageSize = 6;
        private const int PageNumber = 5;
        private int _curpageTai = 1;
        private int _curpageMoi = 1;

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

            DataSet dsNew = _hinhnenController.GetGalleryAlbum(_curpageMoi, PageSize);

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
        }
    }
}
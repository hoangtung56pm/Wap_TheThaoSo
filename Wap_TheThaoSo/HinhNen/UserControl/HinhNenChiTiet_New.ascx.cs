using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.HinhNen;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.HinhNen.UserControl
{
    public partial class HinhNenChiTiet_New : BaseControl
    {
        readonly HinhNenController _hinhnenController = new HinhNenController();


        protected string AlbumName;
        protected string AlbumDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (id > 0)
            {
                DataSet ds = _hinhnenController.GetGalleryAlbumDetailNew(id);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        AlbumName = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                        AlbumDetail = ds.Tables[0].Rows[0]["AlbumDetail"].ToString();

                        rptAlbumDetail.DataSource = ds.Tables[0];
                        rptAlbumDetail.DataBind();
                    }

                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        rptOtherNews.DataSource = ds.Tables[1];
                        rptOtherNews.DataBind();
                    }
                }
            }
        }
    }
}
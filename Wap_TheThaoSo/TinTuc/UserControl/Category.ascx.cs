using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.TinTuc.UserControl
{
    public partial class Category : BaseControl
    {
        readonly TinTucController _tinTucController = new TinTucController();
        private const int PageSize = 10;
        private const int PageNumber = 5;
        private int _curpage = 1;
        protected string CategoryName;

        protected void Page_Load(object sender, EventArgs e)
        {
            int catId = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (catId > 0)
            {
                DataSet ds = _tinTucController.GetNewsByCatId(catId, _curpage, PageSize);
                if (ds != null)
                {
                    IList<DataRow> contentTop = ds.Tables[0].Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentBottom = ds.Tables[0].Select().Skip(1).Take(9).ToList();

                    if (catId == 138)
                        CategoryName = "Hậu Trường";
                    else
                        CategoryName = ds.Tables[2].Rows[0][0].ToString();
                    

                    rptContentTop.DataSource = contentTop.CopyToDataTable();
                    rptContentTop.DataBind();

                    rptContentBottom.DataSource = contentBottom.CopyToDataTable();
                    rptContentBottom.DataBind();

                    Pagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0][0]);
                    Pagging1.pagesize = PageSize;
                    Pagging1.numberpage = PageNumber;
                    Pagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID;
                    Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID + "&cpage=";
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

           

        }
    }
}
using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.CTKM;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo
{
    public partial class CTKM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CTKMcontroller ct = new CTKMcontroller();
                DataTable dt = ct.GetTopCTKMvisport();
                grv_user.DataSource = dt;
                grv_user.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string msisdn = txtuserid.Text.Trim();
            if (msisdn != string.Empty)
            {
                CTKMcontroller ct = new CTKMcontroller();
                DataTable dtu = ct.GetTopCTKMvisportByUser_ID(msisdn);
                if (dtu != null && dtu.Rows.Count > 0)
                {
                    lblresult.Text = "Bạn đang có "+dtu.Rows[0]["Total"].ToString()+" điểm, hiện đang xếp thứ "+ dtu.Rows[0]["Row"].ToString();
                }
                else
                {
                    lblresult.Text = "Không tìm thấy dữ liệu";
                }
            }
        }

       
    }
}
using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.TinTuc.UserControl
{
    public partial class Login : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["wifi"] != null)
            {
                pnlWifi.Visible = true;
            }
            else if (Session["regis"] != null)
            {
                pnlDangKyThanhCong.Visible = true;
            }
            else if (Session["unregis"] != null)
            {
                pnlDangKyThatBai.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtMsisdn.Text.Trim();
            string password = txtPassword.Text.Trim();

            var sql = new SqlProvider();
            DataTable dt = sql.CgbdGetRegisterUser(userId, password);
            if(dt.Rows.Count > 0)
            {
                Session["login"] = userId;
                Response.Redirect("/Wap/GameShow.aspx");
            }
            else
            {
                lblStatus.Text = "Tài khoản không tồn tại !";
                txtMsisdn.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }

        }
    }
}
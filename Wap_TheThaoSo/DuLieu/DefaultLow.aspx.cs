using System;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.DuLieu
{
    public partial class DefaultLow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEnv.GetMsisdn();
                ltrWidth.Text = "<meta content=\"width=" + Width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            switch (Display)
            {
                case "dulieu":
                    plContent.Controls.Add(LoadControl("UserControlLow/DuLieu.ascx"));
                    break;
                case "topghiban":
                    plContent.Controls.Add(LoadControl("UserControlLow/TopGhiBan.ascx"));
                    break;
                case "topbxh":
                    plContent.Controls.Add(LoadControl("UserControlLow/TopBxh.ascx"));
                    break;
                case "calendar":
                    plContent.Controls.Add(LoadControl("UserControlLow/Calendar.ascx"));
                    break;
                case "trandada":
                    plContent.Controls.Add(LoadControl("UserControlLow/TranDaDa.ascx"));
                    break;
                case "trandangda":
                    plContent.Controls.Add(LoadControl("UserControlLow/TranDangDa.ascx"));
                    break;
                case "livescore":
                    plContent.Controls.Add(LoadControl("UserControlLow/LiveScore.ascx"));
                    break;
                case "tuvan":
                    plContent.Controls.Add(LoadControl("UserControlLow/TuVan.ascx"));
                    break;
                case "cauthu":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietCauThu.ascx"));
                    break;
                case "doibong":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietDoiBong.ascx"));
                    break;
                case "trandau":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietTranDau.ascx"));
                    break;
                case "doihinh":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietTranDau_DoiHinh.ascx"));
                    break;
                case "tuongthuat":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "tyle":
                    plContent.Controls.Add(LoadControl("UserControlLow/ChiTietTranDau_TyLe.ascx"));
                    break;
                case "dsgiaidau":
                    plContent.Controls.Add(LoadControl("UserControlLow/DanhSachGiaiDau.ascx"));
                    break;
                case "dschitiet":
                    plContent.Controls.Add(LoadControl("UserControlLow/DanhSachGiaiDau_ChiTiet.ascx"));
                    break;
                case "b-trandau":
                    plContent.Controls.Add(LoadControl("UserControlLow/Bonus/ChiTietTranDau.ascx"));
                    break;
                case "ft-trandau":
                    plContent.Controls.Add(LoadControl("UserControlLow/Bonus/ChiTietTranDauKetThuc.ascx"));
                    break;
                case "b-tuongthuat":
                    plContent.Controls.Add(LoadControl("UserControlLow/Bonus/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "b-tyle":
                    plContent.Controls.Add(LoadControl("UserControlLow/Bonus/ChiTietTranDau_TyLe.ascx"));
                    break;
                case "b-doihinh":
                    plContent.Controls.Add(LoadControl("UserControlLow/Bonus/ChiTietTranDau_DoiHinh.ascx"));
                    break;
            }
        }
    }
}
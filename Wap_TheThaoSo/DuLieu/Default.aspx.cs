using System;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.DuLieu
{
    public partial class Default : BasePage
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
                    plContent.Controls.Add(LoadControl("UserControl/DuLieu.ascx"));
                    break;
                case "topghiban":
                    plContent.Controls.Add(LoadControl("UserControl/TopGhiBan.ascx"));
                    break;
                case "topbxh":
                    plContent.Controls.Add(LoadControl("UserControl/TopBxh.ascx"));
                    break;
                case "calendar":
                    plContent.Controls.Add(LoadControl("UserControl/Calendar.ascx"));
                    break;
                case "trandada":
                    plContent.Controls.Add(LoadControl("UserControl/TranDaDa.ascx"));
                    break;
                case "trandangda":
                    plContent.Controls.Add(LoadControl("UserControl/TranDangDa.ascx"));
                    break;
                case "livescore":
                    plContent.Controls.Add(LoadControl("UserControl/LiveScore.ascx"));
                    break;
                case "tuvan":
                    plContent.Controls.Add(LoadControl("UserControl/TuVan.ascx"));
                    break;
                case "cauthu":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietCauThu.ascx"));
                    break;
                case "doibong":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietDoiBong.ascx"));
                    break;
                case "trandau":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietTranDau.ascx"));
                    break;
                case "b-trandau":
                    //plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "ft-trandau":
                    //plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDauKetThuc.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "doihinh":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietTranDau_DoiHinh.ascx"));
                    break;
                case "b-doihinh":
                    plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau_DoiHinh.ascx"));
                    break;
                case "tuongthuat":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "b-tuongthuat":
                    plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau_TuongThuat.ascx"));
                    break;
                case "tyle":
                    plContent.Controls.Add(LoadControl("UserControl/ChiTietTranDau_TyLe.ascx"));
                    break;
                case "b-tyle":
                    plContent.Controls.Add(LoadControl("UserControl/Bonus/ChiTietTranDau_TyLe.ascx"));
                    break;
                case "dsgiaidau":
                    plContent.Controls.Add(LoadControl("UserControl/DanhSachGiaiDau.ascx"));
                    break;
                case "dschitiet":
                    plContent.Controls.Add(LoadControl("UserControl/DanhSachGiaiDau_ChiTiet.ascx"));
                    break;
            }
        }
    }
}
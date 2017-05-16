using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.DuLieu;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.DuLieu.UserControl
{
    public partial class DanhSachGiaiDau : System.Web.UI.UserControl
    {
        readonly DuLieuController _duLieuController = new DuLieuController();
        protected string QuocGiaLink;
        protected string ChauLucLink;
        protected string TheGioiLink;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dtQuocGia = _duLieuController.WapTheThaoSoGetCompetitionByAreaId(-1); // Default England
            DataTable dtChauLuc = _duLieuController.WapTheThaoSoGetCompetitionByAreaId(-2); // Default Chau A
            DataTable dtTheGioi = _duLieuController.WapTheThaoSoGetCompetitionByAreaId(ConvertUtility.ToInt32(AppEnv.GetSetting("World")));

            QuocGiaLink = UrlProcess.GetDanhSachGiaiDauChiTiet(2);
            ChauLucLink = UrlProcess.GetDanhSachGiaiDauChiTiet(1);
            TheGioiLink = UrlProcess.GetDanhSachGiaiDauChiTiet(3);

            if(dtQuocGia != null)
            {
                rptVoDichQuocGiavaCup.DataSource = dtQuocGia;
                rptVoDichQuocGiavaCup.DataBind();
            }

            if(dtChauLuc != null)
            {
                rptChauLuc.DataSource = dtChauLuc;
                rptChauLuc.DataBind();
            }

            if(dtTheGioi != null)
            {
                rptTheGioi.DataSource = dtTheGioi;
                rptTheGioi.DataBind();
            }

        }
    }
}
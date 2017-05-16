using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap.UserControl
{
    public partial class Home : BaseControl
    {
        readonly TinTucController _tinTucController = new TinTucController();

        protected int ResolutionWidth;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ResolutionWidth = Width;

            int anh = ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh"));
            int taybannha = ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha"));
            int italia = ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia"));
            int duc = ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc"));
            int namchau = ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau"));
            int vietnam = ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam"));
            int thethaoquocte = ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe"));

            DataSet ds = _tinTucController.GetHomeNews(anh, taybannha, italia, duc, namchau, vietnam, thethaoquocte);
            if(ds != null)
            {
                IList<DataRow> contentTop = ds.Tables[0].Select().Skip(0).Take(1).ToList();
                IList<DataRow> contentTopList = ds.Tables[0].Select().Skip(1).Take(5).ToList();

                rptContentTop.DataSource = contentTop.CopyToDataTable();
                rptContentTop.DataBind();

                rptContentTopList.DataSource = contentTopList.CopyToDataTable();
                rptContentTopList.DataBind();

                //Anh
                rptAnh.DataSource = ds.Tables[1];
                rptAnh.DataBind();

                rptAnhList.DataSource = ds.Tables[2];
                rptAnhList.DataBind();
                // End Anh

                //Tay Ban Nha
                rptTayBanNha.DataSource = ds.Tables[3];
                rptTayBanNha.DataBind();

                rptTayBanNhaList.DataSource = ds.Tables[4];
                rptTayBanNhaList.DataBind();
                //End Tay Ban Nha

                //Italia
                rptItalia.DataSource = ds.Tables[5];
                rptItalia.DataBind();

                rptItaliaList.DataSource = ds.Tables[6];
                rptItaliaList.DataBind();
                //End Italia

                //Duc
                rptDuc.DataSource = ds.Tables[7];
                rptDuc.DataBind();

                rptDucList.DataSource = ds.Tables[8];
                rptDucList.DataBind();
                //End Duc

                //5 Chau
                rptNamChau.DataSource = ds.Tables[9];
                rptNamChau.DataBind();

                rptNamChauList.DataSource = ds.Tables[10];
                rptNamChauList.DataBind();
                //End 5 Chau


                //Viet Nam
                rptVietNam.DataSource = ds.Tables[11];
                rptVietNam.DataBind();

                rptVietNamList.DataSource = ds.Tables[12];
                rptVietNamList.DataBind();
                //End Viet Nam


                //The Thao Quoc Te
                rptTheThaoQuocTe.DataSource = ds.Tables[13];
                rptTheThaoQuocTe.DataBind();

                rptTheThaoQuocTeList.DataSource = ds.Tables[14];
                rptTheThaoQuocTeList.DataBind();
                //End The Thao Quoc Te

                //Bong da Phap
                rptPhap.DataSource = ds.Tables[15];
                rptPhap.DataBind();

                rptPhapList.DataSource = ds.Tables[16];
                rptPhapList.DataBind();
                //End Bong da Phap

                //Chien Thang Nha Cai
                rptNhaCai.DataSource = ds.Tables[17];
                rptNhaCai.DataBind();

                rptNhaCaiList.DataSource = ds.Tables[18];
                rptNhaCaiList.DataBind();
                //End Chien Thang Nha Cai

                //Chuyen Sao
                rptChuyenSao.DataSource = ds.Tables[19];
                rptChuyenSao.DataBind();

                rptChuyenSaoList.DataSource = ds.Tables[20];
                rptChuyenSaoList.DataBind();
                //End Chuyen Sao

                //Chuyen Sao
                rptDiemTin.DataSource = ds.Tables[21];
                rptDiemTin.DataBind();

                rptDiemTinList.DataSource = ds.Tables[22];
                rptDiemTinList.DataBind();
                //End Chuyen Sao
            }
        }

        protected int GetAutoWidth()    
        {
            return ConvertUtility.ToInt32(Width*4/10);
        }
        protected int GetAutoWidth30()
        {
            return ConvertUtility.ToInt32(Width * 3 / 10);
        }
    }
}
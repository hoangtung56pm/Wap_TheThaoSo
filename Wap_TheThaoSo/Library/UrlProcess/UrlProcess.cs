using System.Configuration;
using System.Web;
using System.Web.Configuration;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.vn.xzone.payment;

namespace Wap_TheThaoSo.Library.UrlProcess
{
    public class UrlProcess : BaseControl
    {
        //static log4net.ILog log = log4net.LogManager.GetLogger("LogFile");

        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        public static string GetWidth()
        {
            int width = ConvertUtility.ToInt32(HttpContext.Current.Request.QueryString["w"]);
            if (width > 0)
                return width.ToString();

            return "320";
        }

        //Trang chu mac dinh
        public static string GetHomeUrl(string lang)
        {
            return "/Wap/Default.aspx?lang=" + lang;
        }
        public static string GetHomeUrl(string lang, string width)
        {
            return "/Wap/Default.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetHomeLowUrl(string lang,string width)
        {
            return "/Wap/DefaultLow.aspx?lang=" + lang + "&w=" + width;
        }
        //Trang chu redirect
        public static string GetOtherHomeUrl()
        {
            return "/Other/Home.aspx";
        }


        #region New

        public static string GetTranCauVangUrl()
        {
            return "/DuLieu/Default.aspx?display=tuvan&w=320&id=4B4619C7-531B-4856-ABA5-A38593CBCFC9";
        }

        public static string GetTranCauVangLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?display=tuvan&w=320&id=4B4619C7-531B-4856-ABA5-A38593CBCFC9";
        }

        public static string GetNewsSearchResultUrl(string key)
        {
            return "/TinTuc/Default.aspx?lang=" + Getlang() + "&display=search&w=320&key=" + key;
        }

        public static string GetNewsSearchResultLowUrl(string key)
        {
            return "/TinTuc/DefaultLow.aspx?lang=" + Getlang() + "&display=search&w=320&key=" + key;
        }

        public static string GetOptionDetailUrl(int catid, int id, int type)
        {
            if (type == 1)
                return GetNewsDetailUrl(catid, id);
            else
                return BuildAudioBookDetailLink(catid, id);
        }

        public static string GetNewsDetailUrl(int catid, int id)
        {
            return "/TinTuc/Default.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        public static string GetNewsDetailLowUrl(int catid, int id)
        {
            return "/TinTuc/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        public static string GetNewsCategoryUrl(int catid)
        {
            return "/TinTuc/Default.aspx?lang=" + Getlang() + "&display=list&w=" + GetWidth() + "&catid=" + catid;
        }

        public static string GetNewsCategoryLowUrl(int catid)
        {
            return "/TinTuc/DefaultLow.aspx?lang=" + Getlang() + "&display=list&w=" + GetWidth() + "&catid=" + catid;
        }

        public static string BuildAudioBookDetailLink(int catId, int id)
        {
            return "/AudioBook/Default.aspx?lang=" + Getlang() + "&display=detail&w=320&catid=" + catId + "&id=" + id;
        }


        public static string BuildMucisIntructionList(int catId)
        {
            return "/Video/Default.aspx?lang=" + Getlang() + "&display=lstvideo&w=320&catid=" + catId;
        }

        public static string BuildAudioBookList(int catId)
        {
            return "/AudioBook/Default.aspx?lang=" + Getlang() + "&display=list&w=320&catid=" + catId;
        }
        public static string BuildAudioBookHome()
        {
            return "/AudioBook/Default.aspx?lang=" + Getlang() + "&display=home&w=320";
        }


        #endregion

        #region Hinh nen

        public static string GetHinhNenHomeUrl()
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=hinhnen&w=" + GetWidth();
        }

        public static string GetHinhNenHomeNewUrl()
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=hinhnenn&w=" + GetWidth();
        }

        public static string GetHinhNenHomeLowUrl()
        {
            return "/HinhNen/DefaultLow.aspx?lang=" + Getlang() + "&display=hinhnen&w=" + GetWidth();
        }

        public static string GetHinhNenHomeLowNewUrl()
        {
            return "/HinhNen/DefaultLow.aspx?lang=" + Getlang() + "&display=hinhnenn&w=" + GetWidth();
        }

        public static string GetHinhNenDetailUrl(int id)
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=detail&w=320&id=" + id;
        }

        public static string GetHinhNenDetailLowUrl(int id)
        {
            return "/HinhNen/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=320&id=" + id;
        }

        public static string GetHinhNenDetailUrl(int catid, int id)
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=detail&w=320&catid=" + catid + "&id=" + id;
        }

        public static string GetHinhNenDetailNewUrl(int catid, int id)
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=detailn&w=320&catid=" + catid + "&id=" + id;
        }

        public static string GetHinhNenDetailLowUrl(int catid, int id)
        {
            return "/HinhNen/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=320&catid=" + catid + "&id=" + id;
        }

        public static string GetHinhNenDetailNewLowUrl(int catid, int id)
        {
            return "/HinhNen/DefaultLow.aspx?lang=" + Getlang() + "&display=detailn&w=320&catid=" + catid + "&id=" + id;
        }

        public static string GetHinhNenGalleryUrl(int catid)
        {
            return "/HinhNen/Default.aspx?lang=" + Getlang() + "&display=gallerydetail&w=320&catid=" + catid;
        }
        #endregion

        #region Video

        public static string GetVideoHomeUrl()
        {
            return "/Video/Default.aspx?lang=" + Getlang() + "&display=video&w=" + GetWidth();
        }

        public static string GetVideoHomeLowUrl()
        {
            return "/Video/DefaultLow.aspx?lang=" + Getlang() + "&display=video&w=" + GetWidth();
        }

        public static string GetVideoDetailUrl(int catid, int id)
        {
            return "/Video/Default.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        public static string GetVideoDetailLowUrl(int catid, int id)
        {
            return "/Video/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        public static string GetVideoDetailUrl(int id)
        {
            return "/Video/Default.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetVideoDetailLowUrl(int id)
        {
            return "/Video/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetVideoCategoryUrl(int catid)
        {
            return "/Video/Default.aspx?lang=" + Getlang() + "&display=category&w=" + GetWidth() + "&catid=" + catid;
        }

        public static string GetVideoCategoryLowUrl(int catid)
        {
            return "/Video/DefaultLow.aspx?lang=" + Getlang() + "&display=category&w=" + GetWidth() + "&catid=" + catid;
        }

        #endregion

        #region NhacChuong

        public static string GetNhacChuongHomeUrl()
        {
            return "/NhacChuong/Default.aspx?lang=" + Getlang() + "&display=nhacchuong&w=" + GetWidth();
        }

        public static string GetNhacChuongHomeLowUrl()
        {
            return "/NhacChuong/DefaultLow.aspx?lang=" + Getlang() + "&display=nhacchuong&w=" + GetWidth();
        }

        public static string GetNhacChuongDetailUrl(int catid, int id)
        {
            return "/NhacChuong/Default.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        public static string GetNhacChuongDetailLowUrl(int catid, int id)
        {
            return "/NhacChuong/DefaultLow.aspx?lang=" + Getlang() + "&display=detail&w=" + GetWidth() + "&catid=" + catid + "&id=" + id;
        }

        #endregion

        #region DuLieu

        public static string NavigateUrlView(string status,int id)
        {
            string returnValue;

            if (status == "Played")
            {
                returnValue = GetChiTietTranDauTuongThuatBonus(id);
            }
            else
            {
                returnValue = GetChiTietTranDauTyLeBonus(id);
            }

            return returnValue;
        }

        public static string NavigateUrlViewLow(string status, int id)
        {
            string returnValue;

            if (status == "Played")
            {
                returnValue = GetChiTietTranDauTuongThuatLowBonus(id);
            }
            else
            {
                returnValue = GetChiTietTranDauTyLeLowBonus(id);
            }

            return returnValue;
        }

        public static string GetLinkName(string status,string rateAsia)
        {
            string returnValue;

            if (status == "Played")
            {
                returnValue = "Xem";
            }
            else
            {
                returnValue = rateAsia;
            }

            return returnValue;
        }

        public static string NavigateUrl(string status, int id)
        {
            string returnValue;

            if (status == "Played")
            {
                returnValue = GetChiTietTranDauKetThucUrlBonus(id);
            }
            else
            {
                returnValue = GetChiTietTranDauUrlBonus(id);
            }

            return returnValue;
        }

        public static string NavigateUrlLow(string status, int id)
        {
            string returnValue;

            if (status == "Played")
            {
                returnValue = GetChiTietTranDauKetThucLowUrlBonus(id);
            }
            else
            {
                returnValue = GetChiTietTranDauLowUrlBonus(id);
            }

            return returnValue;
        }

        public static int Getlang()
        {
            int lang = ConvertUtility.ToInt32(HttpContext.Current.Request.QueryString["lang"]);
            return lang;
        }

        public static string GetDuLieuHomeUrl()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=dulieu&w=" + GetWidth();
        }

        public static string GetDuLieuHomeLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=dulieu&w=" + GetWidth();
        }

        public static string GetTopGhiBanUrl(int competitionId)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=topghiban&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetTopGhiBanLowUrl(int competitionId)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=topghiban&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetTopBxhUrl(int competitionId)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=topbxh&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetTopBxhLowUrl(int competitionId)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=topbxh&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetLichThiDau(int competitionId)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=calendar&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetLichThiDauLow(int competitionId)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=calendar&w=" + GetWidth() + "&catid=" + competitionId;
        }

        public static string GetTranDaDaUrl()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=trandada&w=" + GetWidth();
        }

        public static string GetTranDaDaLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=trandada&w=" + GetWidth();
        }

        public static string GetTranDangDaUrl()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=trandangda&w=" + GetWidth();
        }

        public static string GetTranDangDaLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=trandangda&w=" + GetWidth();
        }

        public static string GetLivescoreUrl()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=livescore&w=" + GetWidth();
        }

        public static string GetLivescoreLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=livescore&w=" + GetWidth();
        }

        public static string GetTuVanUrl()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=tuvan&w=" + GetWidth();
        }

        public static string GetTuVanLowUrl()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=tuvan&w=" + GetWidth();
        }

        public static string GetChiTietCauThuUrl(int catId, int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=cauthu&w=" + GetWidth() + "&catid=" + catId + "&id=" + id;
        }

        public static string GetChiTietCauThuLowUrl(int catId, int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=cauthu&w=" + GetWidth() + "&catid=" + catId + "&id=" + id;
        }

        public static string GetChiTietDoiBongUrl(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=doibong&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietDoiBongLowUrl(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=doibong&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauUrl(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauUrlBonus(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=b-trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauKetThucUrlBonus(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=ft-trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauKetThucLowUrlBonus(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=ft-trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauLowUrl(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauLowUrlBonus(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=b-trandau&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauDoiHinhUrl(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=doihinh&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauDoiHinhUrlBonus(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=b-doihinh&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauDoiHinhLowUrlBonus(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=b-doihinh&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauDoiHinhLowUrl(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=doihinh&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTuongThuat(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=tuongthuat&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTuongThuatBonus(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=b-tuongthuat&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTuongThuatLowBonus(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=b-tuongthuat&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTuongThuatLow(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=tuongthuat&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTyLe(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=tyle&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTyLeBonus(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=b-tyle&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTyLeLowBonus(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=b-tyle&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetChiTietTranDauTyLeLow(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=tyle&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetDanhSachGiaiDau()
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=dsgiaidau&w=" + GetWidth();
        }

        public static string GetDanhSachGiaiDauLow()
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=dsgiaidau&w=" + GetWidth();
        }


        public static string GetDanhSachGiaiDauChiTiet(int id)
        {
            return "/DuLieu/Default.aspx?lang=" + Getlang() + "&display=dschitiet&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetDanhSachGiaiDauChiTietLow(int id)
        {
            return "/DuLieu/DefaultLow.aspx?lang=" + Getlang() + "&display=dschitiet&w=" + GetWidth() + "&id=" + id;
        }

        public static string GetSmsUrl(string lang, string width)
        {
            return "/Wap/Sms.aspx?display=sms&lang=" + lang + "&w=" + width;
        }

        public static string GetSmsUrlLow(string lang, string width)
        {
            return "/Wap/SmsLow.aspx?display=sms&lang=" + lang + "&w=" + width;
        }

        #endregion

        public static string GetRingToneDownloadItem(string telco, string itemtype, string itemid, string encode)
        {
            //itemtype = 1 : hinh nen
            //itemtype = 2 : Nhac chuong
            //itemtype = 22 : Am nhac
            //itemtype = 3: game
            //itemtype = 4: app
            //itemtype = 5: video
            //itemtype = 6: y kien chuyen gia
            //itemtype = 7: tip
            //itemtype = 8: ket qua cho
            //itemtype = 9: ket qua xo so
            //itemtype = 10: soi cau
            //itemtype = 11: ket qua xoso cho
            //itemtype = 12: ket qua xoso 20 ngay lien tiep
            //itemtype = 13: truyen cuoi
            return AppEnv.GetSetting("vnmdownload") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        }

        public static string GetDownloadItem(string telco, string itemtype, string itemid, string encode)
        {
            //itemtype = 1 : hinh nen
            //itemtype = 2 : Nhac chuong
            //itemtype = 6: y kien chuyen gia
            //itemtype = 5: video
            // 20 : tk dac biet
            // 14 : tran cau vang
            // 7 : Tip

            return AppEnv.GetSetting("download") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        }

        public static string GetDownloadVideoItem(string telco, string itemtype, string itemid, string encode)
        {
            return AppEnv.GetSetting("downloadVideo") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        }

        public static string GetWallpaperHomeUrl(string lang, string width)
        {
            return "/HinhNen/Default.aspx?lang=" + lang + "&display=hinhnen&w=" + width;
        }
        //Trang tải ảnh
        public static string GetWallpaperDownloadUrl(string lang, string width, string id, string catid)
        {
            return "/Hinhnen/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string GetWallpaperDownloadLowUrl(string lang, string width, string id, string catid)
        {
            return "/Hinhnen/DownloadLow.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        //Trang tặng ảnh
        public static string GetWallpaperSendGiftUrl(string lang, string width, string id, string sdt, string catid)
        {
            return "/Hinhnen/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt + "&catid=" + catid;
        }

        //Trang tải video
        public static string GetVideoDownloadUrl(string lang, string width, string id, string catid)
        {
            return "/Video/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string GetVideoDownloadLowUrl(string lang, string width, string id, string catid)
        {
            return "/Video/DownloadLow.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        //Trang xem video
        public static string GetVideoXemUrl(string lang, string width, string id, string catid)
        {
            return "/Video/Xem.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string GetVideoXemLowUrl(string lang, string width, string id, string catid)
        {
            return "/Video/XemLow.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        //Trang tải nhac chuong
        public static string GetRingToneDownloadUrl(string lang, string width, string id, string catid)
        {
            return "/NhacChuong/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string GetRingToneDownloadLowUrl(string lang, string width, string id, string catid)
        {
            return "/NhacChuong/DownloadLow.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        //Trang tải nhac chuong
        public static string GetTuVanDownloadUrl(string lang, string width, string id, string catid)
        {
            return "/DuLieu/TuVanDacBiet.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string GetTuVanDownloadLowUrl(string lang, string width, string id, string catid)
        {
            return "/DuLieu/TuVanDacBietLow.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }

        public static string BuildUrlCharging(object price, object itemId, object itemtype, object itemName, object pageDisplayContentUrl)
        {
            if (AppEnv.GetSetting("TestFlag") == "1")
            {
                return pageDisplayContentUrl.ToString();
            }
            else
            {
                DesSecurity des = new DesSecurity();

                if (HttpContext.Current.Session["MSISDN"] != null)
                {
                    string msisdn = ConvertUtility.ToString(HttpContext.Current.Session["MSISDN"].ToString());
                    string telco = ConvertUtility.ToString(HttpContext.Current.Session["Telco"].ToString());
                    string transactionid = ConvertUtility.ToString(HttpContext.Current.Session["TransID"].ToString());

                    if (msisdn != "" && telco != "0")
                    {
                        AuthSoapHd objAuthSoapHeader = new AuthSoapHd();
                        srti oPayment = new srti();
                        objAuthSoapHeader.strUserName = AppEnv.GetSetting("PartnerID");
                        objAuthSoapHeader.strPassword = AppEnv.GetSetting("Password");
                        oPayment.AuthSoapHdValue = objAuthSoapHeader;
                        string result = oPayment.SendTransactionInfo(transactionid, msisdn, itemId.ToString(), itemName.ToString(), itemtype.ToString(), price.ToString(), pageDisplayContentUrl.ToString());
                        string[] arrresult = result.Split('|');

                        //log.Info("arrresult = " + arrresult);
                       
                        if (ConvertUtility.ToInt32(arrresult[0]) == 1)
                        {
                            return "http://" + AppEnv.GetSetting("PaymentDomain") + "/tc.aspx?t=" + arrresult[1];
                        }

                        return AppEnv.GetSetting("WapDefault");
                    }
                    else
                    {
                        return AppEnv.GetSetting("WapDefault");
                    }
                }
                else
                {
                    return AppEnv.GetSetting("WapDefault");
                }
            }
        }

    }
}
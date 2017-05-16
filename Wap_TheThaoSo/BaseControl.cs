using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo
{
    public class BaseControl : System.Web.UI.UserControl
    {
        public int Lang
        {
            get
            {
                return ((BasePage)this.Page).Lang;
            }
        }

        public int Width
        {
            get
            {
                return ((BasePage)this.Page).Width;
            }
        }

        public string UrlData
        {
            get
            {
                return ((BasePage)this.Page).UrlData;
            }
        }

        public string Type
        {
            get
            {
                return ConvertUtility.ToString(Request.QueryString["t"]);
            }
        }

        public string Display
        {
            get
            {
                return ((BasePage)this.Page).Display;
            }
        }

        public int CatID
        {
            get
            {
                return ((BasePage)this.Page).CatID;
            }
        }

        public int ID
        {
            get
            {
                return ((BasePage)this.Page).ID;
            }
        }

        public int CategoryType
        {
            get
            {
                return ((BasePage)this.Page).CategoryType;
            }
        }

        public UserInfo CurrentUser
        {
            get
            {
                return ((BasePage)this.Page).CurrentUser;
            }
            set
            {
                ((BasePage)this.Page).CurrentUser = value;
            }
        }

        #region Game
        public string ClipCommandCode
        {
            get
            {
                return "DA";
            }
        }

        public string GameCommandCode
        {
            get
            {
                return "DA";
            }
        }

        #endregion

        public string WallpaperCommandCode
        {
            get
            {
                return "WA";
            }
        }

        public string ThemeCommandCode
        {
            get
            {
                return "DA";
            }
        }


        public string LogoCommandCode
        {
            get
            {
                if (Display.ToLower() == "lmdetail")
                {
                    return "AM";
                }
                if (Display.ToLower() == "ldtdetail")
                {
                    return "LG";
                }
                if (Display.ToLower() == "lddetail")
                {
                    return "MG";
                }
                return "LM";
            }
        }

        public string ServiceID(string price)
        {
            if (price == "1000") return "8179";
            if (price == "3000") return "8379";
            if (price == "4000") return "8479";
            if (price == "5000") return "8579";
            if (price == "10000") return "8679";
            if (price == "15000") return "8779";
            return "8279";
        }

        //public string AmNhacCommandCode
        //{
        //    get
        //    {
        //        if (CategoryType == (int)Constant.AmNhac.NhacMp3)
        //        {
        //            return AppEnv.GetSetting("NhacMP3_CommandCode");
        //        }
        //        if (CategoryType == (int)Constant.AmNhac.NhacCho)
        //        {
        //            return AppEnv.GetSetting("NhacCho_CommandCode");
        //        }
        //        return AppEnv.GetSetting("NhacChuong_CommandCode");
        //    }
        //}

        public string NhacChoSericeID
        {
            get { return "9194"; }
        }

        public string NhacChoDownloadCommandCode
        {
            get { return "Tune"; }
        }

        public string NhacChoGiftCommandCode
        {
            get { return "Tang"; }
        }

        public string NhacChoSetCommandCode
        {
            get { return "set"; }
        }

        public User_AgentInfo UserAgentInfo
        {
            get
            {
                return ((BasePage)this.Page).UserAgentInfo;
            }
        }
    }
}
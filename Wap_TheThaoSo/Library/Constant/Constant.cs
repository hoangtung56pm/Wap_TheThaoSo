namespace Wap_TheThaoSo.Library.Constant
{
    public class Constant
    {
        public static string tintucchung = "00";
        public static string thethao = "02";
        public static string nhacchuong = "21";
        public static string hinhnen = "31";
        public static string clipchung = "40";         

        public enum ItemType
        {
            HinhNen = 3,
            NhacChuong = 2,
            Video = 5,
            DuLieuBongDa = 1,
        }

        public enum Game
        {
            Plus = 2,
            //La Moi nhat 
            SamsungGame = 11,
        }

        //Man hinh mac dinh
        public enum DefaultScreen
        {
            Standard = 320,
        }
        //Portal mac dinh
        public enum DefaultPortal
        {
            WapDaLink = 96,
        }

        //Cau hinh telCo
        public static string T_Undefined = "Undefined";
        public static string T_Mobifone = "Mobifone";
        public static string T_Vinaphone = "Vinaphone";
        public static string T_Viettel = "Viettel";
        public static string T_Vietnamobile = "Vietnamobile";
        public static string T_EVN = "EVN";

        public enum HinhNen
        {
            AnhDong = 4,
            AnhNen = 8,
            Themes = 9,
            Logo = 10,
        }

        public enum AmNhac
        {
            NhacMp3 = 1,
            NhacChuong = 2,
            NhacCho = 3
        }

        public enum ChancelComment
        {
            Game = 1,
            Wallpager = 2,
            Mp3 = 3,
            RingTone = 4,
            Rbt = 5,
            Theme = 6,
            Logo = 7,
            Clip = 8,
        }
    }
}
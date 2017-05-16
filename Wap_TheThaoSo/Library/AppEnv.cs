using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Configuration;
using HtmlAgilityPack;
using WapJavaGame.Library.Utilities;
using Wap_TheThaoSo.Library.Utilities;
using System.Web;
using Wap_TheThaoSo.SentMT;
using Wap_TheThaoSo.VisportNew;

namespace Wap_TheThaoSo.Library
{
    public class AppEnv
    {

        public static void GetMsisdn()
        {
            //use test only
            if (GetSetting("TestFlag") == "1")
            {
                //HttpContext.Current.Session["msisdn"] = "84989999999";
                HttpContext.Current.Session["msisdn"] = "Khách";
                HttpContext.Current.Session["telco"] = Constant.Constant.T_Vietnamobile;
            }
            else
            {
                if (HttpContext.Current.Session["msisdn"] == null)
                {
                    HttpContext.Current.Response.Redirect("http://wap.vietnamobile.com.vn/pm/getmsisdnvsport.aspx");
                }
            }
        }

        public static void GetMsisdnWithParam(string param)
        {
            //use test only
            //if (GetSetting("TestFlag") == "1")
            //{
            //    //HttpContext.Current.Session["msisdn"] = "84989999999";
            //    HttpContext.Current.Session["msisdn"] = "841886602010";
            //    HttpContext.Current.Session["telco"] = Constant.Constant.T_Vietnamobile;
            //}
            //else
            //{
                if (HttpContext.Current.Session["msisdn"] == null)
                {
                    HttpContext.Current.Response.Redirect("http://wap.vietnamobile.com.vn/pm/getmsisdnvsport.aspx?t=" + param);
                }
            //}
        }
        public static string RegisterService(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
            VnmVsp add = new VnmVsp();
            string reString = add.RegisterService(shortCode, requestId, msisdn, commandcode, message); ;
            //if (GetSetting("trachamMT") == "0")
            //{
            //    reString = S2Vnm.RegisterServiceTrachamMT(shortCode, requestId, msisdn, commandcode, message);
            //}
            //else
            //{
             //   reString = add.RegisterService(shortCode, requestId, msisdn, commandcode, message);
            //}

            return reString;
        }
        public static string TranslateApi(string type, string name, string minute)
        {
            string content = string.Empty;
            if (type == "substitute_in")
            {
                content = "Phút thứ " + minute + " " + name + " được tung vào sân !";
            }
            else if (type == "substitute_out")
            {
                content = "Phút thứ " + minute + " " + name + " được thay ra sân !";
            }
            else if (type == "yellow_card")
            {
                content = "Phút thứ " + minute + " " + name + " nhận thẻ vàng !";
            }
            else if (type == "yellow_red_card")
            {
                content = "Phút thứ " + minute + " " + name + " nhận thẻ vàng thứ 2 !";
            }
            else if (type == "red_card")
            {
                content = "Phút thứ " + minute + " " + name + " nhận thẻ đỏ trực tiếp !";
            }
            else if (type == "goal")
            {
                content = "Phút thứ " + minute + " " + name + " ghi bàn thắng !";
            }
            else if (type == "penalty_goal")
            {
                content = "Phút thứ " + minute + " " + name + " ghi bàn thắng trên chấm phạt đền !";
            }
            else if (type == "own_goal")
            {
                content = "Phút thứ " + minute + " " + name + " đá phản lưới nhà !";
            }

            return content;
        }
        public static string GetViewLink(string smartPhone, string mobilePath)
        {
            string viewLink;

            if (!string.IsNullOrEmpty(smartPhone))
                viewLink = smartPhone;
            else
                viewLink = mobilePath;

            if (HttpContext.Current.Request.UserAgent != null)
            {
                if (HttpContext.Current.Request.UserAgent.ToLower().Contains("safari"))
                {
                    return GetSetting("vnmviewIphone") + viewLink.Replace("~/", "/");
                }
                return GetSetting("vnmview") + viewLink.Replace("~/Upload/Video", "");
            }
            return GetSetting("vnmview") + viewLink.Replace("~/Upload/Video", "");
        }

        public static string GetViewLinkLow(string mobilePath)
        {
            return GetSetting("vnmview") + mobilePath.Replace("~/Upload/Video", "");
        }


        public static string ToTimeSinceString(DateTime value)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - value.Ticks);
            double seconds = ts.TotalSeconds;

            if (seconds < 1 * MINUTE)
                return ts.Seconds == 1 ? "1 giây trước" : ts.Seconds + " giây trước";

            if (seconds < 60 * MINUTE)
                return ts.Minutes + " phút trước";

            if (seconds < 120 * MINUTE)
                return "1 giờ trước";

            if (seconds < 24 * HOUR)
                return ts.Hours + " giờ trước";

            if (seconds < 48 * HOUR)
                return "1 ngày trước";

            if (seconds < 30 * DAY)
                return ts.Days + " ngày trước";

            if (seconds < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1 tháng trước" : months + " tháng trước";
            }

            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "1 năm trước" : years + " năm trước";
        }

        public static string GetTelco(string telcoInput)
        {
            string telco = "viettel";

            if (telcoInput == "3")
            {
                telco = "viettel";
            }
            else if (telcoInput == "2")
            {
                telco = "vinaphone";
            }
            else if (telcoInput == "1")
            {
                telco = "mobifone";
            }
            else if (telcoInput == "4")
            {
                telco = "vietnamobile";
            }

            return telco;
        }

        public static string BuildUrlGetMSISDN()
        {
            DesSecurity des = new DesSecurity();
            return "http://" + AppEnv.GetSetting("PaymentDomain") + "/sc.aspx?pid=" + AppEnv.GetSetting("PartnerID") + "&k=" + des.Des3Encrypt(AppEnv.GetSetting("PartnerID") + "|" + DateTime.Now.ToString("HHmm"), AppEnv.GetSetting("Password"));
        }
       
        public enum CompetetionStatus
        {
            Fixture = 0,
            Playing = 1,
            Played = 2,
            AllMatch = -1,
        }

        //public static string Translate(string type, string content)
        //{
        //    string SI = " được tung vào sân thay cho ";
        //    string YC = " nhận thẻ vàng của trọng tài ";
        //    string G = " ghi bàn thắng ";
        //    string AB = " được kiến tạo bởi ";
        //    string RC = " bị đuổi khỏi sân vì nhận thẻ đỏ trực tiếp ";
        //    string PS = " Không vào!!! Thủ thành xxx đã cản phá được cú sút 11m của đối phương ";
        //    string PG = " Vào!!! Xxx ghi bàn thắng cho zzz từ chấm 11m ";
        //    string Y2C = " bị đuổi khỏi sân vì nhận thẻ vàng thứ hai ";
        //    string OG = " Vào!!! Xxx đã vô tình ghi bàn phản lưới nhà";
        //    string SO = " rời sân ";
        //    string PSG = " sút luân lưu ";

        //    switch (type)
        //    {
        //        case "YC":
        //            content = content.Replace("gets yellow.", YC);

        //            break;
        //        case "G":
        //            content = content.Replace("has scored a goal", G);
        //            content = content.Replace("!", " ");
        //            content = content.Replace("for", " cho ");
        //            content = content.Replace("Assist by", " từ đường chuyền của ");
        //            content = "Vào !!! " + content;
        //            break;
        //        case "PG":
        //            int nameposition = content.IndexOf("!");
        //            if (content.Length != nameposition + 1)
        //            {
        //                string name1 = content.Substring(nameposition + 27);
        //                content = content.Replace(name1, "");
        //                content = content.Replace("It was awarded thanks to", "sau khi xxx bị phạm lỗi trong vòng cấm ");
        //                content = content.Replace("xxx", name1);
        //            }
        //            content = content.Replace("Penalty goal scored by", "Vào!!! ");
        //            content = content.Replace("for", " ghi bàn thắng từ chấm 11m cho ");
        //            break;
        //        case "SI":
        //            content = content.Replace("enters the game and replaces", SI);
        //            break;
        //        case "RC":
        //            content = content.Replace("goes off after a red card!", RC);
        //            break;
        //        case "Y2C":
        //            content = content.Replace("gets a second yellow card and is sent off.", Y2C);
        //            break;
        //        case "OG":
        //            string name2 = content.Replace("is unfortunate, scores an own goal!", "");
        //            content = content.Replace("is unfortunate, scores an own goal!", OG);

        //            content = content.Replace(name2, "");
        //            content = content.Replace("Xxx", name2);
        //            break;
        //        case "SO":
        //            content = content.Replace("is substituted out.", SO);
        //            break;
        //        case "PS":
        //            string name = content.Substring(16);
        //            name = name.Replace("!", "");
        //            content = content.Replace(name, "");
        //            content = content.Replace("Penalty saved by", PS);


        //            content = content.Replace("xxx", name);
        //            break;
        //        case "PSG":
        //            content = content.Replace("Penalty shootout:", PSG);
        //            content = content.Replace("scored!", " đã ghi điểm");
        //            break;
        //        case "PSM":
        //            content = content.Replace("Penalty shootout:", PSG);
        //            content = content.Replace("missed!", " đã đá trượt");
        //            break;

        //    }

        //    return content;
        //}

        public static string Translate(string type, string content)
        {
            const string AS = "Kiến tạo bởi ";
            const string AS1 = "là cầu thủ kiến tạo";
            const string AS2 = "Cầu thủ kiến tạo";
            const string AS3 = " từ đường chuyền của ";
            const string SI = " được tung vào sân thay cho ";
            const string SI1 = " được thay ra bởi ";
            const string SI2 = " được thay ra nghỉ";
            const string SI3 = " được tung vào sân";
            const string YC = " nhận thẻ vàng của trọng tài ";
            const string G = " ghi bàn thắng ";
            const string G1 = " người lập công là ";
            const string G2 = "đã ghi bàn thắng cho";
            const string G3 = "Bàn thắng cho";
            const string G4 = "cầu thủ đã ghi bàn là";
            const string AB = " được kiến tạo bởi ";
            const string RC = " bị đuổi khỏi sân vì nhận thẻ đỏ trực tiếp ";
            const string PS = " Không vào!!! Thủ thành xxx đã cản phá được cú sút 11m của đối phương ";
            const string PG = " Vào!!! Xxx ghi bàn thắng cho zzz từ chấm 11m ";
            const string Y2C = " bị đuổi khỏi sân vì nhận thẻ vàng thứ hai ";
            const string OG = " Vào!!! Xxx đã vô tình ghi bàn phản lưới nhà";
            const string SO = " rời sân ";
            const string PSG = " sút luân lưu ";
            const string imgYC = "/App_Themes/Sport/images/YC.png";
            const string imgY2C = "/App_Themes/Sport/images/Y2C.png";
            const string imgRC = "/App_Themes/Sport/images/red-card.jpg";
            const string imgout = "/App_Themes/Sport/images/out.png";
            const string imgin = "/App_Themes/Sport/images/in.png";
            const string imggoal = "/App_Themes/Sport/images/ball2.png";
            const string imgpenaltygoal = "/App_Themes/Sport/images/PG.png";
            const string imgourgoal = "/App_Themes/Sport/images/ball1.png";
            switch (type)
            {
                case "AS":
                    content = content.Replace("Assist by", AS);
                    content = content.Replace("provided the assist", AS1);
                    content = content.Replace("gave the assist", AS1);
                    content = content.Replace("The assist came from", AS2);
                    break;
                case "YC":
                    content = content.Replace("gets yellow.", YC);
                    content = content.Replace("is yellow-carded.", YC);
                    content = content.Replace("receives a yellow card.", YC);
                    content = content.Replace("goes into the referee-s book.", YC);
                    content = content.Replace("is cautioned by the referee", YC);
                    //img.ImageUrl = imgYC;

                    break;
                case "G":
                    {
                        int index = content.IndexOf("has scored a goal");
                        if (index > 0)
                        {
                            content = content.Replace("has scored a goal", G);
                            content = content.Replace("!", " ");
                            content = content.Replace("for", " cho ");
                            content = content.Replace("Assist by", AS3);
                            content = "Vào !!! " + content;
                        }
                        int index1 = content.IndexOf("score a goal through");
                        if (index1 > 0)
                        {
                            content = content.Replace("score a goal through", G1);
                            content = content.Replace("!", " ");
                            content = "Vào !!! Bàn thắng cho " + content;
                        }
                        content = content.Replace("hits the net for", G2);
                        content = content.Replace("has found the target for", G2);
                        content = content.Replace("scores for", G2);
                        content = content.Replace("Goal to", G3);
                        content = content.Replace("scored by", G4);

                    }
                    //img.ImageUrl = imggoal;
                    break;
                case "PG":
                    int nameposition = content.IndexOf("!");
                    if (content.Length != nameposition + 1)
                    {
                        string name1 = content.Substring(nameposition + 27);
                        content = content.Replace(name1, "");
                        content = content.Replace("It was awarded thanks to", "sau khi xxx bị phạm lỗi trong vòng cấm ");
                        content = content.Replace("xxx", name1);
                    }
                    content = content.Replace("Penalty goal scored by", "Vào!!! ");
                    content = content.Replace("for", " ghi bàn thắng từ chấm 11m cho ");

                    //img.ImageUrl = imgpenaltygoal;
                    break;
                case "SI":
                    content = content.Replace("enters the game and replaces", SI);
                    content = content.Replace("enters play, replacing", SI);
                    content = content.Replace("is replaced with", SI1);
                    content = content.Replace("is done for the day", SI2);
                    content = content.Replace("is his replacement", SI3);
                    content = content.Replace("comes on for", SI);
                    //img.ImageUrl = imgin;
                    break;
                case "RC":
                    content = content.Replace("goes off after a red card!", RC);
                    content = content.Replace("receives a red card!", RC);
                    //img.ImageUrl = imgRC;
                    break;
                case "Y2C":
                    content = content.Replace("gets a second yellow card and is sent off.", Y2C);
                    content = content.Replace("gets a second yellow card and is sent off!", Y2C);
                    //img.ImageUrl = imgY2C;
                    break;
                case "OG":
                    string name2 = content.Replace("is unfortunate, scores an own goal!", "");
                    content = content.Replace("is unfortunate, scores an own goal!", OG);

                    content = content.Replace(name2, "");
                    content = content.Replace("Xxx", name2);
                    //img.ImageUrl = imgourgoal;
                    break;
                case "SO":
                    content = content.Replace("is substituted out.", SO);
                    //img.ImageUrl = imgout;
                    break;
                case "PS":
                    string name = content.Substring(16);
                    name = name.Replace("!", "");
                    content = content.Replace(name, "");
                    content = content.Replace("Penalty saved by", PS);


                    content = content.Replace("xxx", name);
                    break;
                case "PSG":
                    content = content.Replace("Penalty shootout:", PSG);
                    break;
            }

            return content;
        }

        public static string ConvertTime(string input)
        {
            string strReturn;
            int num = ConvertUtility.ToInt32(input);

            if (num < 10)
                strReturn = "0" + num;
            else
                strReturn = num.ToString();

            return strReturn;
        }

        public static string ConnectionString
        {
            get
            {
                string con = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                return con;
            }
        }

        public static string ConnectionString177
        {
            get
            {
                string con = WebConfigurationManager.ConnectionStrings["ConnectionString177"].ConnectionString;
                return con;
            }
        }
        public static string ConnectionStringttndservices
        {
            get
            {
                string con = WebConfigurationManager.ConnectionStrings["ConnectionStringttndservices"].ConnectionString;
                return con;
            }
        }
        public static string TrimLength(string headline, int length)
        {
            if (headline.Trim().Length > 0)
            {
                if (headline.Trim().Length > length)
                {
                    headline = headline.Trim();
                    headline = headline.Substring(0, length);
                    return headline.Substring(0, headline.LastIndexOf(" ")) + "...";
                }
                return headline;
            }

            return "";
        }

        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
        public static double GetTimeCacheExpire()
        {
            int cacheExpire = ConvertUtility.ToInt32(GetSetting("CacheExpire"));
            if (cacheExpire > 0)
            {
                return cacheExpire;
            }
            return -1;
        }

        static readonly WapTheThaoSoWebReference.GetAvatarThumb Service1 = new WapTheThaoSoWebReference.GetAvatarThumb();
        static readonly TinTucWebReference.GetAvatarThumb TinTucService = new TinTucWebReference.GetAvatarThumb();

        

        public static void SentMt(string userId)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("File");
            try
            {
                var objSentMt = new ServiceProviderService();

                string mtMessage = "Chuc mung ban da tham gia CTKM Trieu phu bong da cua Vietnamobile. ";
                if (DateTime.Now > Convert.ToDateTime(AppEnv.GetSetting("StartKM")) && DateTime.Now < Convert.ToDateTime(AppEnv.GetSetting("EndKM")))
                {
                    mtMessage = mtMessage + "Ban co 5.000 diem voi co hoi trung thuong 1 dien thoai Samsung Galaxy A5. ";
                }
                mtMessage = mtMessage + "Ban duoc mien phi xem, nghe, tai toan bo noi dung dich vu. " +
                                "Truy cap bang 3g vao dia chi http://visport.vn de su dung (5000d/ngay). " +
                                "De biet chi tiet CTKM, soan HD gui 979, huy dvu soan: HUY TP gui 979, xem diem va so diem cao nhat hien tai soan TOP gui 979 HT: 19001255";
                

                int result = objSentMt.sendMT(userId, mtMessage, "979", "TP", "0", "0", "1", "1", "0", "0");

                log.Debug(" ");
                log.Debug(" ");

                log.Debug("requestId : " + "0");
                log.Debug("Send MT result : " + result);
                log.Debug("userId : " + userId);
                log.Debug("Noi dung MT : " + mtMessage);
                log.Debug("ServiceId : " + "979");
                log.Debug("commandCode : " + "TP");
                log.Debug("requestId : " + "0");

                log.Debug(" ");
                log.Debug(" ");

                if (result == 1)
                {
                    var objMt = new ViSport_S2_SMS_MTInfo();
                    objMt.User_ID = userId;
                    objMt.Message = mtMessage;
                    objMt.Service_ID = "979";
                    objMt.Command_Code = "TP";
                    objMt.Message_Type = 1;
                    objMt.Request_ID = "0";
                    objMt.Total_Message = 1;
                    objMt.Message_Index = 0;
                    objMt.IsMore = 0;
                    objMt.Content_Type = 0;
                    objMt.ServiceType = 0;
                    objMt.ResponseTime = DateTime.Now;
                    objMt.isLock = false;
                    objMt.PartnerID = "ViSport";
                    objMt.Operator = "vnmobile";
                    objMt.IsQuestion = 0;

                    InsertSportGameHeroMt(objMt);
                }            
            }
            catch (Exception ex)
            {
                log.Debug("-----");
                log.Debug("Error : " + ex.Message);
                log.Debug("-----");
            }
            
        }

        public static void SentMtPro(string userId, string mtMessage)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("File");
            try
            {
                var objSentMt = new ServiceProviderService();

                int result = objSentMt.sendMT(userId, mtMessage, "979", "TP", "0", "0", "1", "1", "0", "0");

                log.Debug(" ");
                log.Debug(" ");

                log.Debug("requestId : " + "0");
                log.Debug("Send MT result : " + result);
                log.Debug("userId : " + userId);
                log.Debug("Noi dung MT : " + mtMessage);
                log.Debug("ServiceId : " + "979");
                log.Debug("commandCode : " + "TP");
                log.Debug("requestId : " + "0");

                log.Debug(" ");
                log.Debug(" ");

                if (result == 1)
                {
                    var objMt = new ViSport_S2_SMS_MTInfo();
                    objMt.User_ID = userId;
                    objMt.Message = mtMessage;
                    objMt.Service_ID = "979";
                    objMt.Command_Code = "TP";
                    objMt.Message_Type = 1;
                    objMt.Request_ID = "0";
                    objMt.Total_Message = 1;
                    objMt.Message_Index = 0;
                    objMt.IsMore = 0;
                    objMt.Content_Type = 0;
                    objMt.ServiceType = 0;
                    objMt.ResponseTime = DateTime.Now;
                    objMt.isLock = false;
                    objMt.PartnerID = "ViSport";
                    objMt.Operator = "vnmobile";
                    objMt.IsQuestion = 0;

                    InsertSportGameHeroMt(objMt);
                }
            }
            catch (Exception ex)
            {
                log.Debug("-----");
                log.Debug("Error : " + ex.Message);
                log.Debug("-----");
            }

        }

        public static void SentMtVtvDigital(string userId)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("File");
            try
            {
                var objSentMt = new ServiceProviderService();

                //GOI API lay PASS ben DOITAC
                var post = new PostSubmitter();
                post.Url = "http://worldcup.visport.vn/TelcoApi/service.php?action=VMGsms&command=VMG&message=" + "dang-ky-vtv6-wc" + "&msisdn=" + userId + "&short_code=dau-SMS-VMG";
                post.Type = PostSubmitter.PostTypeEnum.Get;
                string resultVtv = post.Post();

                int result = objSentMt.sendMT(userId, resultVtv, "979", "VTV", "0", "0", "1", "1", "0", "0");

                log.Debug(" ");
                log.Debug(" ");
                log.Debug("-------------- VTV WORLD CUP --------");
                log.Debug("requestId : " + "0");
                log.Debug("Send MT result : " + result);
                log.Debug("userId : " + userId);
                log.Debug("Noi dung MT : " + resultVtv);
                log.Debug("ServiceId : " + "979");
                log.Debug("commandCode : " + "VTV");
                log.Debug("requestId : " + "0");

                log.Debug(" ");
                log.Debug(" ");
            }
            catch (Exception ex)
            {
                log.Debug("-----");
                log.Debug("Error : " + ex.Message);
                log.Debug("-----");
            }

        }

        public static int InsertSportGameHeroMt(ViSport_S2_SMS_MTInfo entity)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Sport_Game_Hero_SMS_MT_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", entity.User_ID);
            dbCmd.Parameters.Add("@Message", entity.Message);
            dbCmd.Parameters.Add("@Service_ID", entity.Service_ID);
            dbCmd.Parameters.Add("@Command_Code", entity.Command_Code);
            dbCmd.Parameters.Add("@Message_Type", entity.Message_Type);
            dbCmd.Parameters.Add("@Request_ID", entity.Request_ID);
            dbCmd.Parameters.Add("@Total_Message", entity.Total_Message);
            dbCmd.Parameters.Add("@Message_Index", entity.Message_Index);
            dbCmd.Parameters.Add("@IsMore", entity.IsMore);
            dbCmd.Parameters.Add("@Content_Type", entity.Content_Type);
            dbCmd.Parameters.Add("@ServiceType", entity.ServiceType);
            dbCmd.Parameters.Add("@ResponseTime", entity.ResponseTime);
            dbCmd.Parameters.Add("@isLock", entity.isLock);
            dbCmd.Parameters.Add("@PartnerID", entity.PartnerID);
            dbCmd.Parameters.Add("@Operator", entity.Operator);
            dbCmd.Parameters.Add("@IsQuestion", entity.IsQuestion);


            dbCmd.Parameters.Add("@RETURN_ID", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_ID"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }


        public static string GetAvatar(object avatar, int width, int height)
        {
            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

            string ext = avatar.ToString().Substring(avatar.ToString().LastIndexOf('.') + 1);
            if (ext == "gif")
            {
                return GetAvatarGif(avatar.ToString(), width, height);
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("urldata") +
                           TinTucService.GetAvatar(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
            catch
            {
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
        }

        public static string GetAvatarVideo(object avatar, int width, int height)
        {

            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

            string ext = avatar.ToString().Substring(avatar.ToString().LastIndexOf('.') + 1);
            if (ext == "gif")
            {
                return GetAvatarGif(avatar.ToString(), width, height);
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("urldata1") +
                           Service1.GetAvatar(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata1") + "/layout/images/avartar-default.jpg";
            }
            catch
            {
                return GetSetting("urldata1") + "/layout/images/avartar-default.jpg";
            }
        }



        private static string GetAvatarGif(object avatar, int width, int height)
        {
            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("urldata") + Service1.GetAvatarGif(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
            catch (Exception ex)
            {
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
        }

        public static string GetAvatarWaterMark(object avatar, int Width)
        {
            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("UrlData") +
                           TinTucService.GetAvatarWithTextWaterMarkWithResize(avatar.ToString().Replace("~/", "/"), "", "arial", 11, true, 2, 1, Width);
                }
                return GetSetting("UrlData") +
                          TinTucService.GetAvatar("/layout/images/avartar-default.jpg", 100, 100);

        }

        public static List<string> GetSrc(string htmlText)
        {
            List<string> imgScrs = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
            var nodes = doc.DocumentNode.SelectNodes(@"//img[@src]");
            if (nodes != null)
            {
                foreach (var img in nodes)
                {
                    HtmlAttribute att = img.Attributes["src"];
                    imgScrs.Add(att.Value);
                }
            }

            return imgScrs;
        }

        #region Get Avatar for CP Device

        public static string GetNewsAvatarMobileTop(object avatar, int resolutionWidth)
        {
            string ext = avatar.ToString().Substring(avatar.ToString().LastIndexOf('.') + 1);

            int width;
            int height;

            if (resolutionWidth >= 320)
            {
                width = 200;
                height = 156;
            }
            else
            {
                width = 80;
                height = 75;
            }

            if (ext == "gif")
            {
                return GetAvatarGif(avatar.ToString(), width, height);
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("urldata") +
                           TinTucService.GetAvatar(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
            catch
            {
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
        }

        public static string GetNewsAvatarMobileBottom(object avatar,int resolutionWidth)
        {
            string ext = avatar.ToString().Substring(avatar.ToString().LastIndexOf('.') + 1);

            int width;
            int height;

            if(resolutionWidth >= 320)
            {
                width = 141;
                height = 110;
            }
            else
            {
                width = 60;
                height = 60;
            }

            if (ext == "gif")
            {
                return GetAvatarGif(avatar.ToString(), width, height);
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return GetSetting("urldata") +
                           TinTucService.GetAvatar(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
            catch
            {
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
        }

        #endregion
    }

    public class ViSport_S2_SMS_MTInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _user_ID;
        public string User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _service_ID;
        public string Service_ID
        {
            get { return _service_ID; }
            set { _service_ID = value; }
        }

        private string _command_Code;
        public string Command_Code
        {
            get { return _command_Code; }
            set { _command_Code = value; }
        }

        private int _message_Type;
        public int Message_Type
        {
            get { return _message_Type; }
            set { _message_Type = value; }
        }

        private string _request_ID;
        public string Request_ID
        {
            get { return _request_ID; }
            set { _request_ID = value; }
        }

        private int _total_Message;
        public int Total_Message
        {
            get { return _total_Message; }
            set { _total_Message = value; }
        }

        private int _message_Index;
        public int Message_Index
        {
            get { return _message_Index; }
            set { _message_Index = value; }
        }

        private int _isMore;
        public int IsMore
        {
            get { return _isMore; }
            set { _isMore = value; }
        }

        private int _content_Type;
        public int Content_Type
        {
            get { return _content_Type; }
            set { _content_Type = value; }
        }

        private int _serviceType;
        public int ServiceType
        {
            get { return _serviceType; }
            set { _serviceType = value; }
        }

        private DateTime _responseTime;
        public DateTime ResponseTime
        {
            get { return _responseTime; }
            set { _responseTime = value; }
        }

        private bool _isLock;
        public bool isLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }

        private string _partnerID;
        public string PartnerID
        {
            get { return _partnerID; }
            set { _partnerID = value; }
        }

        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public int IsQuestion { get; set; }

    }

    public class RandomActiveCode
    {
        // Define default min and max password lengths.
        private static int DEFAULT_MIN_PASSWORD_LENGTH = 10;
        private static int DEFAULT_MAX_PASSWORD_LENGTH = 12;

        // Define supported password characters divided into groups.
        // You can add (or remove) characters to (from) these groups.
        //private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz,ABCDEFGHJKLMNPQRSTWXYZ";
        private static string PASSWORD_CHARS_LCASE = "";
        private static string PASSWORD_CHARS_UCASE = "";
        private static string PASSWORD_CHARS_NUMERIC = "0123456789";
        //private static string PASSWORD_CHARS_SPECIAL= "*$-+?_&=!%{}/";
        //private static string PASSWORD_CHARS_SPECIAL= "";

        public static string RandomStringNumber(int length)
        {
            string str = "0123456789";
            int strlen = str.Length;
            var rnd = new Random();
            string retVal = String.Empty;

            for (int i = 0; i < length; i++)
                retVal += str[rnd.Next(strlen)];

            return retVal;
        }

        public static string Generate()
        {
            return Generate(DEFAULT_MIN_PASSWORD_LENGTH,
                DEFAULT_MAX_PASSWORD_LENGTH);
        }


        public static string Generate(int length)
        {
            return Generate(length, length);
        }

        /// <summary>
        /// Generates the specified min length.
        /// </summary>
        /// <param name="minLength">Length of the min.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <returns></returns>
        public static string Generate(int minLength, int maxLength)
        {
            // Make sure that input parameters are valid.
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                return null;

            // Create a local array containing supported password characters
            // grouped by types. You can remove character groups from this
            // array, but doing so will weaken the password strength.
            char[][] charGroups = new char[][]
				{
					//PASSWORD_CHARS_LCASE.ToCharArray(),
					//PASSWORD_CHARS_UCASE.ToCharArray(),
					PASSWORD_CHARS_NUMERIC.ToCharArray(),
				//PASSWORD_CHARS_SPECIAL.ToCharArray()
			};

            // Use this array to track the number of unused characters in each
            // character group.
            int[] charsLeftInGroup = new int[charGroups.Length];

            // Initially, all characters in each group are not used.
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            // Use this array to track (iterate through) unused character groups.
            int[] leftGroupsOrder = new int[charGroups.Length];

            // Initially, all character groups are not used.
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            // Because we cannot use the default randomizer, which is based on the
            // current time (it will produce the same "random" number within a
            // second), we will use a random number generator to seed the
            // randomizer.

            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            // Convert 4 bytes into a 32-bit integer value.
            int seed = (randomBytes[0] & 0x7f) << 24 |
                randomBytes[1] << 16 |
                randomBytes[2] << 8 |
                randomBytes[3];

            // Now, this is real randomization.
            Random random = new Random(seed);

            // This array will hold password characters.
            char[] password = null;

            // Allocate appropriate memory for the password.
            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];

            // Index of the next character to be added to password.
            int nextCharIdx;

            // Index of the next character group to be processed.
            int nextGroupIdx;

            // Index which will be used to track not processed character groups.
            int nextLeftGroupsOrderIdx;

            // Index of the last non-processed character in a group.
            int lastCharIdx;

            // Index of the last non-processed group.
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            // Generate password characters one at a time.
            for (int i = 0; i < password.Length; i++)
            {
                // If only one character group remained unprocessed, process it;
                // otherwise, pick a random character group from the unprocessed
                // group list. To allow a special character to appear in the
                // first position, increment the second parameter of the Next
                // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                        lastLeftGroupsOrderIdx);

                // Get the actual index of the character group, from which we will
                // pick the next character.
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                // Get the index of the last unprocessed characters in this group.
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                // If only one unprocessed character is left, pick it; otherwise,
                // get a random character from the unused character list.
                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                // Add this character to the password.
                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                // If we processed the last character in this group, start over.
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                        charGroups[nextGroupIdx].Length;
                // There are more unprocessed characters left.
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                            charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[nextGroupIdx]--;
                }

                // If we processed the last group, start all over.
                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                // There are more unprocessed groups left.
                else
                {
                    // Swap processed group with the last unprocessed group
                    // so that we don't pick it until we process all groups.
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                            leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    // Decrement the number of unprocessed groups.
                    lastLeftGroupsOrderIdx--;
                }
            }

            // Convert password characters into a string and return the result.
            return new string(password);
        }
    }

}
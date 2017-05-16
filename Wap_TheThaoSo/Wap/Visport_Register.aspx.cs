using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.SQLHelper;
using Wap_TheThaoSo.Library.UrlProcess;

namespace Wap_TheThaoSo.Wap
{
    public partial class Visport_Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["msisdn"] = "841882406279";
            if (Session["msisdn"] != null)
            {
                if (Session["msisdn"].ToString() != "Khách")
                {
                    string msisdn = Session["msisdn"].ToString();
                    //Transaction.DangKyViSportKM(Session["msisdn"].ToString());
                    #region Insert MO Anh Tai Bong Da
                    var moInfo = new MTInfo();
                    var random = new Random();
                    moInfo.User_ID = msisdn;
                    moInfo.Service_ID = "979";
                    moInfo.Command_Code = "DK KM";
                    moInfo.Message = "DK KM";
                    moInfo.Request_ID = "0";
                    moInfo.Operator = "vnmobile";
                    InsertSportGameHeroMo(moInfo);
                    #endregion
                    #region DK USER ANH TAI BONG DA

                    var entity = new ViSport_S2_Registered_UsersInfo();
                    entity.User_ID = msisdn;
                    entity.Request_ID = "0";
                    entity.Service_ID = "979";
                    entity.Command_Code = "DK KM";
                    entity.Service_Type = 1;
                    entity.Charging_Count = 0;
                    entity.FailedChargingTimes = 0;
                    entity.RegisteredTime = DateTime.Now;
                    entity.ExpiredTime = DateTime.Now.AddDays(1);
                    entity.Registration_Channel = "WAP";
                    entity.Status = 1;
                    entity.Operator = "vnmobile";
                    entity.Point = 2;

                    DataTable dt = InsertSportGameHeroRegisterUser(entity);

                    //if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                    //{
                    //    string code1 = RandomActiveCode.Generate(8);
                    //    string code2 = RandomActiveCode.Generate(8);
                    //    SportGameHeroLotteryCodeInsert(msisdn, code1);
                    //    SportGameHeroLotteryCodeInsert(msisdn, code2);

                    //    mtContent = "Chuc mung ban da tham gia CTKM Chuyen gia bong da cua Vietnamobile de co co hoi trung thuong 1 dien thoai Samsung Galaxy S4. Moi ngay ban se duoc tra loi cau hoi de  nang cao co hoi trung thuong (5000d/ngay). Truy cap: http://visport.vn de su dung dvu. De huy dvu soan: HUY TP gui 979. HT: 19001255";
                    //    SendMt(msisdn, "979", "TP", mtContent);
                    //}

                    #endregion
                    #region Send MT trả chậm
                    if (dt.Rows[0]["RETURN_ID"].ToString() == "0")
                    {
                        #region Log MT DVKH
                        var objMt = new ViSport_S2_SMS_MTInfo();
                        objMt.User_ID = msisdn;
                        objMt.Message = " Ban da dang ky thanh cong CT iPhone 6s trao tay TRI AN khach hang Vietnamobile cua dv Visport . KH co so diem cao nhat se so huu iPhone 6s vao cuoi CT. Duy tri dich vu de nhan diem hang ngay. Truy cap bang 3g vao trang http://visport.vn  de su dung dvu (5000d/ngay). De biet ro hon ve chuong trinh soan HD gui 2288. De huy dich vu soan HUY KM gui 979";
                        objMt.Service_ID = "979";
                        objMt.Command_Code = "DK KM";
                        objMt.Message_Type = 1;
                        objMt.Request_ID = "0";
                        objMt.Total_Message = 1;
                        objMt.Message_Index = 0;
                        objMt.IsMore = 0;
                        objMt.Content_Type = 0;
                        objMt.ServiceType = 0;
                        objMt.ResponseTime = DateTime.Now.AddMinutes(30);
                        objMt.isLock = false;
                        objMt.PartnerID = "VNM";
                        objMt.Operator = "vnmobile";
                        objMt.IsQuestion = 0;

                        InsertSportGameHeroMt(objMt);
                        #endregion

                        #region Insert to MTSending 949
                        Vmg_MT_Info mtInfo = new Vmg_MT_Info();
                        mtInfo.User_ID = msisdn;
                        mtInfo.Message = " Ban da dang ky thanh cong CT iPhone 6s trao tay TRI AN khach hang Vietnamobile cua dv Visport . KH co so diem cao nhat se so huu iPhone 6s vao cuoi CT. Duy tri dich vu de nhan diem hang ngay. Truy cap bang 3g vao trang http://visport.vn  de su dung dvu (5000d/ngay). De biet ro hon ve chuong trinh soan HD gui 2288. De huy dich vu soan HUY KM gui 979";
                        mtInfo.Short_Code = "979";
                        mtInfo.Command_Code = "DK KM";
                        mtInfo.Message_Type = 1;
                        mtInfo.Request_ID = "0";
                        mtInfo.Total_Message = 0;
                        mtInfo.Message_Index = 0;
                        mtInfo.IsMore = 0;
                        mtInfo.Content_Type = 0;
                        mtInfo.MT_Price = 0;
                        mtInfo.Service_Type = 0;
                        mtInfo.Service_ID = 0;
                        mtInfo.Partner_ID = "VNM";
                        mtInfo.Operator = "vnmobile";
                        mtInfo.Response_Time = DateTime.Now.AddMinutes(30);
                        int result = InsertWithResponseTime(mtInfo);
                        #endregion

                    }

                    #endregion
                }
            }
            
            Response.Redirect("/Wap/Default.aspx");
        }
        #region class MTInfo
         public class MTInfo
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

    }
        #endregion

        #region InsertSportGameHeroMo
         public static void InsertSportGameHeroMo(MTInfo entity)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Sport_Game_Hero_SMS_MO_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", entity.User_ID);
            dbCmd.Parameters.Add("@Request_ID", entity.Request_ID);
            dbCmd.Parameters.Add("@Service_ID", entity.Service_ID);
            dbCmd.Parameters.Add("@Command_Code", entity.Command_Code);
            dbCmd.Parameters.Add("@Message", entity.Message);
            dbCmd.Parameters.Add("@Operator", entity.Operator);

            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                dbConn.Close();
            }
        }
        #endregion

        #region ViSport_S2_Registered_UsersInfo
        public class ViSport_S2_Registered_UsersInfo
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

        private string _request_ID;
        public string Request_ID
        {
            get { return _request_ID; }
            set { _request_ID = value; }
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

        private int _service_Type;
        public int Service_Type
        {
            get { return _service_Type; }
            set { _service_Type = value; }
        }

        private int _charging_Count;
        public int Charging_Count
        {
            get { return _charging_Count; }
            set { _charging_Count = value; }
        }

        private int _failedChargingTimes;
        public int FailedChargingTimes
        {
            get { return _failedChargingTimes; }
            set { _failedChargingTimes = value; }
        }

        private DateTime _registeredTime;
        public DateTime RegisteredTime
        {
            get { return _registeredTime; }
            set { _registeredTime = value; }
        }

        private DateTime _expiredTime;
        public DateTime ExpiredTime
        {
            get { return _expiredTime; }
            set { _expiredTime = value; }
        }

        private string _registration_Channel;
        public string Registration_Channel
        {
            get { return _registration_Channel; }
            set { _registration_Channel = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public int IsLock { get; set; }

        public int Point { get; set; }


    }
        #endregion

        #region InsertSportGameHeroRegisterUser
         public static DataTable InsertSportGameHeroRegisterUser(ViSport_S2_Registered_UsersInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Sport_Game_Hero_Registered_Users_Insert"

                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTimes
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Point

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        #endregion

        #region Vmg_MT_Info
         public class Vmg_MT_Info
    {
        private int _iD;
        private string _user_ID;
        private string _message;
        private string _short_Code;
        private string _command_Code;
        private int _message_Type;
        private string _request_ID;
        private int _total_Message;
        private int _message_Index;
        private int _isMore;
        private int _content_Type;
        private int _mt_Price;
        private int _service_Type;
        private int _service_ID;
        private string _partner_ID;
        private string _operator;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public string User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string Short_Code
        {
            get { return _short_Code; }
            set { _short_Code = value; }
        }

        public string Command_Code
        {
            get { return _command_Code; }
            set { _command_Code = value; }
        }

        public int Message_Type
        {
            get { return _message_Type; }
            set { _message_Type = value; }
        }

        public string Request_ID
        {
            get { return _request_ID; }
            set { _request_ID = value; }
        }

        public int Total_Message
        {
            get { return _total_Message; }
            set { _total_Message = value; }
        }

        public int Message_Index
        {
            get { return _message_Index; }
            set { _message_Index = value; }
        }

        public int IsMore
        {
            get { return _isMore; }
            set { _isMore = value; }
        }

        public int Content_Type
        {
            get { return _content_Type; }
            set { _content_Type = value; }
        }

        public int MT_Price
        {
            get { return _mt_Price; }
            set { _mt_Price = value; }
        }

        public int Service_Type
        {
            get { return _service_Type; }
            set { _service_Type = value; }
        }

        public int Service_ID
        {
            get { return _service_ID; }
            set { _service_ID = value; }
        }

        public string Partner_ID
        {
            get { return _partner_ID; }
            set { _partner_ID = value; }
        }

        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }
        private DateTime _Response_Time;

        public DateTime Response_Time
        {
            get { return _Response_Time; }
            set { _Response_Time = value; }
        }
    }
        #endregion

        #region InsertSportGameHeroMt
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
        #endregion

        #region InsertWithResponseTime
         public static int InsertWithResponseTime(Vmg_MT_Info mt_info)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStringttndservices"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VMG_MT_Sending_InsertSchedule", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", mt_info.User_ID);
            dbCmd.Parameters.Add("@Message", mt_info.Message);
            dbCmd.Parameters.Add("@Short_Code", mt_info.Short_Code);
            dbCmd.Parameters.Add("@Command_Code", mt_info.Command_Code);
            dbCmd.Parameters.Add("@Message_Type", mt_info.Message_Type);
            dbCmd.Parameters.Add("@Request_ID", mt_info.Request_ID);
            dbCmd.Parameters.Add("@Total_Message", mt_info.Total_Message);
            dbCmd.Parameters.Add("@Message_Index", mt_info.Message_Index);
            dbCmd.Parameters.Add("@IsMore", mt_info.IsMore);
            dbCmd.Parameters.Add("@Content_Type", mt_info.Content_Type);
            dbCmd.Parameters.Add("@MT_Price", mt_info.MT_Price);
            dbCmd.Parameters.Add("@Service_Type", mt_info.Service_Type);
            dbCmd.Parameters.Add("@Service_ID", mt_info.Service_ID);
            dbCmd.Parameters.Add("@Partner_ID", mt_info.Partner_ID);
            dbCmd.Parameters.Add("@Operator", mt_info.Operator);
            dbCmd.Parameters.Add("@Response_Time", mt_info.Response_Time);
            dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }
        #endregion
    }
}
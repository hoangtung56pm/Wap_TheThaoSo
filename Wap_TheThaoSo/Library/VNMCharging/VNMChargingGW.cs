using System;
using log4net;
using Wap_TheThaoSo.VnmCharging;

namespace Wap_TheThaoSo.Library.VNMCharging
{
    public class VNMChargingGW
    {
        ILog log = LogManager.GetLogger("File");      
        private const int REQUEST_TIMEOUT = 50;
        private const string BALANCE_NAME = "core";

        //public string PaymentVnm(string msisdn, string serviceId, string serviceState, string cnttype, string path)
        public string PaymentVnm(string msisdn, string serviceId,string path)   
        {
            //Sửa bỏi Bình Trần 25/11/2016
            //var info = new ChargingTransactionInfo();
            //info.ServiceId = serviceId;
            //info.UserId = msisdn;

            //info.UserName = AppEnv.GetSetting("user_3g");
            //info.UserPass = AppEnv.GetSetting("pass_3g");
            //info.CpId = AppEnv.GetSetting("userid_3g");
            ////info.ServiceState = serviceState;

            //try
            //{
            //    log.Info(" ");
            //    log.Info(" ");
            //    log.Info("------ 3G Charging ---------");
            //    log.Info(string.Format("3G Begin Charging Request: userID:{0}; serviceID:{1}", msisdn, serviceId));
            //    if (ExDebit(info, path))
            //    {
            //        return "1";
            //    }
            //}
            //catch (Exception ex) 
            //{
            //    log.Info(" == 3G Error: " + ex.Message);
            //    log.Info(" == 3G Error: " + ex.StackTrace);
            //    log.Info(" ");
            //    log.Info(" ");
            //}
            //return "-1";
            return "1";   
        }

        public bool ExDebit(ChargingTransactionInfo info, string content)
        {

            //if (AppEnv.GetSetting("TestFlag") == "1")
            //    return true;



            //Sửa bỏi Bình Trần 25/11/2016 
            //bool success = false;
            //try
            //{
            //    var wsCgw = new WebServiceCharging3g();
            //    log.Info("3G Call Deduct method: " + info.UserId + " | " + info.ServiceId + " | " + info.UserName + " | " + info.UserPass + " | " + info.CpId + " | " + content);
            //    string resp = wsCgw.PaymentVnmWithAccount(info.UserId, info.ServiceId, content, "viSport",info.UserName,info.UserPass,info.CpId);

            //    log.Info("3G Ket qua tra ve: " + resp);

            //    if (resp == "1")
            //    {
            //        success = true;
            //    }
            //    return success;
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //    log.Info("3G Error: " + ex.Message);
            //    log.Info(" ");
            //    log.Info(" ");
            //    return false;
            //}


            return true;
        }


        public string StrPaymentVnm(string msisdn, string serviceId, string path)
        {
            return "1"; 
            //Sửa bỏi Bình Trần 25/11/2016
            //var info = new ChargingTransactionInfo();
            //info.ServiceId = serviceId;
            //info.UserId = msisdn;

            //info.UserName = AppEnv.GetSetting("user_3g");
            //info.UserPass = AppEnv.GetSetting("pass_3g");
            //info.CpId = AppEnv.GetSetting("userid_3g");
            ////info.ServiceState = serviceState;

            //try
            //{
            //    log.Info(" ");
            //    log.Info(" ");
            //    log.Info("------ 3G Charging ---------");
            //    log.Info(string.Format("3G Begin Charging Request: userID:{0}; serviceID:{1}", msisdn, serviceId));
            //    return StrExDebit(info, path);
            //}
            //catch (Exception ex)
            //{
            //    log.Info(" == 3G Error: " + ex.Message);
            //    log.Info(" == 3G Error: " + ex.StackTrace);
            //    log.Info(" ");
            //    log.Info(" ");
            //    return "-1";
            //}
        }

        public string StrExDebit(ChargingTransactionInfo info, string content)
        {
            return "1";   
            //Sửa bỏi Bình Trần 25/11/2016
            //try
            //{
            //    var wsCgw = new WebServiceCharging3g();
            //    log.Info("3G Call Deduct method: " + info.UserId + " | " + info.ServiceId + " | " + info.UserName + " | " + info.UserPass + " | " + info.CpId + " | " + content);
            //    string resp = wsCgw.PaymentVnmWithAccount(info.UserId, info.ServiceId, content, "viSport", info.UserName, info.UserPass, info.CpId);

            //    return resp;
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //    log.Info("3G Error: " + ex.Message);
            //    log.Info(" ");
            //    log.Info(" ");
            //    return "-1";
            //}
        }
    }
}
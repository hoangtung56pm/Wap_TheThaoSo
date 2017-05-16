using System;
using System.Web;
using Wap_TheThaoSo.Library.Component.Transaction;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.WSVisport;
namespace Wap_TheThaoSo.Library
{
    public class Transaction
    {
        public static void Success(string telCo, string msisdn, string price, string link, string content_id, string detail, int type)
        {
            //luu giao dich
            var trans = new TransactionInfo();
            trans.Wap_Transaction_Link = link;
            trans.Wap_Transaction_Mobile = msisdn;
            trans.Wap_Transaction_Operator = telCo;
            trans.Wap_Transaction_Portal = telCo;
            trans.Wap_TransactionDetail = detail;
            trans.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            trans.Wap_TransactionName = content_id;
            trans.Wap_TransactionOn = DateTime.Now;
            trans.Wap_TransactionType = type;
            trans.Is3g = ConvertUtility.ToInt32(HttpContext.Current.Session["is3g"]);

            if (AppEnv.GetSetting("TestFlag") == "0")
            {
                TransactionController.Insert_Transaction(trans);
            }
            //end luu giao dich 
        }

        public static void ViClipSubscriptionInsert(string msisdn, int updateType, string updateDesc, DateTime regisTime, DateTime expiryTime, string serviceID)
        {
            ViSport_SubscriptionInfo log = new ViSport_SubscriptionInfo();
            log.MSISDN = msisdn;
            log.UpdateType = updateType;
            log.UpdateDesc = updateDesc;
            log.RegisTime = regisTime;
            log.ExpiryTime = expiryTime;
            log.ServiceID = serviceID;
            TransactionController.Insert_Sub(log);
        }
        public static void DangKyViSport(string msisdn)
        {           
            try
            {
                WSVisport.WebService ws = new WebService();
                ws.WSProcessMoViSportWap(msisdn,"979","DK","DK TP","0");
            }
            catch (Exception ex)
            {
                
            }            
        }
        public static void DangKyViSportKM(string msisdn)
        {
            try
            {
                WSVisport.WebService ws = new WebService();
                ws.WSProcessMoViSportWap(msisdn, "979", "DK", "DK KM", "0");
            }
            catch (Exception ex)
            {

            }
        }
        public static void DangKyViSport_TP1(string msisdn)
        {
            try
            {
                WSVisport.WebService ws = new WebService();
                ws.WSProcessMoViSportWap_New(msisdn, "979", "TP1", "TP1", "0");
            }
            catch (Exception ex)
            {

            }
        }

        public static void DangKyEuro(string msisdn)
        {
            try
            {
                WS_Euro2016.Euro euro = new WS_Euro2016.Euro();
                euro.WSProcessMoEuro_Wap(msisdn, "979", "EU", "EU", "0");
            }
            catch (Exception ex)
            {

            }
        }
        public static void Failure(string telCo, string msisdn, string price, string link, string contentId, string detail, int type, string errorDetail)
        {
            var log = new TransactionLogInfo();
            //Luu vao bang transaction log truong hop giao dich that bai
            log.Wap_Transaction_Link = link;
            log.Wap_Transaction_Mobile = msisdn;
            log.Wap_Transaction_Operator = telCo;
            log.Wap_Transaction_Portal = telCo;
            log.Wap_TransactionDetail = detail;
            log.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            log.Wap_TransactionName = contentId;
            log.Wap_TransactionOn = DateTime.Now;
            log.Wap_TransactionType = type;
            log.ErrorCode = 1;//That bai
            log.ErrorDetail = errorDetail;
            log.Is3g = ConvertUtility.ToInt32(HttpContext.Current.Session["is3g"]);
            if (AppEnv.GetSetting("TestFlag") == "0")
            {
                TransactionController.Insert_TransactionLog(log);
            }
        }

    }
}
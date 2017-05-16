using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.SQLHelper;

namespace Wap_TheThaoSo.Library.Component.Transaction
{
    public class TransactionController
    {
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();
        public TransactionController()
        {
        }

        public static int Insert_Sub(ViSport_SubscriptionInfo obj)
        {
            return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "ViSport_S2_Registered_Users_Insert", obj.MSISDN,
                "0",
                 "979",
                "SC",
                "1",
                "0", "0", obj.RegisTime, obj.ExpiryTime, "Wap", "1", "viSport");
        }

        public static DataTable GetRegisterInfo(string msisdn)
        {
            return SqlProvider.GetRegisterInfo(msisdn);
        }

        public static int Insert_Transaction(TransactionInfo obj)
        {
            return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_vSport", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.Is3g);
        }
        public static int Insert_TransactionLog(TransactionLogInfo obj)
        {
            return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log_vSport", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail, obj.Is3g);
        }

        static log4net.ILog log = log4net.LogManager.GetLogger("File");

        public static int Insert_Transaction_Log(Transaction_LogInfo obj)
        {
            string folderName = ConfigurationManager.AppSettings.Get("LogCDR") + DateTime.Now.ToString("yyyyMMdd") + "/";
            string fileName = "ErrorCDR_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string path = folderName + fileName;
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            try
            {
                return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Operator, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail);
            }
            catch
            {
                WriteFileLogCdrToHardDisk(path, obj, fileName);
                return 1;
            }
        }

        private static void WriteFileLogCdrToHardDisk(string path, Transaction_LogInfo obj, string fileName)
        {
            try
            {
                FileStream texlog = null;
                if (!File.Exists(path))
                {
                    texlog = File.Create(path);
                }
                else
                {
                    texlog = new FileStream(path, FileMode.Append);
                }
                AddText(texlog, obj.Wap_TransactionName + "|");
                AddText(texlog, obj.Wap_TransactionType + "|");
                AddText(texlog, obj.Wap_TransactionDetail.Replace("\r\n", "").Replace("\n", "").Replace("\r", "") + "|");
                AddText(texlog, obj.Wap_TransactionOn + "|");
                AddText(texlog, obj.Wap_Transaction_Mobile + "|");
                AddText(texlog, obj.Wap_Transaction_Portal + "|");
                AddText(texlog, obj.Wap_Transaction_Operator + "|");
                AddText(texlog, obj.Wap_Transaction_Link + "|");
                AddText(texlog, obj.Wap_Transaction_Amount + "|");
                AddText(texlog, obj.ErrorCode + "|");
                AddText(texlog, obj.ErrorDetail);
                AddText(texlog, Environment.NewLine);

                texlog.Close();
                texlog.Dispose();
            }
            catch (Exception ex)
            {
                log.Debug("Happen error when write file:" + fileName + Environment.NewLine + ex.Message);
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public static void Delete_Transaction(int transactionid)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Delete", transactionid);
        }

    }
}
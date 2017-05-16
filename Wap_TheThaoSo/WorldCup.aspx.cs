using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Constant;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.Wap;

namespace Wap_TheThaoSo
{
    public partial class WorldCup : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msisdn"] == null)
            {
                AppEnv.GetMsisdnWithParam("3");
            }

            if (Session["msisdn"] != null)
            {
                if (!string.IsNullOrEmpty(Session["msisdn"].ToString()) && Session["msisdn"].ToString() != "Khách")
                {
                    var entity = new GameShow.ViSport_S2_Registered_UsersInfo();
                    entity.User_ID = Session["msisdn"].ToString();
                    entity.Request_ID = "0";
                    entity.Service_ID = "979";
                    entity.Command_Code = "VTV";
                    entity.Service_Type = 1;
                    entity.Charging_Count = 0;
                    entity.FailedChargingTimes = 0;
                    entity.RegisteredTime = DateTime.Now;
                    entity.ExpiredTime = DateTime.Now.AddDays(1);
                    entity.Registration_Channel = "VTV_WAP";
                    entity.Status = 1;
                    entity.Operator = "vnmobile";
                    entity.Point = 0;

                    DataTable value = WorldCupRegisterUserVtv6(entity);
                    if (value.Rows[0]["RETURN_ID"].ToString() == "0")
                    {
                        AppEnv.SentMtVtvDigital(Session["msisdn"].ToString());
                    }

                    Response.Redirect("http://worldcup.visport.vn/");

                }
            }

            Response.Redirect("http://worldcup.visport.vn/");

        }

        public static DataTable WorldCupRegisterUserVtv6(GameShow.ViSport_S2_Registered_UsersInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "World_Cup_Registered_Users_Insert_Vtv"

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

    }
}
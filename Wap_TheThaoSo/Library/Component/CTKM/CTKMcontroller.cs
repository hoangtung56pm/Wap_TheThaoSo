using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Wap_TheThaoSo.Library.SQLHelper;

namespace Wap_TheThaoSo.Library.Component.CTKM
{
    public class CTKMcontroller
    {
        public DataTable GetTopCTKMvisport()
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "Sport_Game_Hero_GetTopCTKMvisport");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetTopCTKMvisportByUser_ID(string user_id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "Sport_Game_Hero_GetTopCTKMvisportByUser_ID", user_id);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
    }
}

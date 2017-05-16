using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Wap_TheThaoSo.Library.SQLHelper;

namespace Wap_TheThaoSo.Library
{
    public class UserAcountController
    {
        public bool Login(string _username, string _commandcode)
        {
            DataTable dtuser = Getuserinfo(_username, _commandcode);

            if (dtuser != null && dtuser.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public DataTable Getuserinfo(string user_id, string commandcode)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "Sport_Game_Hero_GetInfoVisportUser", user_id, commandcode);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
    }
}

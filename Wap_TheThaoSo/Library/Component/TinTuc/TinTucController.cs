using System;
using System.Data;
using System.Web.Configuration;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.SQLHelper;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.TinTuc
{
    public class TinTucController
    {
        private readonly DataCaching _dataCaching = new DataCaching();
        private const string Key = "Wap_TinTuc";
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();

        #region Get Data

        public DataSet GetHomeNews(int anh, int taybannha, int italia, int duc, int namchau, int vietnam, int thethaoquocte)
        {
            string param = Key + "GetHomeNews?anh=" + anh + "&taybannha=" + taybannha + "&italia" + italia + "&duc" + duc+"&namchau=" + namchau + "&vietnam=" + vietnam + "&thethao=" + thethaoquocte;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetHomeNews(anh, taybannha, italia, duc, namchau, vietnam, thethaoquocte);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetNewsByCatId(int catId,int pageNumber,int pageSize)
        {
            string param = Key + "GetNewsByCatId?catId=" + catId + "&pageIndex=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetNewsByCatId(catId, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetNewsDetail(int id,int pageNumber,int pageSize,int view)
        {
            string param = Key + "GetNewsDetail?id=" + id + "&pageIndex=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetNewsDetail(id, pageNumber, pageSize,view);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetHomeMarqueeNews()
        {
            string param = Key + "GetHomeMarqueeNews";
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetHomeMarqueeNews();
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetNewsByKeyword(string key,int pageNumber,int pageSize)
        {
            return SqlProvider.GetNewsByKeyword(key, pageNumber, pageSize);
        }

        public static void WapUserLog(string userId, int? categoryId, string path, int type)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString177"].ConnectionString, "Wap_User_Log_Add", userId, categoryId, path, type);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetLotteryCodeByUserId(string userId)
        {
            DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Sport_Game_Hero_GetCodeByUserId", userId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        #endregion

        #region MyRegion
        


        #endregion

    }
}
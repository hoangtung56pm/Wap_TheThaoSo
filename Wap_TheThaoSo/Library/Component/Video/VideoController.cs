using System.Data;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.Video
{
    public class VideoController
    {
        private readonly DataCaching _dataCaching = new DataCaching();
        private const string Key = "Wap_Video";
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();

        #region Get Data

        public DataSet GetVideoByKeywordW4A(string key, int pageNumber, int pageSize)
        {
            return SqlProvider.GetVideoByKeywordW4A(key, pageNumber, pageSize);
        }

        public DataSet GetVideoByKey(string key,int pageNumber,int pageSize)
        {
            return SqlProvider.GetVideoByKeyword(key, pageNumber, pageSize);
        }

        public DataSet GetLastestVideo(int pageNumber, int pageSize)
        {
            string param = Key + "GetLastestVideo?pageIndex=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetLastestVideo(pageNumber,pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetLastestVideoW4A(string telco, int catId, int exceptId, int displayType, int pageNumber, int pageSize)
        {
            string param = Key + "GetLastestVideoW4A?telco=" + telco + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&catId=" + catId + "&ex=" + exceptId + "&type=" + displayType;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetVideoByCategoryW4A(telco, catId, exceptId, displayType, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetVideoByCategoryId(int catId,int pageNumber, int pageSize)
        {
            string param = Key + "GetVideoByCategoryId?catid=" + catId + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetVideoByCategory(catId,pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetVideoByCategoryW4A(string telco,int catId,int exceptId,int displayType,int pageNumber,int pageSize)
        {
            string param = Key + "GetVideoByCategoryW4A?telco=" + telco + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&catId=" + catId + "&ex=" + exceptId + "&type=" + displayType;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetVideoByCategoryW4A(telco, catId, exceptId, displayType, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet GetVideoDetailW4A(string telco,int id,int pageNumber,int pageSize)
        {
            return SqlProvider.GetVideoDetailW4A(telco, id, pageNumber, pageSize);
        }

        public DataSet GetVideoDetail(int id,int pageNumber,int pageSize)
        {
            string param = Key + "GetVideoDetail?id=" + id + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.GetVideoDetail(id, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache3Minute")));
            return ds;
        }

        #endregion
    }
}
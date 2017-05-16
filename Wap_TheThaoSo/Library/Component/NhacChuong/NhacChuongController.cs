using System.Data;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.NhacChuong
{
    public class NhacChuongController
    {
        private readonly DataCaching _dataCaching = new DataCaching();
        private const string Key = "Wap_NhacChuong";
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();

        public DataSet GetRingToneByAlbumId(int id, string telco, int pageNumber, int pageSize)
        {
            string param = Key + "GetRingToneByAlbumId?telco=" + telco + "&id=" + id + "&pageNumber=" + pageNumber +"&pageSize=" + pageSize;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetRingToneByAlbumId(id, telco, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet GetRingToneByCategory(string telco, int catId, int displayType, int pageNumber, int pageSize,string orderBy)
        {
            string param = Key + "GetRingToneByCategory?telco=" + telco + "&catId=" + catId + "&type=" + displayType + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&orderby=" + orderBy;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetRingToneByCategory(telco,catId,displayType, pageNumber, pageSize,orderBy);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet GetRingToneDetail(string telco,int id,int pageNumber,int pageSize)
        {
            //string param = Key + "GetRingToneDetail?telco=" + telco + "&id=" + id + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            //var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            //if (dt != null)
            //{
            //    return dt;
            //}
            //dt = SqlProvider.GetRingToneDetail(telco, id, pageNumber, pageSize);
            //_dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            //return dt;

            return SqlProvider.GetRingToneDetail(telco, id, pageNumber, pageSize);
        }
    }
}
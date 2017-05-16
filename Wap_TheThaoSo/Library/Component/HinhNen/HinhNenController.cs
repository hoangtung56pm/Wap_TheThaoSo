using System.Data;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.HinhNen
{
    public class HinhNenController
    {
        private readonly DataCaching _dataCaching = new DataCaching();
        private const string Key = "Wap_HinhNen";
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();

        public DataSet GetWallPaperByCategoryId(string telco, int catId, int displayType, int pageNumber, int pageSize, string orderBy)
        {
            string param = Key + "GetWallPaperByCategoryId?telco=" + telco + "&id=" + catId + "&display=" + displayType + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&order=" + orderBy;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetWallPaperByCategoryId(telco,catId,displayType, pageNumber, pageSize,orderBy);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet GetWallpaperDetail(string telco,int id,int pageNumber,int pageSize)
        {
            //string param = Key + "GetWallpaperDetail?telco=" + telco + "&id=" + id + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            //var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            //if (dt != null)
            //{
            //    return dt;
            //}
            return SqlProvider.GetWallpaperDetail(telco,id, pageNumber, pageSize);
            //_dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            //return dt;
        }

        public DataSet GetGalleryAlbumDetailNew(int albumId)
        {
            string param = Key + "GetGalleryAlbumDetailNew?albumId=" + albumId;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetGalleryAlbumDetailNew(albumId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataTable GetGalleryAlbumDetail(int albumId)
        {
            string param = Key + "GetGalleryAlbumDetail?albumId=" + albumId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetGalleryAlbumDetail(albumId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet GetGalleryAlbum(int pageNumber, int pageSize)
        {
            string param = Key + "GetGalleryAlbum?pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetGalleryAlbum(pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }
    }
}
using System.Data;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.SQLHelper;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.DuLieu
{
    public class DuLieuController
    {
        private readonly DataCaching _dataCaching = new DataCaching();
        private const string Key = "Wap_DuLieu";
        private static readonly SqlProvider SqlProvider = SqlProvider.GetInstance();

        #region Get Data
        
        public DataSet WapTheThaoSoGet87ServiceLists()
        {
            const string param = Key + "WapTheThaoSoGet87ServiceLists";
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGet87ServiceLists();
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataTable WapTheThaoSoGet87Content(string serviceId)
        {
            string param = Key + "WapTheThaoSoGet87Content?serviceId=" + serviceId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGet87Content(serviceId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache2Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetSchedulesLive(int competitionId,int status,int pageNumber,int pageSize)
        {
            string param = Key + "WapTheThaoSoGetGetSchedulesLive?competition=" + competitionId + "&status=" + status + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetGetSchedulesLive(competitionId,status,pageNumber,pageSize);

           _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));

            return ds;
        }

        public DataSet WapTheThaoSoGetSchedulesLivePlaying(int competitionId, int status, int pageNumber, int pageSize)
        {
            string param = Key + "WapTheThaoSoGetSchedulesLivePlaying?competition=" + competitionId + "&status=" + status + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetGetSchedulesLive(competitionId, status, pageNumber, pageSize);

            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));

            return ds;
        }

        public DataTable WapTheThaoSoGetAllLeagues()
        {
            const string param = Key + "WapTheThaoSoGetAllLeagues";
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetAllLeagues();
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetCompetition(int status)
        {
            string param = Key + "WapTheThaoSoGetCompetition?status=" + status;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetition(status);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetCompetitionPlaying(int status)
        {
            string param = Key + "WapTheThaoSoGetCompetitionPlaying?status=" + status;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetition(status);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetTeamInfo(int id)
        {
            string param = Key + "WapTheThaoSoGetTeamInfo?id=" + id;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetTeamInfo(id);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet WapTheThaoSoGetTeamLastestMatch(int teamId,int pageNumber,int pageSize)
        {
            string param = Key + "WapTheThaoSoGetTeamLastestMatch?id=" + teamId + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetTeamLastestMatch(teamId,pageNumber,pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet WapTheThaoSoGetTeamLastestNews(int teamId, int pageNumber, int pageSize)
        {
            string param = Key + "WapTheThaoSoGetTeamLastestNews?id=" + teamId + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetTeamLastestNews(teamId, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataSet WapTheThaoSoGetTeamInfoLastestVideoId(int teamId, int pageNumber, int pageSize)
        {
            string param = Key + "WapTheThaoSoGetTeamInfoLastestVideoId?id=" + teamId + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetTeamInfoLastestVideoId(teamId, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }

        public DataTable WapTheThaoSoGetTeamInforLastestVideoContent(string ids)
        {
            string param = Key + "WapTheThaoSoGetTeamInforLastestVideoContent?id=" + ids.Replace(",","&");
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.GetTeamInfoLastestVideo(ids);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetMatchInfoPhongDo(int matchId)
        {
            string param = Key + "WapTheThaoSoGetMatchInfoPhongDo?id=" + matchId;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetMatchInfoPhongDo(matchId);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return ds;
        }

        public DataSet WapTheThaoSoGetMatchInfoTuongThuat(int matchId)
        {
            string param = Key + "WapTheThaoSoGetMatchInfoTuongThuat?id=" + matchId;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetMatchInfoTuongThuat(matchId);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return ds;
        }

        public DataSet WapTheThaoSoGetMatchInfoDoiHinh(int matchId)
        {
            string param = Key + "WapTheThaoSoGetMatchInfoDoiHinh?id=" + matchId;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetMatchInfoDoiHinh(matchId);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return ds;
        }

        public DataTable WapTheThaoSoGetPlayerInfo(int teamId,int personId)
        {
            string param = Key + "WapTheThaoSoGetPlayerInfo?teamId=" + teamId + "&personId=" + personId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetPlayerInfo(teamId,personId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        //public DataTable WapTheThaoSoGetSeasonYear(int competitionId)
        //{
        //    string param = Key + "WapTheThaoSoGetSeasonYear?competitionId=" + competitionId;
        //    var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
        //    if (dt != null)
        //    {
        //        return dt;
        //    }
        //    dt = SqlProvider.WapTheThaoSoGetSeasonYear(competitionId);
        //    _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
        //    return dt;
        //}
        public DataTable WapTheThaoSoGetSeasonYear(int competitionId)
        {
            string param = Key + "WapTheThaoSoGetSeasonYear?competitionId=" + competitionId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetSeasonYear(competitionId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }
        public DataSet WapTheThaoSoGetTopGoalByCompetitionAndSeason(int competitionId,int seasonId)
        {
            string param = Key + "WapTheThaoSoGetTopGoalByCompetitionAndSeason?competitionId=" + competitionId + "&seasonId=" + seasonId;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetTopGoalByCompetitionAndSeason(competitionId,seasonId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetBxhByCompetitionAndSeason(int competitionId, int seasonId)
        {
            string param = Key + "WapTheThaoSoGetBxhByCompetitionAndSeason?competitionId=" + competitionId + "&seasonId=" + seasonId;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetBxhByCompetitionAndSeason(competitionId, seasonId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek(int competitionId,int seasonId,string week)
        {
            string param = Key + "WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek?competitionId=" + competitionId + "&seasonId=" + seasonId + "&week=" + week;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek(competitionId, seasonId,week);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetCompetitionWeek(int competitionId,int seasonId)
        {
            string param = Key + "WapTheThaoSoGetCompetitionWeek?competitionId=" + competitionId + "&seasonId=" + seasonId;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetitionWeek(competitionId, seasonId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetCompetitionCalendar(int competitionId, int seasonId)
        {
            string param = Key + "WapTheThaoSoGetCompetitionCalendar?competitionId=" + competitionId + "&seasonId=" + seasonId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetitionCalendar(competitionId, seasonId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetAllCountry()
        {
            const string param = Key + "WapTheThaoSoGetAllCountry";
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetAllCountry();
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetAreaByParentId(int parentId)
        {
            string param = Key + "WapTheThaoSoGetAreaByParentId?id=" + parentId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetAreaByParentId(parentId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetCompetitionByAreaId(int areaId)
        {
            string param = Key + "WapTheThaoSoGetCompetitionByAreaId?id=" + areaId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetitionByAreaId(areaId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }

        public DataSet WapTheThaoSoGetMatchOdd(int matchId)
        {
            string param = Key + "WapTheThaoSoGetMatchOdd?match=" + matchId;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.WapTheThaoSoGetMatchOdd(matchId);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return ds;
        }

        public DataTable WapTheThaoSoGetCompetitionLiveScore()
        {
            const string param = Key + "WapTheThaoSoGetCompetitionLiveScore";
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetCompetitionLiveScore();
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetMatchLiveScore(int competitionId)
        {
            string param = Key + "WapTheThaoSoGetMatchLiveScore?id=" + competitionId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetMatchLiveScore(competitionId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetMatchLiveScoreFocus()
        {
            string param = Key + "WapTheThaoSoGetMatchLiveScoreFocus";
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetMatchLiveScoreFocus();
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetTipList()
        {
            string param = Key + "WapTheThaoSoGetTipList";
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetTipList();
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache2Minute")));
            return dt;
        }

        public DataTable WapTheThaoSoGetTipContent(string id)
        {
            string param = Key + "WapTheThaoSoGetTipContent?id=" + id;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.WapTheThaoSoGetTipContent(id);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache2Minute")));
            return dt;
        }
        public DataSet ApiTtsGetCompetitionCalendar(int competitionId, int seasonId, int gameweek)
        {
            string param = Key + "ApiTtsGetCompetitionCalendar?competitionId=" + competitionId + "&seasonId=" + seasonId + "&round=" + gameweek;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.ApiTtsGetCompetitionCalendar(competitionId, seasonId, gameweek);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }
        public DataTable ApiTtsGetPlayerInfo(int personId)
        {
            string param = Key + "ApiTtsGetPlayerInfo?personId=" + personId;
            var dt = (DataTable)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.ApiTtsGetPlayerInfo(personId);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache10Minute")));
            return dt;
        }
        public DataSet ApiTtsGetTeamInfo(int id)
        {
            string param = Key + "ApiTtsGetTeamInfo?id=" + id;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.ApiTtsGetTeamInfo(id);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }
        public DataSet ApiTtsTeamLastestMatch(int teamId, int pageNumber, int pageSize)
        {
            string param = Key + "ApiTtsTeamLastestMatch?id=" + teamId + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.ApiTtsGetTeamLastestMatch(teamId, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }
        public DataSet ApiTtsGetTeamLastestNews(int teamId, int pageNumber, int pageSize)
        {
            string param = Key + "ApiTtsGetTeamLastestNews?id=" + teamId + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.ApiTtsGetTeamLastestNews(teamId, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }
        public DataSet ApiTtsGetTeamInfoLastestVideoId(string text, int pageNumber, int pageSize)
        {
            string param = Key + "ApiTtsGetTeamInfoLastestVideoId?text=" + text + "&pageNumber=" + pageNumber + "&pageSizee=" + pageSize;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.ApiTtsGetTeamInfoLastestVideoId(text, pageNumber, pageSize);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache5Minute")));
            return ds;
        }
        public DataSet ApiTtsGetMatchInfoTuongThuat(int matchId)
        {
            string param = Key + "ApiTtsGetMatchInfoTuongThuat?id=" + matchId;
            var ds = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = SqlProvider.ApiTtsGetMatchInfoTuongThuat(matchId);
            _dataCaching.SetHashCache(Key, param, ds, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return ds;
        }
        #endregion

        public DataSet GetAll_Sport87_DetailBy_PK_Game87ID(string game87id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "VNM_Wap_GetAll_Sport87_DetailByGame87ID", game87id);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetSchedulesMatch(int status)
        {
            string param = Key + "ApiTtsGetSchedulesMatch?status=" + status;
            var dt = (DataSet)_dataCaching.GetHashCache(Key, param);
            if (dt != null)
            {
                return dt;
            }
            dt = SqlProvider.ApiTtsGetSchedulesMatch(status);
            _dataCaching.SetHashCache(Key, param, dt, ConvertUtility.ToInt32(AppEnv.GetSetting("Cache1Minute")));
            return dt;
        }
    }
}
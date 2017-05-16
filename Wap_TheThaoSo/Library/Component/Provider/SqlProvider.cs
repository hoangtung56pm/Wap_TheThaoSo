using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Library.Component.Provider
{
    public class SqlProvider
    {
        private static readonly SqlProvider Instance = new SqlProvider();

        public static SqlProvider GetInstance()
        {
            return Instance;
        }

        private static readonly string ConnectionString = AppEnv.ConnectionString;
        private static readonly string ConnectionString177 = AppEnv.ConnectionString177;
        private static readonly string ConnectionStringttndservices = AppEnv.ConnectionStringttndservices;
        

        #region TinTuc

        public DataSet GetHomeMarqueeNews()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetHomeMarqueeNews");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetHomeNews(int anh,int taybannha,int italia,int duc,int namchau,int vietnam,int thethaoquocte)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_ViSport_GetHomeNews", anh, taybannha, italia, duc, namchau, vietnam, thethaoquocte);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetNewsByCatId(int catId,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetNewsByCategory", catId,pageNumber,pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetNewsDetail(int id,int pageNumber,int pageSize,int view)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetNewsDetail_New", id, pageNumber, pageSize, view);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetNewsByKeyword(string key,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetNewsByKeyword", key, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        #endregion

        #region Video

        public DataSet GetVideoByKeywordW4A(string key, int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Video_QSearch_W4A", key, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        
        public DataSet GetVideoByKeyword(string key,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Video_QSearch", key, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetLastestVideo(int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetLastestVideo",pageNumber,pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetVideoByCategory(int catId,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetVideoByCategory",catId, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetVideoByCategoryW4A(string telco,int catId,int exceptId,int displayType,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetVideoByCategory_W4A",telco,catId,exceptId,displayType,pageNumber,pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetVideoDetailW4A(string telco,int id,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetVideoDetail_W4A", telco,id, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetVideoDetail(int id,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetVideoDetail", id, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable GetTeamInfoLastestVideo(string videoIds)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetTeamLastestVideo", videoIds);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion

        #region DuLieu
        
        public DataSet WapTheThaoSoGet87ServiceLists()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_VinaBox_Get87ServiceLists");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGet87Content(string serviceId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_VinaBox_Get87Content",serviceId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet WapTheThaoSoGetGetSchedulesLive(int competitionId,int status,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetSchedules_Live", competitionId,status,pageNumber,pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGetAllLeagues()
        {
            //DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_VinaBox_GetAll_League");
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_Competitions");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetCompetition(int status)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetCompetition",status);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet WapTheThaoSoGetTeamInfo(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTeamInfo", id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetTeamLastestMatch(int teamId,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTeamInfo_LastestMatch", teamId,pageNumber,pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetTeamLastestNews(int teamId, int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTeamInfo_LastestNews", teamId, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetTeamInfoLastestVideoId(int teamId,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTeamInfo_LatestVideo", teamId, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetMatchInfoPhongDo(int matchId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetMatchInfo_PhongDo", matchId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetMatchInfoTuongThuat(int matchId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetMatchInfoCommentary", matchId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetMatchInfoDoiHinh(int matchId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTeamPlay", matchId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGetPlayerInfo(int teamId,int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetPlayerInfo", teamId,personId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetSeasonYear(int competitionId)
        {
            //DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetSeasonYearByCompetition", competitionId);
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_get_season_by_competition", competitionId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet WapTheThaoSoGetTopGoalByCompetitionAndSeason(int competitionId,int seasonId)
        {
            //DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTopGoalByCompetitionAndSeason", competitionId, seasonId);
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_getTopGoal", competitionId, seasonId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetBxhByCompetitionAndSeason(int competitionId,int seasonId)
        {
            //DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetBXH_ByCompetitionAndSeason", competitionId, seasonId);
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_getBXH", competitionId, seasonId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet WapTheThaoSoGetLichThiDauByCompetitionIdSeasonIdGameWeek(int competitionId,int seasonId,string week)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetCalendarByCompetitionId_SeasonId_Gameweek", competitionId, seasonId,week);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGetCompetitionCalendar(int competitionId,int seasonId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Competition_Calendar",DateTime.Now.ToShortDateString(), competitionId, seasonId,string.Empty);
            if (ds != null)
            {
                if (ds.Tables.Count > 1)
                    return ds.Tables[1];
            }
            return null;
        }

        public DataSet WapTheThaoSoGetCompetitionWeek(int competitionId, int seasonId)
        {
            //DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetCompetitionWeek_New", competitionId, seasonId);
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_get_roundByseason", competitionId, seasonId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGetAllCountry()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GlobalArea_getAllCountry");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetAreaByParentId(int parentId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GlobalArea_GetByParentID", parentId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetCompetitionByAreaId(int areaId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GlobalCompetion_getByAreaID", areaId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet WapTheThaoSoGetMatchOdd(int matchId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetMatchOdd", matchId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable WapTheThaoSoGetCompetitionLiveScore()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Competition_LiveScore");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetMatchLiveScore(int competitionId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Match_LiveScore", competitionId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetMatchLiveScoreFocus()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Match_LiveScore_GetFocus");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetTipList()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTipList");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable WapTheThaoSoGetTipContent(string id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetTipContent", id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet ApiTtsGetSchedulesMatch(int status)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetScheduleByDayWap", status);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetCompetitionCalendar(int competitionId, int seasonId, int gameweek)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_getmatchbyround", competitionId, seasonId, gameweek);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }

        public DataTable ApiTtsGetPlayerInfo(int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetPlayerProfileWap", personId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataSet ApiTtsGetTeamInfo(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetClubSquadWap", id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetTeamLastestMatch(int teamId, int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetScheduleByClubWap", teamId, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetTeamLastestNews(int teamId, int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetlistnewbytagWap", teamId, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetTeamInfoLastestVideoId(string text, int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "API_TTS_GetVideoByTagsWap", text, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet ApiTtsGetMatchInfoTuongThuat(int matchId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "API_TTS_GetMatchSquadWap", matchId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        #endregion

        #region HinhNen

        public DataSet GetWallPaperByCategoryId(string telco,int catId,int displayType, int pageNumber, int pageSize, string orderBy)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Wallpaper_GetItemByCategoryAndDisplayType",telco, catId,displayType,pageNumber,pageSize,orderBy);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetWallpaperDetail(string telco,int id,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_GetWallpaperDetail", telco,id,pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetGalleryAlbumDetailNew(int albumId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Gallery_Picture_GetAllByAlbumID_New", albumId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataTable GetGalleryAlbumDetail(int albumId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_Gallery_Picture_GetAllByAlbumID", albumId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet GetGalleryAlbum(int pageNumber, int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_TheThaoSo_GetGalleryAlbum", pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        #endregion

        #region NhacChuong

        public DataSet GetRingToneByAlbumId(int id,string telco,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Item_GetByAlbumWithPaging",id,telco, pageNumber, pageSize);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        
        public DataSet GetRingToneByCategory(string telco,int catId,int displayType,int pageNumber,int pageSize,string orderBy)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Ringtone_GetItemByCategoryAndDisplayType", telco,catId,displayType, pageNumber, pageSize,orderBy);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet GetRingToneDetail(string telco,int id,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString177, "Wap_TheThaoSo_Music_Item_GetInfo", telco, id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        #endregion

        public DataTable GetRegisterInfo(string msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Wap_ViSport_GetRegisterInfo", msisdn);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        #region Chuyen Gia Bong Da
        
        public DataTable CgbdGetRegisterUser(string userId,string password)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_Hero_Registered_Users_Login", userId,password);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public DataTable CgbdGetQuestionInfoSportGameHero()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_Hero_Question_GetRandomInfo");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public void CgbdInsertSportGameHeroAnswerLog(string userId, int questionId, string question, string trueAnswer, DateTime sendTime, int status)
        {
            SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "Sport_Game_Hero_Answer_Log_Insert"
                                        , userId
                                        , questionId
                                        , question
                                        , trueAnswer
                                        , sendTime
                                        , status
                                    );
        }

        public DataTable CgbdCountQuestionTodaySportGameHeroRegisterUser(string userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_Hero_CountQuestionToday", userId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable CgbdGetAnswerSportGameHero(string userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_Hero_Answer_Log_GetAnswerByUserId", userId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public void CgbdSportGameHeroLotteryCodeInsert(string userId, string code)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "Sport_Game_Hero_Lottery_Code_Insert"
                                        , userId
                                        , code
                                    );
        }

        public DataTable CgbdUpdatePointSportGameHeroRegisterUserTp(string userId, int questionId, int point, string requestId, string answer, int status)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionString, "Sport_Game_Hero_Registered_Users_Update_Point_Tp"

                , userId
                , questionId
                , point
                , requestId
                , answer
                , status

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #endregion

        #region Cau hoi may man
         public DataTable CauHoiMayMan_CountQuestion_Today(string UserID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_CountQuestion_Today", UserID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
         public DataTable CauHoiMayMan_CountAnswerLog_Today(string UserID)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_CountAnswerLog_Today", UserID);
             if (ds != null && ds.Tables[0].Rows.Count > 0)
             {
                 return ds.Tables[0];
             }
             return new DataTable();
         }
         public int CauHoiMayMan_CheckAnswer_Today(string UserID)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_CountAnswer_Today", UserID);
             if (ds != null && ds.Tables[0].Rows.Count > 0)
             {
                 return ConvertUtility.ToInt32(ds.Tables[0].Rows[0][0]);
             }
             return 0;
         }
         public DataTable CauHoiMayMan_LoadQuetionToAnswer(string UserID, int QuestionID)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_LoadQuetionToAnswer", UserID, QuestionID);
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public DataTable CauHoiMayMan_GetQuestion()
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_Question_GetRandomInfo");
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public DataTable CauHoiMayMan_LoadRandomQuestion()
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_LoadRandomQuestion");
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public DataTable CauHoiMayMan_GetAnswerOfQuestion(string userId,int QuestionID)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_GetAnswerOfQuestion", userId, QuestionID);
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public void CauHoiMayMan_Answer_Log_Insert(string userId, int questionId, string question, string trueAnswer,int status)
         {
             SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "CauHoiMayMan_Answer_Log_Insert"
                                         , userId
                                         , questionId
                                         , question
                                         
                                         , trueAnswer
                                         
                                         , status
                                     );
         }
         public int CauHoiMayMan_GetQuestionToUpdate(string userId)
         {
             
             return (int)SqlHelper.ExecuteScalar(ConnectionString, "CauHoiMayMan_GetQuestionToUpdate",
                                                userId
                                               )
               ;
         }
         public void CauHoiMayMan_UpdateAnswer(string userId,int questionId,string answer)
         {
             SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "CauHoiMayMan_UpdateAnswer"
                                         ,userId, questionId, answer

                                     );
         }
         public DataTable CauHoiMayMan_GetAnswer(string userId)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_GetAnswer", userId);
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public void CauHoiMayMan_InsertPoint(string userId)
         {
             SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "CauHoiMayMan_InsertPoint"
                                         , userId
                                         
                                     );
         }
         public DataTable CauHoiMayMan_SumPoint(string userId)
         {
             DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "CauHoiMayMan_SumPoint", userId);
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public DataTable CauHoiMayMan_CheckExistSubRegister(string User_ID)
         {
             DataSet ds = SqlHelper.ExecuteDataset(AppEnv.ConnectionStringttndservices, "CauHoiMayMan_CheckExistSubRegister", User_ID);
             if (ds != null && ds.Tables.Count > 0)
             {
                 return ds.Tables[0];
             }
             return null;
         }
         public void CauHoiMayMan_ChargedUser_InsertLog(string User_ID, string Request_ID, string Service_ID, string Command_Code, string Registration_Channel, int Status, string Operator, string Reason, string Price)
         {
             SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "CauHoiMayMan_ChargedUser_InsertLog"
                                         , User_ID, Request_ID, Service_ID, Command_Code, Registration_Channel, Status, Operator, Reason, Price

                                     );
         }
        #endregion

        #region Check Wifi Visport/ Cau hoi may man
         public void AddDevice(string UserAgent, string ModelName, string BrandName, string DeviceOS, string MobileBrowser, string ResolutionWidth, string ResolutionHeight, string telco, int isWifi, int IsMobileDevice, string UrlReferer, string link, string ip, int type)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "Visport_Log_Click_Insert", UserAgent, ModelName, BrandName, DeviceOS, MobileBrowser, ResolutionWidth, ResolutionHeight, telco, isWifi, IsMobileDevice, UrlReferer, link, ip,type);
        }
        #endregion

        #region Landingpage
        public DataTable Landing94x_Manager_GetbyServiceID(int Service_ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionStringttndservices, "Landing94x_Manager_GetbyServiceID", Service_ID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
        public DataTable S294x_Getinfo(int Service_id)
        {
            string cmdText = "select * from  S2_TTND_Subscription_Services where id=" + Service_id;           
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionStringttndservices, CommandType.Text, cmdText);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
        #endregion
        #region dang ky Visport 
        public static DataTable Visport_Getservice_Info(int Service_id)
        {
            string cmdText = "select * from  Visport_Subscription_Services where id=" + Service_id;
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, cmdText);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
        public static void VmgAdsVisport_Log_Insert
            (
                string UserAgent,
                string ModelName,
                string BrandName,
                string DeviceOS,
                string MobileBrowser,
                string ResolutionWidth,
                string ResolutionHeight,
                string Telco,
                int IsWifi,
                int IsMobileDevice,
                string UrlReferer,
                string link,
                string IP,
                string Type,
                string CMD,
                string Msisdn,
                string requestType,
                int status,
                int Service_ID
            )
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "VmgAdsVisport_Log_Insert",
                UserAgent,
                ModelName,
                BrandName,
                DeviceOS,
                MobileBrowser,
                ResolutionWidth,
                ResolutionHeight,
                Telco,
                IsWifi,
                IsMobileDevice,
                UrlReferer,
                link,
                IP,
                Type,
                CMD,
                Msisdn,
                requestType,
                status,
                Service_ID
                );
        }
        #endregion

    }
}
using System;
using System.Data;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.Component.Video;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.TinTuc.UserControl
{
    public partial class SearchResult : BaseControl
    {
        readonly TinTucController _tinTucController = new TinTucController();
        readonly VideoController _videoController = new VideoController();

        private const int PageSize = 6;
        private const int PageNumber = 5;
        private int _curpageNews = 1;
        private int _curpageVideo = 1;
        protected string Keyword;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpageNews = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["vpage"]))
            {
                _curpageVideo = ConvertUtility.ToInt32(Request.QueryString["vpage"]);
            }

            string key = ConvertUtility.ToString(Request.QueryString["key"]);
            key = UnicodeUtility.SqlInjection(key);
            if (!string.IsNullOrEmpty(key))
            {
                Keyword = key;
                string genKey = key.Replace(" ", "+");

                key = UnicodeUtility.UnicodeToKoDau(key);
                DataSet dsNews = _tinTucController.GetNewsByKeyword(key, _curpageNews, PageSize);
                DataSet dsVideo = _videoController.GetVideoByKey(key, _curpageVideo, PageSize);

                if (dsNews != null)
                {
                    rptBaiViet.DataSource = dsNews.Tables[0];
                    rptBaiViet.DataBind();

                    int total = ConvertUtility.ToInt32(dsNews.Tables[1].Rows[0][0]);
                    lblBaiViet.Text = total.ToString();
                    Pagging1.totalrecord = total;
                    Pagging1.pagesize = PageSize;
                    Pagging1.numberpage = PageNumber;
                    Pagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&key=" + genKey;
                    Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&key=" + genKey + "&cpage=";
                }

                if (dsVideo != null)
                {
                    rptVideo.DataSource = dsVideo.Tables[0];
                    rptVideo.DataBind();

                    int total = ConvertUtility.ToInt32(dsVideo.Tables[1].Rows[0][0]);
                    lblVideo.Text = total.ToString();
                    VideoPagging.totalrecord = total;
                    VideoPagging.pagesize = PageSize;
                    VideoPagging.numberpage = PageNumber;
                    VideoPagging.defaultparam = "?display=" + Display + "&w=" + Width + "&key=" + genKey;
                    VideoPagging.queryparam = "?display=" + Display + "&w=" + Width + "&key=" + genKey + "&vpage=";
                }

            }
        }

        protected string KeywordHighlight(string body,string key)
        {
            if(!string.IsNullOrEmpty(body))
            {
                string strReturn = string.Empty;

                string[] arrBody = body.Split(' ');

                if (arrBody.Length > 0)
                {
                    if (key.Trim().Contains(" "))
                    {
                        string[] arrKey = key.Split(' ');
                        for (int i = 0; i < arrBody.Length;i++ )
                        {
                            if (arrBody[i].ToLower() == arrKey[0].ToLower() && arrBody[i+1].ToLower() == arrKey[1].ToLower())
                            {
                                strReturn = strReturn + " " + "<font style=\"background-color:yellow\">"
                                                        + arrKey[0].Substring(0, 1).ToUpper() + arrKey[0].Substring(1) 
                                                            + " "
                                                        + arrKey[1].Substring(0, 1).ToUpper() + arrKey[1].Substring(1) 
                                                            + "</font>";
                            }
                            else
                            {
                                if (arrBody[i].ToLower() != arrKey[1].ToLower())
                                    strReturn = strReturn + " " + arrBody[i];
                            }
                        }
                    }
                    else
                    {
                        foreach (var s in arrBody)
                        {
                            if (s.ToLower() == key.ToLower())
                            {
                                strReturn = strReturn + " " + "<font style=\"background-color:yellow\">" + key.Substring(0, 1).ToUpper() + key.Substring(1) + "</font>";
                            }
                            else
                            {
                                strReturn = strReturn + " " + s;
                            }

                        }
                    }

                    return strReturn;
                }
            }
            return body;
        }
    }
}
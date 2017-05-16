using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.TinTuc;
using Wap_TheThaoSo.Library.UrlProcess;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.TinTuc.UserControlLow
{
    public partial class Detail : BaseControl
    {
        readonly TinTucController _tinTucController = new TinTucController();
        private const int PageSize = 5;
        private const int PageNumber = 5;
        private int _curpage = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                _curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (id > 0)
            {
                DataSet ds = _tinTucController.GetNewsDetail(id, _curpage, PageSize, 1);
                if (ds != null)
                {
                    rptNewsDetail.DataSource = ds.Tables[0];
                    rptNewsDetail.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        rptOtherNews.DataSource = ds.Tables[1];
                        rptOtherNews.DataBind();

                        Pagging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[2].Rows[0][0]);
                        Pagging1.pagesize = PageSize;
                        Pagging1.numberpage = PageNumber;
                        Pagging1.defaultparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID + "&id=" + id;
                        Pagging1.queryparam = "?display=" + Display + "&w=" + Width + "&catid=" + CatID + "&id=" + id + "&cpage=";
                    }
                }
            }
        }


        #region Public Methods


        protected string ReplaceImageSource(string body)
        {

            List<string> imgSrc = AppEnv.GetSrc(body);

            foreach (var item in imgSrc)
            {

                if (item.IndexOf("http://") > -1)
                {
                    Match match = Regex.Match(body, "<img.*?src=\"" + item + "\".*?>", RegexOptions.RightToLeft);

                    if (match.Success)
                    {
                        string olgImg = match.Value.Substring(0, match.Value.IndexOf('>') + 1);
                        if (UserAgentInfo.model_name != "unknown")
                        {
                            body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img src=\"" + item + "\" width=\"300px;\"/></div>");
                        }
                        else
                        {
                            body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img src=\"" + item + "\" width=\"300px;\"/></div>");
                        }
                    }
                    else
                    {
                        body = body.Replace(item, item + "\" width=\"300px;\"");
                    }
                }
                else
                {

                    string newSrc = AppEnv.GetAvatarWaterMark(item, 200);

                    Match match = Regex.Match(body, "<img.*?src=\"" + item + "\".*?>", RegexOptions.RightToLeft);

                    if (match.Success)
                    {
                        string olgImg = match.Value.Substring(0, match.Value.IndexOf('>') + 1);
                        if (UserAgentInfo.model_name != "unknown")
                        {
                            body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img width=\"100%\" src=\"" + newSrc + "\"/></div>");
                        }
                        else
                        {
                            body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img src=\"" + newSrc + "\"/></div>");
                        }
                    }
                }
            }

            string temp = ReplaceLinkRelateNew(body).Replace("font-size: small;", "");
            return (temp);
        }

        private static string ReplaceLinkRelate(string body)
        {
            var document = new HtmlDocument();
            document.LoadHtml(body);
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//ul[@class='ul_reset']");

            string oldHtml = string.Empty;
            string newsHtml = string.Empty;

            if (nodes != null)
            {
                HtmlNode node = nodes.First();
                oldHtml = node.OuterHtml;
                newsHtml = node.OuterHtml;

                HtmlNodeCollection n2 = node.SelectNodes(".//li//a[@href]");
                if (n2 != null)
                {
                    foreach (var link in n2)
                    {
                        HtmlAttribute url = link.Attributes["href"];
                        string oldLink = url.Value;
                        string value = url.Value.Replace("http://thethaoso.vn/sport/", "");

                        string[] arr = value.Split('/');
                        string catId = arr[2];
                        string id = arr[3];

                        string newLink = AppEnv.GetSetting("WapDefault") + "/TinTuc/DefaultLow.aspx?display=detail&w=320&catid=" + catId + "&id=" + id;

                        newsHtml = newsHtml.Replace(oldLink, newLink);
                    }
                }

                body = body.Replace(oldHtml, newsHtml);
            }

            body = Regex.Replace(body, "<td width=\"40%\">.*?</td>", "", RegexOptions.Singleline);

            return body;//.Replace("style=\"width: 100%;\"","");
        }

        private static string ReplaceLinkRelateNew(string body)
        {
            var document = new HtmlDocument();
            document.LoadHtml(body);
            var nodes = document.DocumentNode.SelectNodes(@"//a[@href]");
            if (nodes != null)
            {
                foreach (var img in nodes)
                {
                    HtmlAttribute url = img.Attributes["href"];
                    string oldLink = url.Value;
                    string value = url.Value.ToLower().Replace("http://thethaoso.vn/sport/", "");

                    string[] arr = value.Split('/');

                    if(arr.Length > 3)
                    {
                        string catId = arr[2];
                        string id = arr[3];

                        string newLink = UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(catId), ConvertUtility.ToInt32(id));

                        body = body.Replace(oldLink, newLink);
                    }
                }
            }

            return body;
        }

        #endregion
    }
}
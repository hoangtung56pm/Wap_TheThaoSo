using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Wap_TheThaoSo.Library.Utilities
{
    public class MiscUtility
    {
        public static string UpdateQueryStringItem(HttpRequest httpRequest, string queryStringKey, string newQueryStringValue)
        {
            StringBuilder NewURL = new StringBuilder();

            NewURL.Append(httpRequest.RawUrl);

            if (httpRequest.QueryString[queryStringKey] != null)
            {
                string OrignalSet = String.Format("{0}={1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
                string NewSet = String.Format("{0}={1}", queryStringKey, newQueryStringValue);
                NewURL.Replace(OrignalSet, NewSet);
            }
            else if (httpRequest.QueryString.Count == 0)
            {
                NewURL.AppendFormat("?{0}={1}", queryStringKey, newQueryStringValue);
            }
            else
            {
                NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
            }

            return NewURL.ToString();
        }

        public static string UpdateQueryStringItem(HttpRequest httpRequest, string[] queryStringKeys, string[] newQueryStringValues)
        {
            StringBuilder NewURL = new StringBuilder();

            NewURL.Append(httpRequest.RawUrl.Replace("%20", " "));
            bool check = true;
            for (int i = 0; i < queryStringKeys.GetLength(0); i++)
            {
                string queryStringKey = queryStringKeys[i];
                string newQueryStringValue = newQueryStringValues[i];
                if (httpRequest.QueryString[queryStringKey] != null)
                {
                    string OrignalSet = String.Format("{0}={1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
                    string NewSet = String.Format("{0}={1}", queryStringKey, newQueryStringValue);
                    NewURL.Replace(OrignalSet, NewSet);
                }
                else if (httpRequest.QueryString.Count == 0)
                {
                    if (newQueryStringValue != "" && newQueryStringValue != null)
                    {
                        if (check)
                        {
                            NewURL.AppendFormat("?{0}={1}", queryStringKey, newQueryStringValue);
                            check = false;
                        }
                        else NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
                    }
                }
                else if (newQueryStringValue != "" && newQueryStringValue != null) NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
            }

            return NewURL.ToString();
        }
        public static string UpdateQueryStringItemRewrite(HttpRequest httpRequest, string queryStringKey, string newQueryStringValue)
        {
            StringBuilder NewURL = new StringBuilder();

            NewURL.Append(httpRequest.RawUrl);

            if (httpRequest.QueryString[queryStringKey] != null)
            {
                string OrignalSet = String.Format("{0}/{1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
                string NewSet = String.Format("{0}/{1}", queryStringKey, newQueryStringValue);
                NewURL.Replace(OrignalSet, NewSet);
            }
            else if (httpRequest.QueryString.Count == 0)
            {
                NewURL.AppendFormat("?{0}/{1}", queryStringKey, newQueryStringValue);
            }
            else
            {
                NewURL.AppendFormat("&{0}/{1}", queryStringKey, newQueryStringValue);
            }

            return NewURL.ToString();
        }

        public static string UpdateQueryStringItemRewrite(HttpRequest httpRequest, string[] queryStringKeys, string[] newQueryStringValues)
        {
            StringBuilder NewURL = new StringBuilder();

            NewURL.Append(httpRequest.RawUrl.Replace("%20", " "));
            bool check = true;
            for (int i = 0; i < queryStringKeys.GetLength(0); i++)
            {
                string queryStringKey = queryStringKeys[i];
                string newQueryStringValue = newQueryStringValues[i];
                if (httpRequest.QueryString[queryStringKey] != null)
                {
                    string OrignalSet = String.Format("{0}/{1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
                    string NewSet = String.Format("{0}/{1}", queryStringKey, newQueryStringValue);
                    NewURL.Replace(OrignalSet, NewSet);
                }
                else if (httpRequest.QueryString.Count == 0)
                {
                    if (newQueryStringValue != "" && newQueryStringValue != null)
                    {
                        if (check)
                        {
                            NewURL.AppendFormat("?{0}/{1}", queryStringKey, newQueryStringValue);
                            check = false;
                        }
                        else NewURL.AppendFormat("&{0}/{1}", queryStringKey, newQueryStringValue);
                    }
                }
                else if (newQueryStringValue != "" && newQueryStringValue != null)
                {
                    NewURL = NewURL.Replace(".aspx", "");
                    NewURL.AppendFormat("/{0}/{1}", queryStringKey, newQueryStringValue);
                    NewURL.AppendFormat("{0}", ".aspx"); ;
                }
            }

            return NewURL.ToString();
        }
    }
}
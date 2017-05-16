using log4net;
using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap
{
    public partial class CauHoi_Wifi : BasePage
    {
      protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("http://visport.vn");
            if (!Page.IsPostBack)
            {
                //if (string.IsNullOrEmpty(CheckMsisdn()))
                //{
                //    Response.Redirect("/Wap/cauhoi.aspx");
                //}
            }
        }

      public string CheckMsisdn()
      {
          string msisdn = string.Empty;

          if (Session["MSISDN"] != null && Session["MSISDN"].ToString() != "Khách")
          {
              msisdn = Session["MSISDN"].ToString();
          }

          return msisdn;
      }
    }
}

﻿using System;
using Wap_TheThaoSo.Library;

namespace Wap_TheThaoSo.NhacChuong
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEnv.GetMsisdn();
                ltrWidth.Text = "<meta content=\"width=" + Width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            switch (Display)
            {
                case "nhacchuong":
                    plContent.Controls.Add(LoadControl("UserControl/NhacChuong.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/NhacChuongChiTiet.ascx"));
                    break;
            }
        }
    }
}
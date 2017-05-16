using log4net;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;
using Wap_TheThaoSo.VnmCharging;

namespace Wap_TheThaoSo.Wap
{
    public partial class CauHoi : BasePage
    {
        readonly SqlProvider _sql = new SqlProvider();
        //string userId = "841864950687";
        private string price = "1000";
        private string messageReturn = string.Empty;
        //int checkAnswer;
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Redirect("http://visport.vn");
            //Session["msisdn"] = "841882406279";
            if (Session["msisdn"] == null)
            {
                AppEnv.GetMsisdnWithParam("4");
            }
            //messageReturn = "sdt";
            //ILog logger = LogManager.GetLogger(Session["msisdn"].ToString());
            //logger.Debug("---" + messageReturn + "---");

            //pnlCauHoi.Visible = true;
            if (!Page.IsPostBack)
            {
                #region Dem Luot click
                User_AgentInfo _info = new User_AgentInfo();
                string link = "http://visport.vn/Wap/CauHoi.aspx";
                _info = Get_User_Agent_Info(link);
                #endregion

                InsertCauHoi(CheckMsisdn());
                pnlCauHoi.Visible = true;
                //pnlButton.Visible = true;
                if (!string.IsNullOrEmpty(CheckMsisdn()))
                {
                    pnlCauHoi.Visible = true;
                    string userId = CheckMsisdn();
                    txtsdt.Text = "SĐT: " + userId;
                    DataTable dtCheckSub = _sql.CauHoiMayMan_CheckExistSubRegister(CheckMsisdn());
                    bool registed = false;
                    if (dtCheckSub != null && dtCheckSub.Rows.Count > 0)
                    {
                        registed = true;
                    }

                    if (!registed)
                    {
                        WS_94x.S2Vnm obj94x = new WS_94x.S2Vnm();
                        //string str94xret = obj94x.SynchronizeUser("949", DateTime.Now.ToString("ddMMyyyy"), userId, "DK", "DK MM", 604, 1);
                        string str94xret = obj94x.RegisterService("949", "0", userId, "DK", "DK MM");

                    }
                    DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(CheckMsisdn());
                    int dem = ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString());

                    if (dem <= 5)
                    {
                        int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
                        if (checkAnswer > 0)
                        {
                            LoadCauHoi(CheckMsisdn(), checkAnswer);
                        }
                    }
                    else if (dem > 5)
                    {
                        //lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";
                        try
                        {
                            if (Session["Check"].ToString() == "1")
                            {
                                int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
                                if (checkAnswer > 0)
                                {
                                    LoadCauHoi(CheckMsisdn(), checkAnswer);
                                }
                            }
                        }
                        catch
                        {
                            lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";
                            pnlButton.Visible = false;
                        }
                    }
                }
                else
                {
                    //truy cập 3g để sử dụng dịch vụ
                    Response.Redirect("/Wap/cauhoi_Wifi.aspx");
                }

            }

        }
        protected User_AgentInfo Get_User_Agent_Info(string link)
        {
            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
            o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            User_AgentInfo _info = new User_AgentInfo();
            _info.device_os = o_capabilityGetter.getCapability("device_os");
            _info.mobile_browser = o_capabilityGetter.getCapability("mobile_browser");
            _info.resolution_width = o_capabilityGetter.getCapability("resolution_width");
            _info.resolution_height = o_capabilityGetter.getCapability("resolution_height");
            _info.model_name = o_capabilityGetter.getCapability("model_name");
            _info.brand_name = o_capabilityGetter.getCapability("brand_name");

            int IsMobileDevice = 0;
            if (HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                IsMobileDevice = 1;
            }

            string ip = ClientIp;
            var _urlRefer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            string telco = "other";
            int isWifi = 1;
            if (CheckIsWifi.IsVinaphone(ip))
            {
                telco = "gpc";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsViettel(ip))
            {
                telco = "viettel";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsMobi(ip))
            {
                telco = "vms";
                isWifi = 0;
            }
            else if (CheckIsWifi.IsVnm(ip))
            {
                telco = "vnm";
                isWifi = 0;
            }

            _sql.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, telco, isWifi, IsMobileDevice, _urlRefer, link, ip, 2);
            return _info;
        }
        private static string ClientIp
        {
            get
            {
                var _ip = HttpContext.Current.Request.UserHostAddress;
                return _ip;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            #region LOAD CauHoi

            LoadDiem(CheckMsisdn());
            DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(CheckMsisdn());
            int dem = ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString());
            lblSttCauHoi.Text = ConvertUtility.ToString(dem + 1);
            #endregion
        }
        protected void btnP1_Click(object sender, EventArgs e)
        {

            int QuestionID = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
            if (QuestionID > 0)
            {
                _sql.CauHoiMayMan_UpdateAnswer(CheckMsisdn(), QuestionID, "1");
                if (!string.IsNullOrEmpty(CheckMsisdn()))
                {
                    CheckDapAn(CheckMsisdn(), QuestionID, "1");
                }
            }
            Session["Check"] = "0";
        }


        protected void btnP2_Click(object sender, EventArgs e)
        {

            int QuestionID = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
            if (QuestionID > 0)
            {
                _sql.CauHoiMayMan_UpdateAnswer(CheckMsisdn(), QuestionID, "2");
                if (!string.IsNullOrEmpty(CheckMsisdn()))
                {
                    CheckDapAn(CheckMsisdn(), QuestionID, "2");
                }
            }
            Session["Check"] = "0";

        }

        #endregion

        #region Methods

        //public void CheckAnswer(string userId,int QuestionID, string answer)
        //{
        //    #region CAU HOI MAY MAN

        //        DataTable dtAnswer = _sql.CauHoiMayMan_GetAnswerOfQuestion(CheckMsisdn(), QuestionID);
        //        if (dtAnswer != null && dtAnswer.Rows.Count > 0)
        //        {
        //            if (ConvertUtility.ToString(dtAnswer.Rows[0]["True_Answer"]) == answer)
        //            {
        //                //tra loi dung
        //                _sql.CauHoiMayMan_InsertPoint(userId);
        //            }
        //            else
        //            {
        //                //Tra loi sai
        //            }

        //        }

        //    #endregion
        //}
        public void CheckDapAn(string userId, int QuestionID, string answer)
        {
            #region CAU HOI MAY MAN

            DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(CheckMsisdn());
            int dem = ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString());
            DataTable dtAnswer = _sql.CauHoiMayMan_GetAnswerOfQuestion(userId, QuestionID);
            string answerMt = answer.Trim().ToUpper();

            if (dtAnswer != null && dtAnswer.Rows.Count > 0)
            {
                string answerDb = dtAnswer.Rows[0]["True_Answer"].ToString().Trim().ToUpper();
                //int questionId = ConvertUtility.ToInt32(dtAnswer.Rows[0]["Question_Id"].ToString());

                if (answerMt == answerDb)//TRA LOI DUNG CAU HOI
                {
                    _sql.CauHoiMayMan_InsertPoint(userId);
                    #region TRA LOI DUNG

                    if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) == 5)
                    {
                        lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";

                        pnlButton.Visible = false;
                        btMuaThem.Enabled = true;
                    }
                    else
                        if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 5)
                        {

                            #region CAU HOI TIEP THEO
                            int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
                            if (checkAnswer > 0)
                            {
                                LoadCauHoi(CheckMsisdn(), checkAnswer);
                            }
                            #endregion
                        }
                        else if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) > 5)
                        {
                            //LoadQuestion(userId);
                            //lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";
                            pnlButton.Visible = false;
                            btMuaThem.Enabled = true;

                        }

                    #endregion

                }
                else//TRA LOI SAI
                {

                    #region TRA LOI SAI
                    if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) == 5)
                    {

                        lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";

                        pnlButton.Visible = false;
                        btMuaThem.Enabled = true;
                    }
                    else
                        if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 5)
                        {

                            #region CAU HOI TIEP THEO
                            int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
                            if (checkAnswer > 0)
                            {
                                LoadCauHoi(CheckMsisdn(), checkAnswer);
                            }
                            #endregion
                        }
                        else if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) > 5)
                        {
                            //lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi miễn phí trong ngày. Mua thêm để chơi tiếp";
                            pnlButton.Visible = false;
                            btMuaThem.Enabled = true;

                        }

                    #endregion

                }
            }

            #endregion
        }

        public void LoadCauHoi(string userId, int QuestionID)
        {

            //DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(userId);
            //dem = ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString());
            //if ( dem <= 10)
            //{

            DataTable dtLoadQuetion = _sql.CauHoiMayMan_LoadQuetionToAnswer(userId, QuestionID);
            if (dtLoadQuetion != null && dtLoadQuetion.Rows.Count > 0)
            {

                lblCauHoi.Text = dtLoadQuetion.Rows[0]["Question"].ToString(); ;
                btnP1.Text = dtLoadQuetion.Rows[0]["Q_Answer1"].ToString();
                btnP2.Text = dtLoadQuetion.Rows[0]["Q_Answer2"].ToString();

            }
            //}
            //else
            //{
            //    lblSttCauHoi.Text = "Bạn đã trả lời hết 10 số câu hỏi trong ngày";
            //}



        }
        public void LoadDiem(string userId)
        {
            DataTable dtdiem = _sql.CauHoiMayMan_SumPoint(userId);
            int diem = 0;
            int stt = 0;
            if (dtdiem != null && dtdiem.Rows.Count > 0)
            {
                diem = ConvertUtility.ToInt32(dtdiem.Rows[0]["Diem"].ToString());
                stt = ConvertUtility.ToInt32(dtdiem.Rows[0]["Stt"].ToString());
                if (diem > 0)
                {
                    pnDiem.Visible = true;
                    lblDiem.Text = ConvertUtility.ToString(diem);
                    lblStt.Text = ConvertUtility.ToString(stt);
                }
                else
                {
                    lblDiem.Text = "0";
                    lblStt.Text = "0";
                }
            }
        }

        public void InsertCauHoi(string userId)
        {
            DataTable dtCountQues = _sql.CauHoiMayMan_CountAnswerLog_Today(userId);
            //DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(userId);
            //int DemCauHoi = ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString());
            //if (DemCauHoi==0)
            //{
            //    DataTable dtquestion = _sql.CauHoiMayMan_LoadRandomQuestion();
            //    if (dtquestion != null && dtquestion.Rows.Count > 0)
            //    {
            //        foreach (DataRow rowQuestion in dtquestion.Rows)
            //        {
            //            _sql.CauHoiMayMan_Answer_Log_Insert(userId, ConvertUtility.ToInt32(rowQuestion["ID"]), ConvertUtility.ToString(rowQuestion["Question"]), ConvertUtility.ToString(rowQuestion["Answer"]), 0);
            //        }
            //    }
            //}
            int DemCauHoi = _sql.CauHoiMayMan_CheckAnswer_Today(userId);
            if (DemCauHoi == 0)
            {
                DataTable dtquestion = _sql.CauHoiMayMan_LoadRandomQuestion();
                if (dtquestion != null && dtquestion.Rows.Count > 0)
                {
                    foreach (DataRow rowQuestion in dtquestion.Rows)
                    {
                        _sql.CauHoiMayMan_Answer_Log_Insert(userId, ConvertUtility.ToInt32(rowQuestion["ID"]), ConvertUtility.ToString(rowQuestion["Question"]), ConvertUtility.ToString(rowQuestion["Answer"]), 0);
                    }
                }
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

        #endregion

        protected void btMuaThem_Click(object sender, EventArgs e)
        {
            InsertCauHoi(CheckMsisdn());
            //Session["Check"] = "1";
            ////check = true;
            //pnlButton.Visible = true;
            //if (Session["Check"].ToString() == "1")
            //{
            //    int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
            //    if (checkAnswer > 0)
            //    {
            //        LoadCauHoi(CheckMsisdn(), checkAnswer);
            //    }
            //}
            string msisdn = CheckMsisdn();

            if (msisdn != string.Empty)
            {
                ILog logger = LogManager.GetLogger(Session["msisdn"].ToString());
                //DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(msisdn);

                //if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 10)
                //{
                try
                {

                    var wsCgw = new WebServiceCharging3g();
                    messageReturn = wsCgw.PaymentVnmWithAccount(msisdn, price, "CauHoiMayMan", "viSport", AppEnv.GetSetting("user_3g"), AppEnv.GetSetting("pass_3g"), AppEnv.GetSetting("userid_3g"));
                    
                    logger.Debug("Câu hỏi may mắn");
                    logger.Debug("---" + messageReturn + "---");

                    if (messageReturn == "1")
                    {// Thanh toán thành công >> Load cau hoi moi 
                        Session["Check"] = "1";
                        //check = true;
                        _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", "succ", price);

                        //check = true;
                        pnlButton.Visible = true;
                        //if (Session["Check"].ToString() == "1")
                        //{
                        int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
                        if (checkAnswer > 0)
                        {
                            LoadCauHoi(CheckMsisdn(), checkAnswer);
                        }
                        //}
                    }

                    else if (messageReturn == "Result:12,Detail:Not enough money")
                    {

                        litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
                        _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", messageReturn, price);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        litScript.Text = ("<script type=\"text/javascript\">alert('Hệ thống bận vui lòng thử lại sau !'); </script>");
                        _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", messageReturn, price);
                    }
                }
                catch (Exception ex)
                {
                    litScript.Text = ("<script type=\"text/javascript\">alert('Hệ thống bận vui lòng thử lại sau !'); </script>");
                    _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", ex.ToString(), price);
                    logger.Debug("---" + ex + "---");
                }
                //}

            }

        }

        //bool check = false;
        //protected void btMuaThem_Click(object sender, EventArgs e)
        //{
        //    InsertCauHoi(CheckMsisdn());
        //    //Session["Check"] = "1";
        //    ////check = true;
        //    //pnlButton.Visible = true;
        //    //if (Session["Check"].ToString() == "1")
        //    //{
        //    //    int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
        //    //    if (checkAnswer > 0)
        //    //    {
        //    //        LoadCauHoi(CheckMsisdn(), checkAnswer);
        //    //    }
        //    //}
        //    string msisdn = CheckMsisdn();

        //    if (msisdn != string.Empty)
        //    {
        //        //DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(msisdn);

        //        //if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 10)
        //        //{
        //            var charging = new Library.VNMCharging.VNMChargingGW();
        //            messageReturn = charging.StrPaymentVnm(Session["msisdn"].ToString(), price, "CauHoiMayMan");
        //            ILog logger = LogManager.GetLogger(Session["msisdn"].ToString());
        //            logger.Debug("---" + messageReturn + "---");

        //            if (messageReturn == "1")
        //            {// Thanh toán thành công >> Load cau hoi moi 
        //                Session["Check"] = "1";
        //                //check = true;
        //                _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", "succ", price);

        //                //check = true;
        //                pnlButton.Visible = true;
        //                //if (Session["Check"].ToString() == "1")
        //                //{
        //                int checkAnswer = _sql.CauHoiMayMan_CheckAnswer_Today(CheckMsisdn());
        //                if (checkAnswer > 0)
        //                {
        //                    LoadCauHoi(CheckMsisdn(), checkAnswer);
        //                }
        //                //}
        //            }
        //            else if (messageReturn == "-1")
        //            {// Thanh toán không thành công >> thông báo lỗi
        //                _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", "fail", price);
        //            }
        //            else
        //            {

        //                litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
        //                _sql.CauHoiMayMan_ChargedUser_InsertLog(Session["msisdn"].ToString(), "0", "949", "MM", "Wap", 1, "vnmobile", "fail", price);
        //            }
        //        //}
        //    }

        //}

    }
}
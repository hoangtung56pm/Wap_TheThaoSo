using System;
using System.Data;
using Wap_TheThaoSo.Library;
using Wap_TheThaoSo.Library.Component.Provider;
using Wap_TheThaoSo.Library.Utilities;

namespace Wap_TheThaoSo.Wap
{
    public partial class CauHoiWap : BasePage
    {
        //readonly SqlProvider _sql = new SqlProvider();
        //string userId = "841864950687";
        //#region Events

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        //if (!string.IsNullOrEmpty(CheckMsisdn()))
        //        //{
        //        //    pnlCauHoi.Visible = true;
        //        //    string userId = CheckMsisdn();
        //        //    DataTable dtCheckSub = _sql.CauHoiMayMan_CheckExistSubRegister(userId);
        //        //    if (dtCheckSub != null && dtCheckSub.Rows.Count > 0)
        //        //    {
        //        //        #region LOAD CauHoi 1

        //        //        LoadQuestion(userId);

        //        //        #endregion
        //        //    }
        //        //    else
        //        //    {
        //        //        pnAlert.Visible = true;
        //        //    }
                    
        //        //}
        //        //else
        //        //{
        //        //    pnlThongBao.Visible = true;
        //        //}
        //        pnlCauHoi.Visible = true;


        //        #region LOAD CauHoi 1

        //        LoadQuestion(userId);

        //        #endregion
               
        //    }
        //}

        //protected void btnP1_Click(object sender, EventArgs e)
        //{
        //    //if (!string.IsNullOrEmpty(CheckMsisdn()))
        //    //{
        //    //    CheckAnswer(CheckMsisdn(), "1");
        //    //}
        //    //else
        //    //{
        //    //    pnlThongBao.Visible = true;
        //    //}
        //    int idquestion= _sql.CauHoiMayMan_GetQuestionToUpdate(userId);
        //    _sql.CauHoiMayMan_UpdateAnswer(userId, idquestion, "1");
        //    CheckAnswer(userId, "1");
        //}

        //protected void btnP2_Click(object sender, EventArgs e)
        //{
        //    //if (!string.IsNullOrEmpty(CheckMsisdn()))
        //    //{
        //    //    CheckAnswer(CheckMsisdn(), "2");
        //    //}
        //    //else
        //    //{
        //    //    pnlThongBao.Visible = true;
        //    //}
        //    int idquestion = _sql.CauHoiMayMan_GetQuestionToUpdate(userId);
        //    _sql.CauHoiMayMan_UpdateAnswer(userId, idquestion, "2");
        //    CheckAnswer(userId, "2");
        //}

        //#endregion

        //#region Methods

        //public void CheckAnswer(string userId, string question)
        //{
        //    #region CAU HOI TPBD

        //    DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(userId);
        //    DataTable dtAnswer = _sql.CauHoiMayMan_GetAnswer(userId);
        //    string answerMt = question.Trim().ToUpper();

        //    if (dtAnswer != null && dtAnswer.Rows.Count > 0)
        //    {
        //        string answerDb = dtAnswer.Rows[0]["True_Answer"].ToString().Trim().ToUpper();
        //        int questionId = ConvertUtility.ToInt32(dtAnswer.Rows[0]["Question_Id"].ToString());

        //        if (answerMt == answerDb)//TRA LOI DUNG CAU HOI
        //        {
        //            pnlDapAn.Visible = true;

        //            #region TRA LOI DUNG

        //            if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) == 10)
        //            {
                        
        //                //CONG 1 MDT
        //                _sql.CauHoiMayMan_InsertPoint(userId);

        //                lblDapAn.Text = " ĐÚNG ";
        //                //lblMdt.Text = " 1 ";

        //                lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi trong ngày. Xin cảm ơn";
        //                pnlButton.Visible = false;
        //            }
        //            else if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 10)
        //            {
                       
        //                //CONG 1 MDT
        //                _sql.CauHoiMayMan_InsertPoint(userId);

        //                #region CAU HOI TIEP THEO

        //                LoadQuestion(userId);

        //                #endregion
        //            }

        //            #endregion

        //        }
        //        else//TRA LOI SAI
        //        {
        //            pnlDapAn.Visible = true;

        //            #region TRA LOI SAI

        //            if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) == 10)
        //            {
        //                //SendMtSportGameHero(User_ID, messageReturn, Service_ID, Command_Code, Request_ID, 0);// SEND MT GUI msg Thong bao Tra Loi SAI

        //                lblDapAn.Text = " SAI ";
        //                //lblMdt.Text = " 0 ";

        //                //CONG 0 MDT
                        
        //                lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi trong ngày. Xin cảm ơn";
        //                pnlButton.Visible = false;
        //            }
        //            else if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) < 10)
        //            {
        //                lblDapAn.Text = " SAI ";
        //                //lblMdt.Text = " 0 ";
        //                //CONG 0 MDT
                       

        //                #region CAU HOI TIEP THEO

        //                LoadQuestion(userId);

        //                #endregion
        //            }

        //            #endregion

        //        }
        //    }

        //    #endregion
        //}

        //public void LoadQuestion(string userId)
        //{
        //    DataTable dtdiem = _sql.CauHoiMayMan_SumPoint(userId);
        //    int diem = 0;
        //    int stt = 0;
        //    if (dtdiem != null && dtdiem.Rows.Count > 0)
        //    {
        //        diem = ConvertUtility.ToInt32(dtdiem.Rows[0]["Diem"].ToString());
        //        stt = ConvertUtility.ToInt32(dtdiem.Rows[0]["Stt"].ToString());
        //        if (diem > 0)
        //        {
        //            pnDiem.Visible = true;
        //            lblDiem.Text = ConvertUtility.ToString(diem);
        //            lblStt.Text = ConvertUtility.ToString(stt);
        //        }
        //    }

        //    DataTable dtCountQues = _sql.CauHoiMayMan_CountQuestion_Today(userId);
        //    if (ConvertUtility.ToInt32(dtCountQues.Rows[0]["RETURN_ID"].ToString()) >= 10)
        //    {
        //        pnlCauHoi.Visible = true;
        //        lblCauHoi.Text = "Bạn đã trả lời hết số câu hỏi trong ngày. Xin cảm ơn";
        //        pnlButton.Visible = false;
        //    }
        //    else
        //    {

        //        DataTable dtQuestion = _sql.CauHoiMayMan_GetQuestion();
        //        if (dtQuestion != null && dtQuestion.Rows.Count > 0)
        //        {
        //            string message = dtQuestion.Rows[0]["Question"].ToString();
        //            //message = message.Replace("P1", "1").Replace("P2", "2");

        //            int questionIdnew = ConvertUtility.ToInt32(dtQuestion.Rows[0]["Id"].ToString());
        //            string answer = dtQuestion.Rows[0]["Answer"].ToString();
        //            //answer = answer.Replace("P1", "1").Replace("P2", "2");
                   
        //            _sql.CauHoiMayMan_Answer_Log_Insert(userId, questionIdnew, message, answer, 0); // LUU LOG Question
        //            lblCauHoi.Text = message;
        //            btnP1.Text = dtQuestion.Rows[0]["Q_Answer1"].ToString();
        //            btnP2.Text = dtQuestion.Rows[0]["Q_Answer2"].ToString();
        //        }

        //    }
            
        //}

        //public string CheckMsisdn()
        //{
        //    string msisdn = string.Empty;

        //    if (Session["MSISDN"] != null && Session["MSISDN"].ToString() != "Khách")
        //    {
        //        msisdn = Session["MSISDN"].ToString();
        //    }

        //    return msisdn;
        //}

        //#endregion

        

    }
}
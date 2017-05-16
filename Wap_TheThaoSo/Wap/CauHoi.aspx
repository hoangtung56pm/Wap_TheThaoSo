<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CauHoi.aspx.cs" Inherits="Wap_TheThaoSo.Wap.CauHoi" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>


<%@ Register Src="UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />

    <title>.: Câu hỏi may mắn :.</title>
    <link href="/assets/Css/Style.css" rel="stylesheet" />
    <link href="/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/masonry/3.3.2/masonry.pkgd.min.js"></script>
    <script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/assets/plugins/bootstrap/js/bootstrap.js"></script>

</head>
<body style="margin:0px auto">
    <form id="form1" runat="server">
       
        <div id="body">
            <div class="header">
                <a href="/Wap/CauHoi_TheLe.aspx">
                    <img src="/assets/Images/app_Quest_3G.png" /></a>
                <div class="sdt">                 
                    <a href="#"><asp:Label runat="server" ID="txtsdt" Font-Size="17px"></asp:Label>
                        <%--<span style="font-size: 18px"></span>--%> </a>
                </div>

            </div>
            <div class="content">
                <div class="title">
                    <img style="width: 99%" src="/assets/Images/title.png" />
                </div>
                <div class="content_quest">
                    <div class="ads">
                        <div style="width: 100%">
                            <%--<span>5</span>--%>
                            <asp:Label runat="server" ID="lblSttCauHoi"></asp:Label>
                        </div>
                    </div>
                    <div class="quest_title">
                        <p style="color: white; font-size: 20px; padding-left: 10px">Câu hỏi:</p>
                    </div>
                    <div class="quest_content">
                        <asp:Panel ID="pnlCauHoi" Visible="False" runat="server">
                            <div class="question">
                                <p style="color: white; padding-left: 30px; font-size: 18px; padding-top: 20px; padding-bottom: 20px; padding-right: 30px">
                                    <asp:Label runat="server" ID="lblCauHoi" ></asp:Label>
                                </p>
                                <asp:Panel ID="pnlButton" runat="server">
                                    <div class="quest_1">
                                        <img src="/assets/Images/dapan1.jpg" />
                                        <%--<button type="button">5 tỷ năm</button>--%>
                                        <asp:Button ID="btnP1" CssClass="btanswer" runat="server" OnClick="btnP1_Click" />
                                    </div>
                                    <div class="quest_2">
                                        <img src="/assets/Images/dapan2.jpg" />
                                        <%--<button type="button">7 tỷ năm</button>--%>
                                        <asp:Button ID="btnP2" CssClass="btanswer" runat="server" OnClick="btnP2_Click" />
                                    </div>
                                </asp:Panel>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div class="reward" id="pnDiem" runat="server" visible="true">

                    <div style="color: white; padding-left: 15px; font-size: 14px; padding-top: 10px; padding-bottom: 10px; padding-right: 15px">
                        Bạn đang có
                            <asp:Label ID="lblDiem" ForeColor="Yellow" runat="server"></asp:Label>
                        điểm và đang nằm trong top
                            <asp:Label ID="lblStt" ForeColor="Yellow" runat="server"></asp:Label>
                        để giành được giải thưởng
                    </div>

                </div>
            </div>
            <div class="btnBought" align="center">
                <asp:Button runat="server" CssClass="btnBuy" ID="btMuaThem" OnClick="btMuaThem_Click"/>
            </div>


        </div>
        <div class="modal fade" id="popup-login">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">
                                <img
                                    src="/library/images/close_popup.png" alt="" style="width: 28px"></span></button>
                        <img style="width: 100%; margin-top: -30px;" src="/assets/Images/popup_ko-du_tien.png" />
                    </div>

                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <asp:Literal ID="litScript" runat="server"></asp:Literal>
    </form>
</body>
</html>

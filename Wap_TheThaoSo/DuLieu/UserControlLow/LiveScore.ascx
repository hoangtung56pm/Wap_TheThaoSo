<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveScore.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.LiveScore" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="DropBox.ascx" TagName="DrogBox" TagPrefix="uc2" %>
<%@ Register Src="TopLeague.ascx" TagName="TopLeague" TagPrefix="uc3" %>
<div id="content">
    <div class="home_content">
        <div class="clear5px">
        </div>
        <div class="home_conent_top">
            <div class="item">
                <div class="item-top item-bg">
                    <div class="red-separator margin-left2px">
                    </div>
                    <div class="floatleft padding-left5px padding-right5px  background-white">
                        <a href="javascript:void(0)">Live Score</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                    <uc2:DrogBox ID="DrogBox1" runat="server" />
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <table class="table dulieu-header" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="color-white width80px">
                                <b class="padding-left10px">Thời gian</b>
                            </td>
                            <td style="border: 1px; width: 1px; background-color: #fff">
                            </td>
                            <td class="color-white  text-align-center">
                                <b>Trận</b>
                            </td>
                        </tr>
                    </table>
                    <%--<div class="clear5px"></div>--%>

                    <asp:Panel runat="server" ID="pnlHotMatch">
                    
                    <%--Begin Tran Cau Tam Diem--%>
                    <table class="table item" cellpadding="0">
                        <%--<asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                            <ItemTemplate>--%>
                                <tr class="item-header">
                                    <td colspan="5">
                                        <img alt="" class="padding-top2px" src="/layout/images/icon-bong.png"/>
                                        <a class="textNonDecoration color-white bold"
                                            href="#">
                                            Trận cầu tâm điểm
                                        </a>
                                    </td>
                                    <asp:Repeater ID="rptHotMatch" runat="server" EnableViewState="false">
                                        <ItemTemplate>
                                            <tr class="item-sub lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width125px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px"><%# UrlProcess.GetLinkName(Eval("Status").ToString(),Eval("RateAsia").ToString()) %></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="item-sub-alternate lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width125px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px"><%# UrlProcess.GetLinkName(Eval("Status").ToString(),Eval("RateAsia").ToString()) %></a>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </tr>
                           <%-- </ItemTemplate>
                        </asp:Repeater>--%>
                    </table>
                    <%--End Tran Cau Tam Diem--%>

                    </asp:Panel>

                    <table class="table item" cellpadding="0">
                        <asp:Repeater ID="rptParent" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <tr class="item-header">
                                    <td colspan="5">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("Area_Name").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetTopBxhLowUrl(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Name") %>
                                            -
                                            <%# Eval("Area_Name")%>
                                        </a>
                                        <%--<img style="float: right" alt="" src="/layout/images/icon-plus.png" />--%>
                                    </td>
                                    <asp:Repeater ID="rptChild" runat="server" EnableViewState="false">
                                        <ItemTemplate>
                                            <tr class="item-sub lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width125px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px"><%# UrlProcess.GetLinkName(Eval("Status").ToString(),Eval("RateAsia").ToString()) %></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="item-sub-alternate lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width125px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px"><%# UrlProcess.GetLinkName(Eval("Status").ToString(),Eval("RateAsia").ToString()) %></a>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="clear0px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc3:TopLeague ID="TopLeague1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

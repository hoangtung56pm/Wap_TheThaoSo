<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.Calendar" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="TopLeague.ascx" TagName="TopLeague" TagPrefix="uc2" %>
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
                        <a href="javascript:void(0)">Dữ liệu</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                    <div class="floatright padding-right5px background-white">
                        <asp:DropDownList ID="dgrSeason" runat="server" AutoPostBack="true" CssClass="combo"
                            OnSelectedIndexChanged="dgrSeason_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="dgrWeek" runat="server" AutoPostBack="true" CssClass="combo"
                            OnSelectedIndexChanged="dgrWeek_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="background-white">
                        <div class="background-xam floatleft height18px lineheight text-align-center width30percent">
                            <a style="display:block" class="color-white" href="<%= CalendarLink %>">Lịch thi đấu</a>
                        </div>
                        <div class="floatleft text-align-center width30percent height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= BxhLink %>">BXH</a>
                        </div>
                        <div class="floatleft text-align-center width30percent height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= TopGhiBanLink %>">Top ghi bàn</a>
                        </div>
                    </div>
                    <div class="clear1px">
                    </div>
                    <%--<div class="clear1px"></div>--%>
                    <div class="item">
                        <asp:Repeater ID="rptInfo" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <div class="item-header">
                                    <div class="floatleft padding-left5px">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="javascript:void(0)">
                                            <%# Eval("Name") %>
                                        </a>
                                    </div>
                                    <div class="floatright margin-top3px padding-right5px">
                                        <img alt="" src="/layout/images/icon-plus.png" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div id="divTranCauSangNhat" runat="server" visible="false" class="background-xanh-nhat text-align-center bold lineheight25">
                                Nhận trận cầu sáng nhất giải <asp:Literal EnableViewState="false" ID="litName" runat="server"></asp:Literal> 
                                >>
                                <asp:HyperLink CssClass="textNonDecoration color-black" ID="lnkBamDay" runat="server" EnableViewState="false">
                                    Bấm đây
                                </asp:HyperLink>
                        </div>

                        <div class="clear1px">
                        </div>
                        <table class="table">
                            <asp:Repeater ID="rptChild" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <tr class="item-sub lineheight">
                                        <td class="width70px">
                                            <%# AppEnv.ConvertTime(Eval("TimeDay").ToString()) %>/<%# AppEnv.ConvertTime(Eval("TimeMonth").ToString()) %>
                                            <%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>
                                        </td>
                                        <td class=" width125px text-align-right padding-right5px">
                                            <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                class="textNonDecoration color-black">
                                                <%# Eval("Team_A_Name") %></a>
                                        </td>
                                        <td class="width70px background-xam-dadada text-align-center">
                                            <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                class="textNonDecoration color-chitiet"><b>
                                                    <%# Eval("Fs_A") %>
                                                    -
                                                    <%# Eval("Fs_B") %></b> </a>
                                        </td>
                                        <td class=" padding-left5px width125px">
                                            <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                class="textNonDecoration color-black">
                                                <%# Eval("Team_B_Name") %></a>
                                        </td>
                                        <td class=" width60px">
                                            <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                   <tr class="item-sub-alternate lineheight">
                                        <td class="width70px">
                                            <%# AppEnv.ConvertTime(Eval("TimeDay").ToString()) %>/<%# AppEnv.ConvertTime(Eval("TimeMonth").ToString()) %>
                                            <%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>
                                        </td>
                                        <td class=" width125px text-align-right padding-right5px">
                                            <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                class="textNonDecoration color-black">
                                                <%# Eval("Team_A_Name") %></a>
                                        </td>
                                        <td class="width70px background-xam-dadada text-align-center">
                                            <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                class="textNonDecoration color-chitiet"><b>
                                                    <%# Eval("Fs_A") %>
                                                    -
                                                    <%# Eval("Fs_B") %></b> </a>
                                        </td>
                                        <td class=" padding-left5px width125px">
                                            <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                class="textNonDecoration color-black">
                                                <%# Eval("Team_B_Name") %></a>
                                        </td>
                                        <td class=" width60px">
                                            <a style="display: block" href="<%# UrlProcess.NavigateUrlViewLow(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <div class="clear2px">
                </div>
            </div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc2:TopLeague ID="TopLeague1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DuLieu.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.DuLieu" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
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
                        <a href="javascript:void(0)">Dữ liệu</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                    <uc2:DrogBox ID="DrogBox1" runat="server" />
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="dulieu-header">
                        <div class="color-white floatleft width80px lineheight25">
                            <b class="padding-left10px">Thời gian</b></div>
                        <div class="separator25px-ffffff">
                        </div>
                        <div class="color-white width50percent height25px text-align-center">
                            <div class="height25px lineheight25">
                                <b>Trận</b></div>
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlHotMatch" Visible="false">
                    
                    <%--Begin Tran Cau Tam Diem--%>
                    <table class="table item" cellpadding="0">
                        <tr class="item-header">
                                    <td colspan="5">
                                        <img alt="" class="padding-top2px" src="/layout/images/icon-bong.png"/>
                                        <a class="textNonDecoration color-white bold" href="#">
                                            Trận cầu tâm điểm trong ngày
                                        </a>
                                    </td>
                                    <asp:Repeater ID="rptHotMatch" runat="server" EnableViewState="false">
                                        <ItemTemplate>
                                            <tr class="item-sub lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width90px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrl(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlView(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px">
                                                        <%# UrlProcess.GetLinkName(Eval("Status").ToString(),Eval("RateAsia").ToString()) %>
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="item-sub-alternate lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width90px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrl(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b>
                                                        <%# ConvertUtility.ToString(Eval("Fs_A"), Eval("StartTime"))%>
                                                        -
                                                        <%# ConvertUtility.ToString(Eval("Fs_B"), Eval("StartTime"))%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.NavigateUrlView(Eval("Status").ToString(),ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px">
                                                        <%# UrlProcess.GetLinkName(Eval("match_status").ToString(),Eval("RateAsia").ToString()) %>
                                                    </a>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </tr>
                    </table>
                    <%--End Tran Cau Tam Diem--%>

                    </asp:Panel>

                    <table class="table item" cellpadding="0">
                        <asp:Repeater ID="rptParent" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <tr class="item-header">
                                    <td colspan="5">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetTopBxhUrl(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Name") %>
                                            -
                                            <%--<%# Eval("Area_Name")%>--%>
                                        </a>
                                        <%--<img style="float: right" alt="" src="/layout/images/icon-plus.png" />--%>
                                    </td>
                                </tr>
                                <asp:Repeater ID="rptChild" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <tr class="background-xam-F4F4F4 lineheight">
                                            <td class="width70px">
                                                 <%# ConvertUtility.ToDateTime(Eval("match_day")).ToString("dd/MM") %>
                                                <%# Eval("match_time").ToString().Substring(0,5) %>
                                               <%-- <%# AppEnv.ConvertTime(Eval("TimeDay").ToString()) %>/<%# AppEnv.ConvertTime(Eval("TimeMonth").ToString()) %>
                                                <%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>--%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("home_id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("home_name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauUrlBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                                    class="textNonDecoration color-chitiet"><b>vs</b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("away_id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("away_name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTyLeBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">
                                                    <%--Xem--%>
                                                   <%--<%# Eval("RateAsia") %>--%>
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="lineheight">
                                            <td class="width70px">
                                                 <%# ConvertUtility.ToDateTime(Eval("match_day")).ToString("dd/MM") %>
                                                <%# Eval("match_time").ToString().Substring(0,5) %>
                                               <%-- <%# AppEnv.ConvertTime(Eval("TimeDay").ToString()) %>/<%# AppEnv.ConvertTime(Eval("TimeMonth").ToString()) %>
                                                <%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>--%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("home_id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("home_name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauUrlBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                                    class="textNonDecoration color-chitiet"><b>vs</b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("away_id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("away_name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTyLeBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">
                                                   <%--Xem--%>
                                                   <%--<%# Eval("RateAsia") %>--%>
                                                </a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
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

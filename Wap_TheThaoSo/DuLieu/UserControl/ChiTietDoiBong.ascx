<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietDoiBong.ascx.cs"
    Inherits="Wap_TheThaoSo.DuLieu.UserControl.ChiTietDoiBong" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="Pagging/MatchPagging.ascx" TagName="MatchPagging" TagPrefix="uc2" %>
<%@ Register Src="Pagging/NewsPagging.ascx" TagName="NewsPagging" TagPrefix="uc3" %>
<%@ Register Src="Pagging/VideoPagging.ascx" TagName="VideoPagging" TagPrefix="uc4" %>
<%@ Register Src="TopLeague.ascx" TagName="TopLeague" TagPrefix="uc5" %>
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
                        <a href="javascript:void(0)">Đội bóng</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="chitietdoibong">
                    <div class="clear10px">
                    </div>
                    <asp:Repeater ID="rptTeamInfo" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <div class="floatleft padding-left5px padding-right5px">
                                <%--<img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("avatar") %>.png" />--%>
                                <img alt="" width="90" height="90" src="<%# Eval("avatar") %>" />
                            </div>
                            
                            <div class="clearright5px">
                                </div>
                                <b >
                                    <%# Eval("Club_Name") %></b>
                                <div class="clearright5px">
                                </div>
                                Sân nhà:
                                <%# Eval("stadium_name") %>
                                <div class="clearright2px">
                                </div>
                                Địa chỉ:
                                <%# Eval("Address") %>
                                -
                                <%# Eval("stadium_city") %>
                           
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clear10px">
                    </div>
                    <div style="background-color: #FF6600; height: 1px; width: 100%; float: left; margin-top: 8px;">
                        <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                            padding-left: 5px;">Đội hình</b>
                    </div>
                    <div class="clear5px">
                    </div>
                    <div>
                        <div class="clear5px">
                        </div>
                        <div class="padding-left5px">
                            <b>Thủ môn:</b>
                        </div>
                        <div class="clear5px">
                        </div>
                        <asp:Repeater ID="rptGoalkeeper" runat="server">
                            <ItemTemplate>
                                <div class="width50percent floatleft">
                                    <div class="lineheight height22px padding-left15px">
                                        <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("team_id")),ConvertUtility.ToInt32(Eval("player_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("player_name") %></a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear5px">
                        </div>
                        <div class="padding-left5px">
                            <b>Hậu vệ:</b>
                        </div>
                        <div class="clear5px">
                        </div>
                        <asp:Repeater ID="rptDefender" runat="server">
                            <ItemTemplate>
                                <div class="width50percent floatleft">
                                    <div class="lineheight height22px padding-left15px">
                                        <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("team_id")),ConvertUtility.ToInt32(Eval("player_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("player_name") %></a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear5px">
                        </div>
                        <div class="padding-left5px">
                            <b>Tiền vệ:</b>
                        </div>
                        <div class="clear5px">
                        </div>
                        <asp:Repeater ID="rptMidfielder" runat="server">
                            <ItemTemplate>
                                <div class="width50percent floatleft">
                                    <div class="lineheight height22px padding-left15px">
                                        <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("team_id")),ConvertUtility.ToInt32(Eval("player_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("player_name") %></a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear5px">
                        </div>
                        <div class="padding-left5px">
                            <b>Tiền đạo:</b>
                        </div>
                        <div class="clear5px">
                        </div>
                        <asp:Repeater ID="rptAttacker" runat="server">
                            <ItemTemplate>
                                <div class="width50percent floatleft">
                                    <div class="lineheight height22px padding-left15px">
                                        <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("team_id")),ConvertUtility.ToInt32(Eval("player_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("player_name") %></a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="clear5px">
                    </div>
                    <div class="floatleft padding-left15px">
                        <b class="color-black">HLV:
                            <%= Coach %></b>
                    </div>
                    <div class="clear10px">
                    </div>
                    <div style="background-color: #FF6600; height: 1px; width: 100%; float: left; margin-top: 8px;">
                        <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                            padding-left: 5px;">Các trận đấu</b>
                    </div>
                    <div class="clear10px">
                    </div>
                    <table class="table">
                        <asp:Repeater ID="rptLastestMatch" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <tr class="background-xam-F4F4F4 lineheight">
                                    <td class="width70px">
                                        <%--<%# Eval("TimeVn") %>--%>
                                        <%# ConvertUtility.ToDateTime(Eval("match_time")).ToString("dd/MM") %>
                                    </td>
                                    <td class=" width125px text-align-right padding-right5px">
                                        <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("home_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("home_name") %></a>
                                    </td>
                                    <td class="width70px background-xam-dadada text-align-center">
                                        <%--<a href="<%# UrlProcess.GetChiTietTranDauKetThucUrlBonus(ConvertUtility.ToInt32(Eval("Id"))) %>"
                                            class="textNonDecoration color-chitiet"><b>
                                                <%# Eval("Fs_A") %>
                                                -
                                                <%# Eval("Fs_B") %></b></a>--%>
                                         <a href="<%# UrlProcess.GetChiTietTranDauKetThucUrlBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                            class="textNonDecoration color-chitiet"><b>
                                                <%# Eval("home_score") %>
                                                -
                                                <%# Eval("away_score") %></b></a>
                                    </td>
                                    <td class=" padding-left5px width125px">
                                        <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("away_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("away_name") %></a>
                                    </td>
                                    <td class=" width60px">
                                        <a href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                            class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="lineheight">
                                    <td class="width70px">
                                        <%--<%# Eval("TimeVn") %>--%>
                                        <%# ConvertUtility.ToDateTime(Eval("match_time")).ToString("dd/MM") %>
                                    </td>
                                    <td class="width125px text-align-right padding-right5px">
                                        <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("home_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("home_name") %></a>
                                    </td>
                                    <td class="width70px background-xam-dadada text-align-center">
                                        <a href="<%# UrlProcess.GetChiTietTranDauKetThucUrlBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                            class="textNonDecoration color-chitiet"><b>
                                                <%# Eval("home_score") %>
                                                -
                                                <%# Eval("away_score") %></b></a>
                                    </td>
                                    <td class=" padding-left5px width125px">
                                        <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("away_id"))) %>"
                                            class="textNonDecoration color-black">
                                            <%# Eval("away_name") %></a>
                                    </td>
                                    <td class=" width60px">
                                        <a href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("match_id"))) %>"
                                            class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="clear10px">
                    </div>
                    <uc2:MatchPagging ID="MatchPagging1" runat="server" />
                    <div class="clear5px">
                    </div>
                    <div class="clear10px">
                    </div>
                    <div id="divNews" runat="server" visible="false">
                        <div class="clear5px">
                        </div>
                        <div style="background-color: #FF6600; height: 1px; width: 100%; float: left; margin-top: 8px;">
                            <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                                padding-left: 5px;">Tin tức đội bóng</b>
                        </div>
                        <div class="clear5px">
                        </div>
                        <div class="other-news">
                            <div class="clear5px">
                            </div>
                            <ul>
                                <asp:Repeater ID="rptNews" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li><a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("categoryId")),ConvertUtility.ToInt32(Eval("id")))  %>">
                                            <%# Eval("title") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="clear10px">
                            </div>
                            <uc3:NewsPagging ID="NewsPagging1" runat="server" />
                            <div class="clear5px">
                            </div>
                        </div>
                        <div class="clear10px">
                        </div>
                    </div>
                    <div id="divVideos" runat="server" visible="false">
                        <div class="clear5px">
                        </div>
                        <div style="background-color: #FF6600; height: 1px; width: 100%; float: left; margin-top: 8px;">
                            <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                                padding-left: 5px;">Video đội bóng</b>
                        </div>
                        <div class="clear10px">
                        </div>
                        <div class="other-video">
                            <div class="clear5px">
                            </div>
                            <ul>
                                <asp:Repeater ID="rptlastestVideo" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li><a href="<%# UrlProcess.GetVideoDetailUrl(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Title") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="clear10px">
                            </div>
                            <uc4:VideoPagging ID="VideoPagging1" runat="server" />
                            <div class="clear5px">
                            </div>
                        </div>
                        <div class="clear10px">
                        </div>
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
    <uc5:TopLeague ID="TopLeague" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

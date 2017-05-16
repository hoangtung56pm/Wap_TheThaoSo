<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBxh.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.TopBxh" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
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
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="background-white">
                        <div class="floatleft text-align-center width30percent height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= CalendarLink %>">Lịch thi đấu</a>
                        </div>
                        <div class="background-xam floatleft height18px lineheight width20percent text-align-center">
                            <a style="display:block" class="color-white" href="<%= BxhLink %>">BXH</a>
                        </div>
                        <div class="floatleft text-align-center width30percent height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= TopGhiBanLink %>">Top ghi bàn</a>
                        </div>
                    </div>
                    <div class="clear1px">
                    </div>
                    <div class="item">
                        <asp:Repeater ID="rptInfo" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <div class="item-header">
                                    <div class="floatleft padding-left5px">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("area_name").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="javascript:void(0)">
                                            <%# Eval("group_name") %>
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
                        <table class="table ">
                            <tr class="background-xam color-white height18px lineheight">
                                <td class="width30px">
                                     <b>STT</b>
                                </td>
                                <td class="width125px">
                                    <b class=" padding-left5px">Đội bóng</b>
                                </td>
                                <td class="width30px text-align-center">
                                    <b>Tr</b>
                                </td>
                                <td class="width30px text-align-center">
                                    <b>T</b>
                                </td>
                                <td class="width30px text-align-center">
                                    <b>H</b>
                                </td>
                                <td class="width30px text-align-center">
                                    <b>B</b>
                                </td>
                                <td class="width50px text-align-center">
                                    <b>HS</b>
                                </td>
                                <td class="width60px text-align-center">
                                    <b>Điểm</b>
                                </td>
                            </tr>

                             <asp:Repeater ID="rptBxh" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <tr class="item-sub">
                                        <td class="lineheight18  width30px">
                                            <%# Eval("position") %>
                                        </td>
                                        <td class="width125px">
                                            <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("club_id"))) %>"
                                                class="textNonDecoration color-black padding-left5px">
                                                <%# Eval("club_name")%>
                                            </a>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("match")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("win")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("drawn")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("lost")%>
                                        </td>
                                        <td class="width50px text-align-center">
                                            <%--<%# Eval("Goals_Pro")%>-<%# Eval("Goals_Against")%>--%>
                                            <%# Eval("hieuso")%>
                                        </td>
                                        <td class="width60px text-align-center">
                                            <%# Eval("point") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="item-sub-alternate">
                                        <td class="lineheight18  width30px">
                                            <%# Eval("position") %>
                                        </td>
                                        <td class="width125px">
                                            <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("club_id"))) %>"
                                                class="textNonDecoration color-black padding-left5px">
                                                <%# Eval("Club_Name")%>
                                            </a>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("match")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("win")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("drawn")%>
                                        </td>
                                        <td class="width30px text-align-center">
                                            <%# Eval("lost")%>
                                        </td>
                                        <td class="width50px text-align-center">
                                            <%# Eval("hieuso")%>
                                        </td>
                                        <td class="width60px text-align-center">
                                            <%# Eval("point") %>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>

                        </table>
                        <div class="clear0px">
                        </div>
                       <%-- <table class="table">
                           
                        </table>--%>
                        <div class="clear0px">
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
    <uc2:TopLeague ID="TopLeague1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

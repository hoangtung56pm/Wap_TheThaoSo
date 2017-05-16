<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopGhiBan.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.TopGhiBan" %>

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
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="background-white">
                        <div class="floatleft text-align-center width30percent height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= CalendarLink %>">Lịch thi đấu</a>
                        </div>
                        <div class="floatleft  width20percent text-align-center height18px lineheight">
                            <a style="display:block" class="color-xam" href="<%= BxhLink %>">BXH</a>
                        </div>
                        <div class="background-xam floatleft height18px lineheight width30percent text-align-center">
                            <a style="display:block" class="color-white" href="<%= TopGhiBanLink %>">Top ghi bàn</a>
                        </div>
                    </div>
                    <div class="clear1px">
                    </div>
                    <div class="item">
                        <asp:Repeater ID="rptInfo" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <div class="item-header">
                                    <div class="floatleft padding-left5px">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="#">
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

                        <table class="table"  cellpadding="5" cellspacing="1">
                                    <tr class="background-xam height18px lineheight">
                                        <td class="color-white padding-left5px width50px">
                                            STT
                                        </td>
                                        <td class="color-white width125px">
                                            Cầu thủ
                                        </td>
                                        <td class="color-white  width125px">
                                            CLB
                                        </td>
                                        <td class="color-white padding-left5px">
                                            Bàn thắng
                                        </td>
                                    </tr>
                                </table>

                        <table class="table" cellpadding="5" cellspacing="1">
                            <asp:Repeater ID="rptTopGoals" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <tr class="item-sub">
                                        <td class="floatleft lineheight18 padding-left5px width50px">
                                            <%# Eval("RowNumber") %>
                                        </td>
                                        <td class="width125px">
                                            <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>"
                                                class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                <%# Eval("Name") %>
                                            </a>
                                        </td>
                                        <td class="width125px">
                                            <%# Eval("Team_Name")%>
                                        </td>
                                        <td class="padding-left5px ">
                                            <%# Eval("Goals") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="item-sub-alternate">
                                        <td class="lineheight18 padding-left5px width50px">
                                            <%# Eval("RowNumber") %>
                                        </td>
                                        <td class="width125px">
                                            <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>"
                                                class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                <%# Eval("Name") %>
                                            </a>
                                        </td>
                                        <td class="width125px">
                                            <%# Eval("Team_Name")%>
                                        </td>
                                        <td class="padding-left5px">
                                            <%# Eval("Goals") %>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="clear1px">
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
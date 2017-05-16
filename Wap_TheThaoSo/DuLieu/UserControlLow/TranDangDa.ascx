<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TranDangDa.ascx.cs"Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.TranDangDa" %>
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
                        <a href="javascript:void(0)">Dữ liệu</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                    <uc2:DrogBox ID="DrogBox1" runat="server" />
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
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
                                                <td class="width70px">
                                                    <%# Eval("TimeNow")%>
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width70px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatLowBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
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
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatLowBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="item-sub-alternate lineheight">
                                                <td class="width70px">
                                                    <%# Eval("TimeNow")%>
                                                    <asp:Literal ID="litIconXanh" runat="server"></asp:Literal>
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width70px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatLowBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
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
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatLowBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div id="divThongBao" runat="server" visible="false" align="center">
                        <b>
                            <h3>
                                Hiện không có trận nào đang thi đấu</h3>
                        </b>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear0px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc3:TopLeague ID="TopLeague" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

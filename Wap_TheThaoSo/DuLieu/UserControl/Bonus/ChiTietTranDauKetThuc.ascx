<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDauKetThuc.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.Bonus.ChiTietTranDauKetThuc" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register src="../TopLeague.ascx" tagname="TopLeague" tagprefix="uc3" %>
<%@ Register src="../../../Wap/UserControl/GiaiTri.ascx" tagname="GiaiTri" tagprefix="uc1" %>
<%@ Register Src="../DropBox.ascx" TagName="DrogBox" TagPrefix="uc2" %>



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
                        <a href="javascript:void(0)">Dữ Liệu</a></div>
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
                    <div class="clear5px"></div>
                    <table class="table item" cellpadding="0">
                        <asp:Repeater ID="rptParent" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <tr class="item-header">
                                    <td colspan="5">
                                        <a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("Area_Name").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetTopBxhUrl(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("CompetitionName")%>
                                            -
                                            <%# Eval("Area_Name")%>
                                        </a>
                                        <%--<img style="float: right" alt="" src="/layout/images/icon-plus.png" />--%>
                                    </td>
                                    <asp:Repeater ID="rptChild" runat="server" EnableViewState="false">
                                        <ItemTemplate>
                                            <tr class="item-sub lineheight">
                                                <td class="datetime font11px width70px text-align-center">
                                                    <%--<asp:Literal ID="litIconXanh" runat="server"></asp:Literal>--%>
                                                    FT
                                                </td>
                                                <td class=" width125px text-align-right padding-right5px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_A_Name") %></a>
                                                </td>
                                                <td class="width90px background-xam-dadada text-align-center">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet">
                                                        <b><%# Eval("Fs_A")%>
                                                        -
                                                        <%# Eval("Fs_B")%>
                                                        </b>
                                                    </a>
                                                </td>
                                                <td class=" padding-left5px width125px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                        class="textNonDecoration color-black">
                                                        <%# Eval("Team_B_Name") %></a>
                                                </td>
                                                <td class=" width60px">
                                                    <a style="display: block" href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                        class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                     <div class="clear1px"></div>

                     <!--DoiHinh-->
                        <div>
                            
                            <div class="width50percent border-right-d3d3d3 floatleft">
                                <div class="clear10px">
                                </div>
                                <b class="bold color-red  padding-left15px">
                                    <%= TeamA %></b>
                                <div class="clear5px">
                                </div>
                                <%--<b class="bold  padding-left15px">Chính thức</b>
                                <div class="clear5px">
                                </div>--%>
                                <asp:Repeater ID="rptL1" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <div class="background-xam-F4F4F4 lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <div class="lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                                <div class="clear5px">
                                </div>
                                <div class="floatleft padding-left15px">
                                    <b class="color-black">HLV : <%= CoachA %></b>
                                </div>
                                <div class="clear10px">
                                </div>
                            </div>

                            <div class="width50percent floatleft">
                                <div class="clear10px">
                                </div>
                                <b class="bold color-red  padding-left15px">
                                    <%= TeamB %></b>
                                <div class="clear5px">
                                </div>
                                <%--<b class="bold  padding-left15px">Chính thức</b>
                                <div class="clear5px">
                                </div>--%>
                                <asp:Repeater ID="rptL2" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <div class="background-xam-F4F4F4 lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <div class="lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                                <div class="clear5px">
                                </div>
                                <div class="floatleft padding-left15px">
                                    <b class="color-black">HLV : <%= CoachB %></b>
                                </div>
                                <div class="clear10px">
                                </div>
                            </div>
                            
                        </div>
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
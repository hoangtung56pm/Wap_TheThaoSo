<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDau.ascx.cs"Inherits="Wap_TheThaoSo.DuLieu.UserControl.ChiTietTranDau" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
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
                        <a href="javascript:void(0)">Đội bóng</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="chitietdoibong">
                    <asp:Repeater runat="server" ID="rptTeamInfo" EnableViewState="false">
                        <ItemTemplate>
                            <div class="clear10px">
                            </div>
                            <div class="width10percent floatleft">
                                &nbsp;</div>
                            <div class="floatleft">
                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>">
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_A_ID") %>.png" />
                                </a>
                                <p align="center">
                                    <a class="bold color-black textNonDecoration" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>">
                                        <%# Eval("Team_A_Code") %>
                                    </a>
                                </p>
                            </div>
                            <div class="width30px floatleft">
                                &nbsp;</div>
                            <div class="floatleft lineheight90 bold padding-right5px font20px">
                                <%# Eval("Fs_A") %></div>
                            <div class="floatleft lineheight90 bold font20px">
                                -</div>
                            <div class="floatleft lineheight90 bold padding-left5px font20px">
                                <%# Eval("Fs_B") %></div>
                            <div class="width30px floatleft">
                                &nbsp;</div>
                            <div class="floatleft">
                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_ID"))) %>">
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_B_ID") %>.png" />
                                </a>
                                <p align="center">
                                    <a class="bold color-black textNonDecoration" href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_ID"))) %>">
                                        <%# Eval("Team_B_Code") %>
                                    </a>
                                </p>
                            </div>
                            <div class="clear10px">
                            </div>
                            <div class="bgred">
                                <div class="clear5px">
                                </div>
                                <b class="bold color-white">Giải đấu:</b>&nbsp;<%# !string.IsNullOrEmpty(Eval("CompetitionName").ToString()) ? Eval("CompetitionName") : Eval("Eng_CompetitionName") %>
                                <div class="clear2px">
                                </div>
                                <b class="bold color-white">Ngày:</b>&nbsp;<%# Eval("StartTime") %>
                                <div class="clear2px">
                                </div>
                                <b class="bold color-white">Giờ đá:</b>&nbsp;<%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>
                                <div class="clear2px">
                                </div>
                                <b class="bold color-white">SVĐ:</b>&nbsp;<%# Eval("Stadium") %>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clear10px">
                    </div>
                    <div class="phongdo">
                        <asp:Repeater ID="rptInfoLink" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <div class="floatleft width25percent text-align-center ">
                                    <a href="#" class="color-white padding-left5px padding-right5px lineheight">Phong độ</a>
                                </div>
                                <div class="floatleft height19px background-xam-b8b8b8 width25percent text-align-center margin-left3px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauDoiHinhUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 lineheight padding-left5px padding-right5px">Đội hình</a>
                                </div>
                                <div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                    &nbsp;
                                </div>
                                <div class="floatleft height19px background-xam-b8b8b8 width28percent text-align-center margin-left0px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTuongThuat(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 lineheight padding-left5px padding-right5px">Tường thuật</a>
                                </div>
                                <div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                    &nbsp;
                                </div>
                                <div class="floatleft height19px width20percent text-align-center background-xam-b8b8b8">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTyLe(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px lineheight padding-right5px">Tỷ lệ</a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear10px">
                        </div>
                        <div class="floatleft width100percent">
                            <table class="table">
                                <tr >
                                    <td colspan="5">
                                        <b class="bold color-red padding-left15px">
                                            <%= TeamA %></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;"  colspan="5">
                                    </td>
                                </tr>
                                <asp:Repeater ID="rptTeamA" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <tr class="background-xam-F4F4F4 lineheight">
                                            <td class="width70px datetime text-align-center">
                                                <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("dd/MM") + ' ' %>  <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("yyyy")%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_A_Name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-black"><b>
                                                        <%# Eval("Fs_A") %>
                                                        -
                                                        <%# Eval("Fs_B") %></b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_B_Name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="lineheight">
                                            <td class="width70px datetime text-align-center">
                                                 <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("dd/MM") + ' ' %>  <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("yyyy")%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_A_Name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-black"><b>
                                                        <%# Eval("Fs_A") %>
                                                        -
                                                        <%# Eval("Fs_B") %></b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_B_Name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td style="height: 10px;"  colspan="5">
                                    </td>
                                </tr>
                                <tr >
                                    <td colspan="5">
                                        <b class="bold color-red padding-left15px">
                                            <%= TeamB %></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;"  colspan="5">
                                    </td>
                                </tr>
                                <asp:Repeater ID="rptTeamB" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <tr class="background-xam-F4F4F4 lineheight">
                                            <td class="width70px datetime text-align-center">
                                                <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("dd/MM") + ' ' %>  <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("yyyy")%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_A_Name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-black"><b>
                                                        <%# Eval("Fs_A") %>
                                                        -
                                                        <%# Eval("Fs_B") %></b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_B_Name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="lineheight">
                                            <td class="width70px datetime text-align-center">
                                                <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("dd/MM") + ' ' %>  <%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("yyyy")%>
                                            </td>
                                            <td class=" width125px text-align-right padding-right5px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_A_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_A_Name") %></a>
                                            </td>
                                            <td class="width90px background-xam-dadada text-align-center">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-black"><b>
                                                        <%# Eval("Fs_A") %>
                                                        -
                                                        <%# Eval("Fs_B") %></b></a>
                                            </td>
                                            <td class=" padding-left5px width125px">
                                                <a href="<%# UrlProcess.GetChiTietDoiBongUrl(ConvertUtility.ToInt32(Eval("Team_B_Id"))) %>"
                                                    class="textNonDecoration color-black">
                                                    <%# Eval("Team_B_Name") %></a>
                                            </td>
                                            <td class=" width60px">
                                                <a href="<%# UrlProcess.GetChiTietTranDauUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                                    class="textNonDecoration color-chitiet text-align-center font11px">Xem</a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </table>
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
    <div class="clear0px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <div class="clear0px">
    </div>
    <uc2:TopLeague ID="TopLeague1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

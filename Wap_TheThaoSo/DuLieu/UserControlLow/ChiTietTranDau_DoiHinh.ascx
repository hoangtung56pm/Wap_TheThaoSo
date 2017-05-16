﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDau_DoiHinh.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.ChiTietTranDau_DoiHinh" %>

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
                                <a href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>">
                                    <img alt="" width="60" height="60" src="/layout/TeamLogos/<%# Eval("Team_A_ID") %>.png" />
                                </a>
                                <p align="center">
                                    <a class="bold color-black textNonDecoration" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_A_ID"))) %>">
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
                                <a href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_ID"))) %>">
                                    <img alt="" width="60" height="60" src="/layout/TeamLogos/<%# Eval("Team_B_ID") %>.png" />
                                </a>
                                <p align="center">
                                    <a class="bold color-black textNonDecoration" href="<%# UrlProcess.GetChiTietDoiBongLowUrl(ConvertUtility.ToInt32(Eval("Team_B_ID"))) %>">
                                        <%# Eval("Team_B_Code") %>
                                    </a>
                                </p>
                            </div>
                            <div class="clear10px">
                            </div>
                            <div class="bgred">
                                <div class="clear5px">
                                </div>
                                <b class="bold color-white">Giải đấu:</b>&nbsp;<%# !string.IsNullOrEmpty(Eval("CompetitionName").ToString()) ? Eval("CompetitionName") : Eval("Eng_CompetitionName")%>
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
                                <div class="floatleft width25percent text-align-center background-xam-b8b8b8 height19px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauLowUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px padding-right5px lineheight">Phong độ</a></div>
                                <div class="floatleft width25percent text-align-center margin-left3px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauDoiHinhLowUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-white lineheight padding-left5px padding-right5px">Đội hình</a>
                                </div>
                                <div class="floatleft width28percent text-align-center height19px background-xam-b8b8b8">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTuongThuatLow(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px lineheight padding-right5px">Tường thuật</a></div>

                                <div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                    &nbsp;
                                </div>

                                <div class="floatleft width20percent text-align-center height19px background-xam-b8b8b8">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTyLeLow(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px lineheight padding-right5px">Tỷ lệ</a>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear1px">
                        </div>
                        <!--DoiHinh-->
                        <div>
                            <div class="width50percent border-right-d3d3d3 floatleft">
                                <div class="clear10px">
                                </div>
                                <b class="bold color-red  padding-left15px">
                                    <%= TeamA %></b>
                                <div class="clear5px">
                                </div>
                                <b class="bold  padding-left15px">Chính thức</b>
                                <div class="clear5px">
                                </div>
                                <asp:Repeater ID="rptL1" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <div class="background-xam-F4F4F4 lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
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
                                <b class="bold padding-left15px">Dự bị</b>
                                <div class="clear5px">
                                </div>
                                <asp:Repeater ID="rptSub1" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                         <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_A_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %></a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>
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
                                <b class="bold  padding-left15px">Chính thức</b>
                                <div class="clear5px">
                                </div>
                                <asp:Repeater ID="rptL2" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <div class="background-xam-F4F4F4 lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
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
                                <b class="bold padding-left15px">Dự bị</b>
                                <div class="clear5px">
                                </div>
                                <asp:Repeater ID="rptSub2" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuLowUrl(ConvertUtility.ToInt32(Eval("Team_B_Id")),ConvertUtility.ToInt32(Eval("Person_Id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("Person") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>


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
    </div>
    <div class="clear0px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    
    <uc2:TopLeague ID="TopLeague1" runat="server" />

    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>
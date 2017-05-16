<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDau_DoiHinh.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.Bonus.ChiTietTranDau_DoiHinh" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register src="../TopLeague.ascx" tagname="TopLeague" tagprefix="uc2" %>
<%@ Register src="../../../Wap/UserControl/GiaiTri.ascx" tagname="GiaiTri" tagprefix="uc1" %>

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
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_A_ID_ori") %>.png" />
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
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_B_ID_ori") %>.png" />
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
                                <b class="bold color-white">Giải đấu:</b>&nbsp;<%# !string.IsNullOrEmpty(Eval("CompetitionName").ToString()) ? Eval("CompetitionName") : Eval("CompetitionName")%>
                                <div class="clear2px">
                                </div>
                                <b class="bold color-white">Ngày:</b>&nbsp;<%# Eval("match_time") %>
                                <div class="clear2px">
                                </div>
                                <b class="bold color-white">Giờ đá:</b>&nbsp;<%# Eval("match_day") %><%--<%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %>--%>
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
                                
                                <div class="floatleft width50percent text-align-center background-xam-b8b8b8 ">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>" class="color-xam737373 padding-left5px lineheight padding-right5px">Tường thuật</a></div>

                                <div class="floatleft width50percent text-align-center height19px ">
                                    <a href="#"
                                        class="color-white padding-left5px lineheight padding-right5px">Đội hình</a>
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <div class="lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                         <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %></a>
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <div class="lineheight height25px padding-left15px">
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
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
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
                                                </a>
                                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                                <asp:Literal ID="litThay" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <asp:Literal ID="litStartDiv" runat="server"></asp:Literal>
                                            <div class="width100percent floatleft">
                                                <a href="<%# UrlProcess.GetChiTietCauThuUrl(ConvertUtility.ToInt32(Eval("Team_Id")),ConvertUtility.ToInt32(Eval("player_id"))) %>" class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("National").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-black">
                                                    <%# Eval("ShirtNumber") %>
                                                    <%# Eval("matchName") %>
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
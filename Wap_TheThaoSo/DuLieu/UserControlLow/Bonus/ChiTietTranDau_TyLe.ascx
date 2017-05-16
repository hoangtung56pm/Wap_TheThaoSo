<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDau_TyLe.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.Bonus.ChiTietTranDau_TyLe" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register src="../TopLeague.ascx" tagname="TopLeague" tagprefix="uc2" %>
<%@ Register src="../../../Wap/UserControlLow/GiaiTri.ascx" tagname="GiaiTri" tagprefix="uc1" %>

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
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_A_ID") %>.png" />
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
                                    <img alt="" width="90" height="90" src="/layout/TeamLogos/<%# Eval("Team_B_ID") %>.png" />
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
                                <div class="floatleft background-xam-b8b8b8 text-align-center width50percent height19px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauLowUrlBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px padding-right5px lineheight">Phong độ</a></div>
                                <%--<div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                    &nbsp;</div>
                                <div class="floatleft width25percent  text-align-center background-xam-b8b8b8 height19px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauDoiHinhUrl(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 lineheight padding-left5px padding-right5px">Đội hình</a>
                                </div>
                                <div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                    &nbsp;</div>
                                <div class="floatleft width28percent  text-align-center  background-xam-b8b8b8 height19px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauTuongThuat(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px lineheight padding-right5px">Tường thuật</a></div>--%>
                                <div class="floatleft width50percent text-align-center ">
                                    <a href="#" class="color-white padding-left5px lineheight padding-right5px">Tỷ lệ</a></div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <asp:Panel ID="pnlTyLe" runat="server" Visible="false">

                        <div class="clear2px">
                        </div>
                        <div>
                            <div class="floatleft bold background-b10228 width50percent color-white height25px lineheight25 text-align-center">
                                Tỷ lệ Châu Á</div>
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <div style="width: 49.8%" class="bold color-white background-b10228 height25px floatleft lineheight25 text-align-center">
                                Tổng số bàn thắng</div>
                        </div>
                        <div class="clear1px">
                        </div>
                        <div class="width50percent floatleft">
                            <div class="width33percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Chủ</div>
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <div class="width33percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Tỷ lệ</div>
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <div class="width34percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Khách</div>
                        </div>
                        <div class="width50percent floatleft">
                            <div class="separator25px-ffffff floatleft">
                                &nbsp;</div>
                            <div class="width33percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Tài</div>
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <div class="width33percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Tỷ lệ</div>
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <div class="width33percent floatleft background-0f5995 height25px lineheight25 color-white text-align-center">
                                Xỉu</div>
                        </div>
                        <div class="clear0px">
                        </div>
                        <div class="width50percent floatleft">
                            <asp:Repeater ID="rptTyle" EnableViewState="false" runat="server">
                                <ItemTemplate>
                                    <div class="width33percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("Home") %>
                                    </div>
                                    <div class="separator25px-ffffff">
                                        &nbsp;</div>
                                    <div class="width33percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("RateAsia") %></div>
                                    <div class="separator25px-ffffff">
                                        &nbsp;</div>
                                    <div class="width34percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("Away") %></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="width50percent floatleft">
                            <div class="separator25px-ffffff">
                                &nbsp;</div>
                            <asp:Repeater ID="rptTaixiu" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <div class="width33percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("Over") %>
                                    </div>
                                    <div class="separator25px-ffffff">
                                        &nbsp;</div>
                                    <div class="width33percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("Total") %>
                                    </div>
                                    <div class="separator25px-ffffff">
                                        &nbsp;</div>
                                    <div class="width33percent floatleft background-d7d7d7 height25px lineheight25 color-black text-align-center">
                                        <%# Eval("Under") %></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="clear0px"></div>

                        <asp:Repeater ID="rptUpdateDate" runat="server">
                            <ItemTemplate>
                                 <div class="width100percent floatleft text-align-center">
                                    <p>Tỷ lệ cập nhật lúc : <%# AppEnv.ConvertTime(Eval("TimeHour").ToString()) %>:<%# AppEnv.ConvertTime(Eval("TimeMinute").ToString()) %> (<%# Eval("UpdateDate") %>)</p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                       </asp:Panel>

                        <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
                             <div class="width100percent floatleft text-align-left">
                            <p>
                                <asp:Literal ID="ltrThongBao" runat="server"></asp:Literal></p>
                        </div>
                        </asp:Panel>

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
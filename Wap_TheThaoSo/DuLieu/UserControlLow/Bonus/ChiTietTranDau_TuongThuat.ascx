<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietTranDau_TuongThuat.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.Bonus.ChiTietTranDau_TuongThuat" %>

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
                            <div class="floatleft ">
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
                        <asp:Repeater ID="rptInfoLink" runat="server" EnableViewState="true">
                            <ItemTemplate>
                                
                                <asp:Panel ID="pnlNonVideo" runat="server" Visible="false">

                                <div class="floatleft width50percent text-align-center ">
                                    <a href="#" class="color-white padding-left5px lineheight padding-right5px">Tường thuật</a></div>
                               

                                <div class="floatleft width50percent text-align-center height19px background-xam-b8b8b8">
                                    <a href="<%# UrlProcess.GetChiTietTranDauDoiHinhLowUrlBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 padding-left5px lineheight padding-right5px">Đội hình</a>
                                </div>

                                </asp:Panel>

                                <asp:Panel ID="pnlVideo" runat="server" Visible="false">

                                    <div class="floatleft width33percent text-align-center">
                                        <a href="<%# UrlProcess.GetChiTietTranDauTuongThuatBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>" class="color-white padding-left5px padding-right5px lineheight">Tường thuật</a>
                                    </div>

                                    <div class="floatleft background-xam-b8b8b8 height19px width33percent text-align-center margin-left3px">
                                    <a href="<%# UrlProcess.GetChiTietTranDauDoiHinhUrlBonus(ConvertUtility.ToInt32(Eval("MatchId"))) %>"
                                        class="color-xam737373 lineheight padding-left5px padding-right5px">Đội hình</a>
                                    </div>

                                    <div style="background-color: #737373; float: left; width: 1px; height: 20px;">
                                        &nbsp;
                                    </div>

                                    <div class="floatleft height19px background-xam-b8b8b8 width32percent text-align-center margin-left0px">
                                        <asp:LinkButton ID="lnkVideo" OnClick="lnkVideo_Click" runat="server" CssClass="color-xam737373 lineheight padding-left5px padding-right5px">Video</asp:LinkButton>
                                    </div>

                               </asp:Panel>

                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clear0px">
                        </div>

                        <asp:Panel ID="pnlTuongThuat" runat="server" Visible="false">
                            <!--TuongThuat-->
                            <div class="floatleft width100percent">
                            <asp:Repeater ID="rptCommentary" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <div class="item font12px">
                                        <div class="width50px floatleft padding-left5px lineheight">
                                            <%# Eval("Time") %>'<asp:Literal runat="server" EnableViewState="false" ID="litExtraTime"></asp:Literal>
                                            <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="floatleft width80percent lineheight">
                                            <%# AppEnv.Translate(Eval("Code").ToString(),Eval("Content").ToString()) %></div>
                                    </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div class="item-alternate font12px">
                                        <div class="width50px floatleft padding-left5px lineheight">
                                            <%# Eval("Time") %>'<asp:Literal runat="server" EnableViewState="false" ID="litExtraTime"></asp:Literal>
                                            <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="floatleft width80percent">
                                            <%# AppEnv.Translate(Eval("Code").ToString(),Eval("Content").ToString()) %></div>
                                    </div>
                                </AlternatingItemTemplate>
                            </asp:Repeater>

                            <div id="divThongBao" runat="server" visible="false" align="center">
                                    <h3>
                                        <b>Trận đấu này chưa diễn ra</b>
                                    </h3>
                            </div>

                        </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
                             <div class="width100percent floatleft text-align-left">
                                <p>
                                    <asp:Literal ID="ltrThongBao" runat="server"></asp:Literal>
                                </p>
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
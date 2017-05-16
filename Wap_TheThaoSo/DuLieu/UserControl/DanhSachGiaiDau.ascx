<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachGiaiDau.ascx.cs"Inherits="Wap_TheThaoSo.DuLieu.UserControl.DanhSachGiaiDau" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
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
                        <a href="javascript:void(0)">Danh sách giải đấu</a>
                    </div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="item">
                        <div class="item-header">
                            <div class="floatleft padding-left5px">
                                <a class="textNonDecoration color-white bold" href="javascript:void(0)">Vô địch quốc
                                    gia và cúp Quốc gia </a>
                            </div>
                            <div class="floatright margin-top3px padding-right5px">
                                <a class="textNonDecoration color-white bold" href="<%= QuocGiaLink %>">Xem tất cả
                                    <img alt="" src="/layout/images/icon-plus.png" />
                                </a>
                            </div>
                        </div>
                        <div id="othercategory-dulieu">
                            <ul>
                                <asp:Repeater ID="rptVoDichQuocGiavaCup" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li><a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("AreaName").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetLichThiDau(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Name") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="clear0px">
                    </div>
                    <div class="item">
                        <div class="item-header">
                            <div class="floatleft padding-left5px">
                                <a class="textNonDecoration color-white bold" href="javascript:void(0)">Châu lục </a>
                            </div>
                            <div class="floatright margin-top3px padding-right5px">
                                <a class="textNonDecoration color-white bold" href="<%= ChauLucLink %>">Xem tất cả
                                    <img alt="" src="/layout/images/icon-plus.png" />
                                </a>
                            </div>
                        </div>
                        <div id="othercategory-dulieu">
                            <ul>
                                <asp:Repeater ID="rptChauLuc" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li><a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("AreaName").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetLichThiDau(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Name") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="clear0px">
                    </div>
                    <div class="item">
                        <div class="item-header">
                            <div class="floatleft padding-left5px">
                                <a class="textNonDecoration color-white bold" href="javascript:void(0)">Thê giới </a>
                            </div>
                            <div class="floatright margin-top3px padding-right5px">
                                <a class="textNonDecoration color-white bold" href="<%= TheGioiLink %>">Xem tất cả
                                    <img alt="" src="/layout/images/icon-plus.png" />
                                </a>
                            </div>
                        </div>
                        <div id="othercategory-dulieu">
                            <ul>
                                <asp:Repeater ID="rptTheGioi" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li><a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("AreaName").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                                            href="<%# UrlProcess.GetLichThiDau(ConvertUtility.ToInt32(Eval("Id"))) %>">
                                            <%# Eval("Name") %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear0px">
    </div>
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

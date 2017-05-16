<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachGiaiDau_ChiTiet.ascx.cs"
    Inherits="Wap_TheThaoSo.DuLieu.UserControl.DanhSachGiaiDau_ChiTiet" %>
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
                        <a href="<%= DsGiaiDauLink %>">Danh sách giải đấu</a>
                    </div>
                    <div class="red-separator margin-right2px">
                    </div>
                    <div class="floatright padding-right5px background-white">
                        <asp:DropDownList CssClass="combo" ID="dgrCategory" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="dgrCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="dulieu">
                    <div class="item">
                        <div class="item-header">
                            <div class="floatleft padding-left5px">
                                <a class="textNonDecoration color-white bold" href="javascript:void(0)">
                                    <asp:Label ID="lblName" EnableViewState="false" runat="server"></asp:Label>
                                </a>
                            </div>
                        </div>
                        <div id="othercategory-dulieu">
                            <ul>
                                <asp:Repeater ID="rptLeague" runat="server" EnableViewState="false">
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

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopLeague.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.TopLeague" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<div class="clear5px">
</div>
<div class="background-xam-e0e0e0 height22px lineheight22">
    <b class="padding-left5px">Danh sách giải đấu</b>
</div>
<div id="othercategory-dulieu">
    <ul>
        <asp:Repeater ID="rptTopLeague" runat="server" EnableViewState="false">
            <ItemTemplate>
                <li><a class="flag_16 <%# UnicodeUtility.UnicodeToKoDau(Eval("area_name").ToString().ToLower()).Replace(" ","-") %>_16_left padding-left20px textNonDecoration color-white bold"
                    href="<%# UrlProcess.GetLichThiDau(ConvertUtility.ToInt32(Eval("Id"))) %>">
                    <%# Eval("Title") %>
                </a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="clear5px">
    </div>
    <div class="floatright">
        <a href="<%= DsGiaiDauLink %>" class="textNonDecoration color-black padding-right5px font11px">
            Xem tiếp >> </a>
    </div>
</div>
<div class="clear0px">
</div>

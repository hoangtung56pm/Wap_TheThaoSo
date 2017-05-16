<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropBox.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.DropBox" %>
<div class="floatright padding-right5px background-white">
    <asp:DropDownList ID="dgrBox" runat="server" AutoPostBack="true" CssClass="combo"
        OnSelectedIndexChanged="dgrBox_SelectedIndexChanged">
        <asp:ListItem Value="0">Tất cả</asp:ListItem>
        <asp:ListItem Value="1">Trận sắp đá</asp:ListItem>
        <asp:ListItem Value="2">Trận đã đá</asp:ListItem>
        <asp:ListItem Value="3">Trận đang đá</asp:ListItem>
    </asp:DropDownList>
</div>

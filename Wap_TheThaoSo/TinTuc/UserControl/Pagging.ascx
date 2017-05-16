<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagging.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControl.Pagging" %>
<div class="pagging">
    <asp:Literal ID="ltrNoData" runat="server" EnableViewState="False" Visible="false">Dữ liệu của mục này hiện đang được cập nhật.</asp:Literal>

    <asp:HyperLink ID="lnkFirst" CssClass="bold" runat="server" EnableViewState="False">«</asp:HyperLink>
    <%--<asp:HyperLink ID="lnkFirst" CssClass="bold" runat="server" EnableViewState="False">Đầu trang</asp:HyperLink>--%>

    <asp:HyperLink ID="lnkPrev" CssClass="bold" runat="server" EnableViewState="False">&lt;</asp:HyperLink>
    <asp:Repeater ID="rptPage" runat="server" EnableViewState="False">
        <ItemTemplate>
            <asp:Label ID="ltrPage" CssClass="bold" runat="server" EnableViewState="False" />
            <asp:Literal ID="ltrGach" runat="server" EnableViewState="False">|</asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" CssClass="bold" runat="server" EnableViewState="False">&gt;</asp:HyperLink>

    <asp:HyperLink ID="lnkLast" CssClass="bold" runat="server" EnableViewState="False">»</asp:HyperLink>
    <%--<asp:HyperLink ID="lnkLast" CssClass="bold" runat="server" EnableViewState="False">Cuối trang</asp:HyperLink>--%>

</div>

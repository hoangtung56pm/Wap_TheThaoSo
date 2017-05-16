<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControl.Login" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="VideoPagging.ascx" TagName="VideoPagging" TagPrefix="uc3" %>
<%@ Register Src="BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc4" %>

<div id="content">
    <div class="home_content">
        <div class="clear5px"></div>
        
        <asp:Panel ID="pnlDangKyThanhCong" Visible="False" runat="server">
            <div align="center" style="border-style:solid; border-color:#ff6600">
                Bạn đã đăng ký thành công CTKM chuyên gia bóng đá của Vietnamobile. Vui lòng kiểm tra tin nhắn để lấy mật khẩu đăng nhập.
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlDangKyThatBai" Visible="False" runat="server">
            <div align="center" style="border-style:solid; border-color:#ff6600">
                Đăng ký không thành công hoặc thuê bao đã tồn tại !
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlWifi" Visible="False" runat="server">
            <div align="center" style="border-style:solid; border-color:#ff6600">
                Hệ thống không nhận diện được số điện thoại của bạn. Vui lòng sử dụng 3G.
            </div>
        </asp:Panel>
        
        <div align="center">
            <table>
                <tr>
                    <td>SĐT</td>
                    <td>
                        <asp:TextBox ID="txtMsisdn" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                
                <tr>
                    <td>Mật khẩu</td>
                    <td>
                        <asp:TextBox TextMode="Password" ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CssClass="btn-danger" ID="btnLogin" Text="Đăng nhập" runat="server" OnClick="btnLogin_Click"/>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblStatus" ForeColor="red" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtMsisdn" ErrorMessage="Chưa nhập SĐT !" runat="server"></asp:RequiredFieldValidator>
                        <br/>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ErrorMessage="Chưa nhập mật khẩu !" runat="server">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
            Vui lòng soạn MK gửi 979 để lấy mật khẩu
        </div>

    </div>
    <div class="clear5px"></div>
</div>


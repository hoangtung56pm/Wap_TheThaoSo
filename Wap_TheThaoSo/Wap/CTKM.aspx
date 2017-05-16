<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CTKM.aspx.cs" Inherits="Wap_TheThaoSo.CTKM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="grv_user" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" style="width: 60%; margin-left: 20%;">
            <Columns>
                <asp:BoundField DataField="Row" HeaderText="TT" />
                <asp:BoundField DataField="User_ID" HeaderText="SDT" />
                <asp:BoundField DataField="Total" HeaderText="Tong" />
            </Columns>
        </asp:GridView>
        <br />
        <div style="margin-left:20%">
            <asp:TextBox ID="txtuserid" runat="server" placeholder ="nhập số điện thoại ..."></asp:TextBox>
            <asp:Button ID="btnsearch" runat="server" Text="Tìm kiếm" OnClick="btnsearch_Click" /> <br />
            <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
        </div>
        
    
    </div>
    </form>
</body>
</html>

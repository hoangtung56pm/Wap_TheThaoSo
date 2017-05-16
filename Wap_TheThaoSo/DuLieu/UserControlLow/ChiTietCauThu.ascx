<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietCauThu.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControlLow.ChiTietCauThu" %>

<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="TopLeague.ascx" TagName="TopLeague" TagPrefix="uc2" %>
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
                        <a href="javascript:void(0)">Cầu thủ</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="chitietdoibong">
                    <asp:Repeater ID="rptPlayerInfo" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <div class="clear10px">
                            </div>
                            <div class="floatleft padding-left5px">
                                <img alt="" width="80" height="80" src="http://thethaoso.vn/App_Themes/Sport/PlayerLogos/logos/<%# Eval("Person_Id") %>.jpg" />
                            </div>
                            <div class="floatleft padding-left10px">
                                <b class="floatleft">
                                    <%# Eval("First_Name") %>
                                    <%# Eval("Last_Name") %></b>
                                <div class="clear5px">
                                </div>
                                Quốc tịch:
                                <%# Eval("National") %>
                                <div class="clear2px">
                                </div>
                                Ngày sinh:
                                <%# Eval("BirthDay")%>
                                <div class="clear2px">
                                </div>
                                Tuổi:
                                <%# Eval("Age") %>
                                <div class="clear2px">
                                </div>
                                Nơi Sinh:
                                <%# Eval("BirthPlace")%>
                                <div class="clear2px">
                                </div>
                                Vị trí:
                                <%# Eval("Position")%>
                                <div class="clear2px">
                                </div>
                                Chiều cao:
                                <%# Eval("Height")%>
                                <div class="clear2px">
                                </div>
                                Cân nặng:
                                <%# Eval("Weight")%>
                                <div class="clear2px">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
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
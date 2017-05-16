<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuVan.ascx.cs" Inherits="Wap_TheThaoSo.DuLieu.UserControl.TuVan" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="../../TinTuc/UserControl/BottomCategory.ascx" TagName="BottomCategory"
    TagPrefix="uc2" %>
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
                        <a href="javascript:void(0)">Tư vấn đặc biệt</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <asp:Repeater ID="rptContent" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div>
                            <p style="text-align: justify;">
                                <%# Eval("Content") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="tuvan">
                    <ul>

                        <asp:Repeater ID="rptTip" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="/DuLieu/Tip.aspx?id=<%# Eval("TipId") %>&amp;lang=1&amp;w=<%= width %>" style="color:#0033FF;">
                                        Tip trận <%# Eval("Team_A_Name") %> vs <%# Eval("Team_B_Name") %> 
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                        <asp:Repeater ID="rptTuVan" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <asp:Literal ID="ltrUrl" runat="server"></asp:Literal>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                 
                    </ul>
                    <div class="clear5px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear5px">
    </div>

    <div align="right"><i>Giá tư vấn: Chưa đăng ký: 5000 đ/ Đã đăng ký dịch vụ: 0 đ</i></div>

    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc2:BottomCategory ID="BottomCategory1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

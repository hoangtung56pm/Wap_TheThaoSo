<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNenChiTiet_New.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControlLow.HinhNenChiTiet_New" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>

<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="../../HinhNen/UserControl/NewPagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="../../TinTuc/UserControlLow/BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc4" %>


<div id="content">
    <div class="home_content">
        <div class="clear5px">
        </div>
        <div class="home_conent_top">
           
            <div class="item">

                        <div class="item-top item-bg">
                            <div class="red-separator margin-left2px"></div>
                            <div class="floatleft padding-left5px padding-right5px  background-white">
                                <a  href="<%= UrlProcess.GetHinhNenHomeNewUrl() %>">Ảnh Đẹp</a>
                             </div>
                            <div class="red-separator margin-right2px"></div>
                        </div>
                        
                        <div class="clear7px"></div>

                        <div class="background-xam-e0e0e0 height22px lineheight22"><b class="padding-left5px"><%= AppEnv.TrimLength(AlbumName,40) %></b></div>

                        <div class="clear10px"></div>

                        <div>
                            <%= AlbumDetail%>
                        </div>

                        <div class="clear2px"></div>

                    </div>

        </div>
        <div class="clear5px">
        </div>
        <div class="home_conent_bottom">
            <asp:Repeater ID="rptAlbumDetail" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">

                        <div class="image">
                            <a href="#">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("PicAvatar"),100,100) %>" />
                            </a>
                        </div>

                        <div class="clear0px"></div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear5px"></div>
            <div class="clear5px"></div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc4:BottomCategory ID="BottomCategory1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>
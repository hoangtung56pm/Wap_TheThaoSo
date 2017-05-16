<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControl.Header" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register Src="DangKy.ascx" TagName="DangKy" TagPrefix="uc1" %>

<style>
    
    .btn-danger {
    background-color: #d9534f;
    border-color: #d43f3a;
    color: #fff;
    cursor: pointer;
}

</style>

<div id="header">

    <div>
        
         <div align="right" style="font-size: 11px; padding-left: 0px; padding-top: 5px; z-index: 99999; color:orange; background:#221d21;">
               <img src="/layout/images/vnm_logo.png" alt="" /> Xin chào: <b><asp:Literal ID="litMsisdn" runat="server"></asp:Literal></b> | 
               <a style="text-decoration:none;color:orange;" href="/Wap/HuongDan.aspx">Hướng dẫn </a> 
                <%--|
                <a style="text-decoration:none;color:orange;" href="/TinTuc/Default.aspx?lang=1&display=login">Đăng nhập </a>--%>
         </div>

        <div class="logo">
            <a href="<%= AppEnv.GetSetting("WapDefault") %>"><img alt="" src="/layout/images/logo.jpg" /></a>
            <%--<a href="http://wap.vietnamobile.com.vn/Sub/RegisVisport.aspx">--%>
            <a href="http://wap.thethaoso.vn/ld/index.html">
                <img style="float: right; padding-top:3px; padding-right:5px;" height="50px" width="150px" alt="" src="/layout/images/bannertopVS_new1.gif" />
            </a>
        </div>
        
    </div>

    <div class="clear0px">
    </div>
    <div class="menu">
        <ul>

            <%-- <li class="<%= TinTucCss %>">
                <a href="<%= UrlProcess.GetHomeUrl("1","320") %>">Tin tá»©c</a>
            </li>--%>

             <%--<li style="width: 140px;" class="<%= TinTucCss %>">
                <a href="/Wap/CTKMGV.aspx">CTKM</a>
            </li>--%>
          <%--  <li style="width: 90px;" class="<%= TinTucCss %>">
                <a href="/Wap/CTKMGV.aspx">CTKM</a>
            </li>--%>     
            <li class="<%= LiveCss %>"><a href="<%= UrlProcess.GetHomeUrl("1","320") %>">Tin tức</a></li>

            <li class="<%= VideoCssS %>"><a href="<%= UrlProcess.GetVideoHomeUrl() %>">Video</a></li>
           <%-- <li class="<%= VideoCssS %>"><a href="http://visport.vn/Worldcup.aspx">Euro 2016</a></li>--%>
             <li class="<%= DuLieuCss %>" style="display:none"><a href="/Wap/GameShow.aspx">Euro 2016</a></li>

            <%--<li class="<%= DuLieuCss %>"><a href="<%= UrlProcess.GetDuLieuHomeUrl() %>">Dữ liệu</a></li>--%>
            

        </ul>
    </div>

    <div class="clear0px"></div>

    <uc1:DangKy ID="DangKy1" runat="server" />

    <div class="clear0px"></div>
    
    <asp:Panel ID="pnlDangKy" runat="server">
        
        <%--<div align="center" style="border-style:solid; border-color:#ff6600">
        Đăng ký dịch vụ ngay để tham gia chương trình khuyến mại hấp dẫn với cơ hội sở hữu Samsung Galaxy S4
        <br/>
        <asp:Button ID="btnDangKyCgBd" CssClass="btn-danger" Text="Đăng Ký" runat="server" OnClick="btnDangKyCgBd_Click"/>
    </div>--%>

    </asp:Panel>
    
    
    <div class="clear0px"></div>

    <div class="running-text">
        <marquee behavior="scroll" scrolldelay="150" onmouseover="this.stop();" onmouseout="this.start();"
            direction="left">
                        
                        <asp:Repeater ID="rptMarqueeNews" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                    <%# Eval("Content_Headline") %> 
                                </a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:Repeater></marquee>
    </div>
    <div class="clear5px">
    </div>
    <div class="search" style="display:none;">
        <asp:TextBox ID="txtKey" CssClass="txtInput" runat="server"></asp:TextBox>
        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="floatleft"
            ImageUrl="/layout/images/btn_search.png" />
        <div class="bandaydu">
            <a href="http://thethaoso.vn/?full=1">Bản đầy đủ<a href="http://thethaoso.vn/?full=1">Bản đầy đủ</a></div>
    </div>
</div>

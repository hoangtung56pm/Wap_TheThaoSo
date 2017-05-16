<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControlLow.Header" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register Src="DangKy.ascx" TagName="DangKy" TagPrefix="uc1" %>

<div id="header">
    
    <div class="header-in-top">
        
         <div align="right" style="font-size: 11px; padding-left: 0px; padding-top: 5px; z-index: 99999; color:orange; background:#221d21;">
                <img src="/layout/images/vnm_logo.png" alt="" /> Xin chào: <b><asp:Literal ID="litMsisdn" runat="server"></asp:Literal></b> |

                <a style="text-decoration:none;color:orange;" href="/Wap/HuongDan.aspx">Hướng dẫn </a>

         </div>

        <div class="logo">
            <a href="<%= AppEnv.GetSetting("WapDefault") %>"><img alt="" src="/layout/images/logo.jpg" /></a>

            <a href="http://trachanhquan.com/cp54/">
                <img style="float: right; padding-top:3px; padding-right:5px;" height="50px" width="110px" alt="" src="/layout/images/image_sc.gif" />
            </a>

        </div>
        
    </div>
    <div class="clear0px">
    </div>
    <div class="menu">
        <ul style="width:100%;">

            <%--<li style="width:25%;" class="<%= TinTucCss %>"><a href="<%= UrlProcess.GetHomeLowUrl("1","320") %>">Tin tức</a></li>--%>

            <li style="width:25%;" class="<%= TinTucCss %>"><a href="/Wap/GameShow.aspx">Gameshow</a></li>

            <%--<li class="separator"></li>--%>
            <li style="width:25%;" class="<%= DuLieuCss %>"><a href="<%= UrlProcess.GetDuLieuHomeLowUrl() %>">Dữ liệu</a></li>
            <%--<li class="separator"></li>--%>
            <li style="width:25%;" class="<%= VideoCssS %>"><a href="<%= UrlProcess.GetVideoHomeLowUrl() %>">Video</a>
            </li>
            <%--<li class="separator"></li>--%>
            <li style="width:24%;" class="<%= LiveCss %>"><a href="<%= UrlProcess.GetLivescoreLowUrl() %>">Livescore</a>
            </li>
        </ul>
    </div>

    <div class="clear0px"></div>

    <uc1:DangKy ID="DangKy1" runat="server" />

    <div class="clear0px"></div>
    
    <div align="center" style="border-color: red;">
        Đăng ký dịch vụ ngay để tham gia chương trình khuyến mại hấp dẫn với cơ hội sở hữu Samsung Galaxy S4
    </div>

    <div class="clear0px"></div>

    <div class="running-text">
        <marquee behavior="scroll" scrolldelay="150" onmouseover="this.stop();" onmouseout="this.start();"
            direction="left">
                        
                        <asp:Repeater ID="rptMarqueeNews" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                    <%# Eval("Content_Headline") %> 
                                </a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </marquee>
    </div>
    <div class="clear5px">
    </div>
    <div class="search" style="display:none;">
        <asp:TextBox ID="txtKey" CssClass="txtInput" runat="server"></asp:TextBox>
        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="floatleft"
            ImageUrl="/layout/images/btn_search.png" />
    </div>
</div>

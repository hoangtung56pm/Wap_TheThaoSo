<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControl.Detail" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register src="Pagging.ascx" tagname="Pagging" tagprefix="uc2" %>
<%@ Register src="BottomCategory.ascx" tagname="BottomCategory" tagprefix="uc3" %>


<table style="width: 100%; display: none" class="InfoNewsLink icon-link">
</table>
<div id="content">
    <div class="home_content">
        <div class="clear5px">
        </div>
        <div class="home_conent_top">
            <div class="item">
                <asp:Repeater ID="rptNewsDetail" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="item-top item-bg">
                            <div class="red-separator margin-left2px">
                            </div>
                            <div class="floatleft padding-left5px padding-right5px  background-white">
                                <a href="<%# UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID"))) %>">
                                    <%# Eval("CategoryName")%></a></div>
                            <div class="red-separator margin-right2px">
                            </div>
                        </div>
                        <div class="clear5px">
                        </div>
                        <div class="text-detail">
                            <a href="javascript:void(0)" class="bold color-red font16px">
                                <%# Eval("Content_Headline")%></a>

                                <br />
                                <span class="font12px italic"><%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%></span>

                            <div class="sapo font14px">
                                <%# Eval("Content_Teaser")%>
                            </div>
                            <div class="text-detail-in font14px">
                                <%--Body--%>
                                <%# ReplaceImageSource(Eval("Content_Body").ToString())%>
                            </div>
                        </div>
                        <div class="clear2px"></div>

                    </ItemTemplate>
                </asp:Repeater>

                <uc1:GiaiTri ID="GiaiTri1" runat="server" />

                <div class="other-news">
                     <div class="clear5px">
                    </div>
                    <div style="background-color: #FF6600; height: 1px; width: 100%; float: left; margin-top: 8px;">
                        <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                            padding-left: 5px;">Các tin khác</b>
                    </div>
                    <div class="clear5px">
                    </div>

                    <div class="clear5px"></div>
                    <ul>
                        
                        <asp:Repeater ID="rptOtherNews" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                        <%# Eval("Content_Headline") %> 
                                    </a>

                                    <%--(<%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%>)--%>
                                    <span class="font12px italic">(<%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%>)</span>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                    <div class="clear10px"></div>

                    <uc2:Pagging ID="Pagging1" runat="server" />

                    <div class="clear5px"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5"></div>

    <uc3:BottomCategory ID="BottomCategory1" runat="server" />

    <div class="clear5px"></div>

    <%--<uc1:GiaiTri ID="GiaiTri1" runat="server" />--%>
    <div class="quangcao">
    <a href="/DuLieu/Default.aspx?display=tuvan&w=320&id=4B4619C7-531B-4856-ABA5-A38593CBCFC9">
        <img alt="" width="100%" src="/layout/images/quangcao1.jpg" />
    </a>
</div>

</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControl.Category" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc3" %>
<div id="content">
    <div class="home_content">
        <div class="clear5px">
        </div>
        <div class="home_conent_top">
            <asp:Repeater ID="rptContentTop" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="item-top item-bg">
                            <div class="red-separator margin-left2px">
                            </div>
                            <div class="floatleft padding-left5px padding-right5px  background-white">
                                <a  href="<%# UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(Eval("CategoryId")))  %>">
                                    <%= CategoryName%></a></div>
                            <div class="red-separator margin-right2px">
                            </div>
                        </div>
                        <div class="clear5px">
                        </div>
                        <div class="image">
                            <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),150,121) %>" />
                            </a>
                        </div>
                        <a class="link-title-item-top"  href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <%# Eval("Content_Headline")%>
                        </a>

                        <br />
                        <%--<%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%>--%>
                        <span class="font12px italic"><%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%></span>

                        <p class="justify lineheight padding-right7px margin-left5px font14px">
                            <%# Eval("Content_Teaser")%></p>
                        <div class="clear7px">
                        </div>
                        <div style="height: 1px; background-color: #b5b5b5">
                        </div>
                        <div class="clear2px">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clear5px">
        </div>
        <div class="home_conent_bottom">
            <asp:Repeater ID="rptContentBottom" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="image">
                            <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),100,86) %>" />
                            </a>
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <%# Eval("Content_Headline")%>
                        </a>

                        <br />
                        <span class="font12px italic"><%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%></span>

                        <p class="justify lineheight padding-right7px margin-left5px font14px">
                            <%# Eval("Content_Teaser")%></p>
                        <div class="clear0px">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-alternate">
                        <div class="image">
                            <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),100,86) %>" />
                            </a>
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <%# Eval("Content_Headline")%>
                        </a>

                        <br />
                        <span class="font12px italic"><%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("Distribution_CreateDate")))%></span>

                        <p class="justify lineheight padding-right7px margin-left5px font14px">
                            <%# Eval("Content_Teaser")%></p>
                        <div class="clear0px">
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div class="clear5px">
            </div>
            <uc2:Pagging ID="Pagging1" runat="server" />
            <div class="clear5px">
            </div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc3:BottomCategory ID="BottomCategory1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>

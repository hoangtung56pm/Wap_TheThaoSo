<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs"
    Inherits="Wap_TheThaoSo.TinTuc.UserControl.SearchResult" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="VideoPagging.ascx" TagName="VideoPagging" TagPrefix="uc3" %>
<%@ Register Src="BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc4" %>
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
                        <a href="javascript:void(0)">Kết quả tìm kiếm</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
            </div>
        </div>
        <div class="clear5px">
        </div>
        <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Tìm thấy
                <asp:Label runat="server" ID="lblBaiViet" Text="0"></asp:Label>
                bài viết</b>
        </div>
        <div class="home_conent_bottom">
            <%--<div class="hinhanh">--%>
            <asp:Repeater ID="rptBaiViet" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                       <div class="image">
                            <a href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),100,86) %>" />
                            </a>
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetNewsDetailUrl(ConvertUtility.ToInt32(Eval("CategoryId")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <%# KeywordHighlight(Eval("Content_Headline").ToString(),Keyword)%>
                        </a>
                        <p class="justify lineheight padding-right7px margin-left5px">
                            <%# KeywordHighlight(Eval("Content_Teaser").ToString(), Keyword) %></p>
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
                            <%# KeywordHighlight(Eval("Content_Headline").ToString(),Keyword)%>
                        </a>
                        <p class="justify lineheight padding-right7px margin-left5px">
                            <%# KeywordHighlight(Eval("Content_Teaser").ToString(), Keyword) %></p>
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
            <%--</div>--%>
        </div>
        <div class="clear5px">
        </div>
        <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Tìm thấy
                <asp:Label runat="server" ID="lblVideo" Text="0"></asp:Label>
                video</b>
        </div>
        <div class="home_conent_bottom">
            <%--<div class="hinhanh">--%>
            <asp:Repeater runat="server" ID="rptVideo" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="image">
                            <img alt="" src="<%# AppEnv.GetAvatarVideo(Eval("Thumnail").ToString(),100,86) %>" /></div>
                        <div class="text margin-left3px">
                            <a class="link-title" href="<%# UrlProcess.GetVideoDetailUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                <%# KeywordHighlight(Eval("Title").ToString(), Keyword)%></a>
                            <div class="clear2px">
                            </div>
                            <div>
                                <%# KeywordHighlight(Eval("Description").ToString(),Keyword) %></div>
                            <div class="clear5px">
                            </div>
                            <%--<div>
                                Thể loại:
                                <%# Eval("CategoryName") %></div>--%>
                            <div class="clear5px">
                            </div>
                            <a class="link-title" href="<%# UrlProcess.GetVideoDownloadUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">Tải</a> 
                            | <a class="link-title" href="<%# UrlProcess.GetVideoDetailUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                Xem</a> 
                                <%--| <a class="link-title" href="javascript:void(0)">Tặng</a>--%>
                        </div>
                        <div class="clear5px">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-alternate">
                       <div class="image">
                            <img alt="" src="<%# AppEnv.GetAvatarVideo(Eval("Thumnail").ToString(),100,86) %>" /></div>
                        <div class="text margin-left3px">
                            <a class="link-title" href="<%# UrlProcess.GetVideoDetailUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                <%# KeywordHighlight(Eval("Title").ToString(), Keyword)%></a>
                            <div class="clear2px">
                            </div>
                            <div>
                                <%# KeywordHighlight(Eval("Description").ToString(),Keyword) %></div>
                            <div class="clear5px">
                            </div>
                            <%--<div>
                                Thể loại:
                                <%# Eval("CategoryName") %></div>--%>
                            <div class="clear5px">
                            </div>
                            <a class="link-title" href="<%# UrlProcess.GetVideoDownloadUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">Tải</a> 
                            | <a class="link-title" href="<%# UrlProcess.GetVideoDetailUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                Xem</a> 
                                <%--| <a class="link-title" href="javascript:void(0)">Tặng</a>--%>
                        </div>
                        <div class="clear5px">
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div class="clear5px">
            </div>
            <uc3:VideoPagging ID="VideoPagging" runat="server" />
            <div class="clear5px">
            </div>
            <%--</div>--%>
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

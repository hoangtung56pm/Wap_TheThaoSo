<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoCategory.ascx.cs" Inherits="Wap_TheThaoSo.Video.UserControlLow.VideoCategory" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc3" %>
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
                        <a href="javascript:void(0)">
                            <%= CateName %></a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear5px">
        </div>
        <div class="home_conent_bottom">
            <asp:Repeater runat="server" ID="rptContentBottom" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="image">
                            <a class="link-title" href="<%# UrlProcess.GetVideoDetailLowUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                <img alt="" width="60" height="45" src="<%# AppEnv.GetAvatarVideo(Eval("Thumnail").ToString(),60,45) %>" />
                            </a>
                        </div>
                        <div class="clearright5px">
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetVideoDetailLowUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                            <%# Eval("Title")%></a>
                        <div class="clearright5px">
                        </div>
                        <div>
                            Lượt xem:
                            <%# ConvertUtility.ToInt32(Eval("ViewCount").ToString()) + 1000%>
                        </div>
                        <div class="clearright5px">
                        </div>
                        <div>
                            Thể loại:<a class="link-title" href="<%# UrlProcess.GetVideoCategoryLowUrl(ConvertUtility.ToInt32(Eval("CategoryId"))) %>">
                                <%# Eval("CategoryName") %>
                            </a>
                        </div>
                        <div class="clearright5px"></div>

                        <div>
                                Giá tải hoặc xem video: <%= Price %>/lượt
                            </div>

                        <div class="clearright5px"></div>

                        <a style="color:#FF6600; text-decoration:none; font-weight:bold" class="margin-right2px margin-left2px font13px" href="<%# UrlProcess.GetVideoDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                            Tải</a> | <a style="color: #FF6600; text-decoration:none; font-weight:bold" class="margin-right2px margin-left2px font13px"
                                href="<%# UrlProcess.GetVideoXemLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                                Xem</a> 

                        <div class="clear5px">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-alternate">
                        <div class="image">
                            <a class="link-title" href="<%# UrlProcess.GetVideoDetailLowUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                                <img alt="" width="60" height="45" src="<%# AppEnv.GetAvatarVideo(Eval("Thumnail").ToString(),141,110) %>" />
                            </a>
                        </div>
                        <div class="clearright5px">
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetVideoDetailLowUrl(ConvertUtility.ToInt32(Eval("VideoId"))) %>">
                            <%# Eval("Title")%></a>
                        <div class="clearright5px">
                        </div>
                        <div>
                            Lượt xem:
                            <%# ConvertUtility.ToInt32(Eval("ViewCount").ToString()) + 1000%>
                        </div>
                        <div class="clearright5px">
                        </div>
                        <div>
                            Thể loại: <a class="link-title" href="<%# UrlProcess.GetVideoCategoryLowUrl(ConvertUtility.ToInt32(Eval("CategoryId"))) %>">
                                <%# Eval("CategoryName") %>
                            </a>
                        </div>
                        <div class="clearright5px"></div>

                        <div>
                            Giá tải hoặc xem video: <%= Price %>/lượt
                         </div>

                        <div class="clearright5px"></div>

                        <a style="color: #FF6600; text-decoration:none; font-weight:bold" class="margin-right2px margin-left2px font13px" href="<%# UrlProcess.GetVideoDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                            Tải</a> | <a style="color: #FF6600; text-decoration:none; font-weight:bold" class="margin-right2px margin-left2px font13px"
                                href="<%# UrlProcess.GetVideoXemLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                                Xem</a> 
   
                        <div class="clear5px">
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoDetail.ascx.cs" Inherits="Wap_TheThaoSo.Video.UserControlLow.VideoDetail" %>

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
                        <a href="javascript:void(0)">Video</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <asp:Repeater ID="rptContentTop" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="image">
                            <img width="60" height="45" alt="" src="<%# AppEnv.GetAvatarVideo(Eval("Thumnail").ToString(),60,45) %>" />
                        </div>
                        <div class="text  width50percent floatleft">
                            <a href="#">
                                <%# Eval("Title")%></a>
                            <div class="clearright2px">
                            </div>
                            <div class="justify lineheight">
                                <%# ConvertUtility.ToInt32(Eval("ViewCount").ToString()) + 1000%>
                                lượt tải</div>
                            <div class="clearright2px"></div>
                            <div class="justify lineheight">
                                Giá tải: <%= Price %>/lượt
                            </div>
                            <div class="clearright2px">
                            </div>
                            <div class="justify lineheight">
                                Giá xem: <%= Price %>/lượt</div>
                            <div class="clearright2px">
                            </div>
                            <div class="justify lineheight">
                                <div class="clear2px">
                                </div>
                                <a href="<%# UrlProcess.GetVideoXemLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                                    Xem trực tuyến</a></div>
                            <div class="clearright2px">
                            </div>
                            <div class="taive">
                                <img alt="" src="/layout/images/icon-taive.png" />
                                <a href="<%# UrlProcess.GetVideoDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>"
                                    class="link_taive">Tải về</a>
                            </div>
                            <div class="clearright5px">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear7px">
                </div>
            </div>
        </div>
        <div class="clear5px">
        </div>

         <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Các video khác</b>
        </div>

        <div class="home_conent_bottom">
            <asp:Repeater ID="rptContentBottom" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item-video">
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

                        <a style="color: #FF6600; text-decoration: none; font-weight: bold" class="margin-right2px margin-left2px font13px"
                            href="<%# UrlProcess.GetVideoDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                            Tải</a> | <a style="color: #FF6600; text-decoration: none; font-weight: bold" class="margin-right2px margin-left2px font13px"
                                href="<%# UrlProcess.GetVideoXemLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                                Xem</a>
                        <div class="clear5px">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-video-alternate">
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

                        <a style="color: #FF6600; text-decoration: none; font-weight: bold" class="margin-right2px margin-left2px font13px"
                            href="<%# UrlProcess.GetVideoDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                            Tải</a> | <a style="color: #FF6600; text-decoration: none; font-weight: bold" class="margin-right2px margin-left2px font13px"
                                href="<%# UrlProcess.GetVideoXemLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("VideoId")), CatID.ToString()) %>">
                                Xem</a>
                        <div class="clear5px">
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div class="clear10px">
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

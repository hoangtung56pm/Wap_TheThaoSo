<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControlLow.Home" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<div class="home_content">
    <div class="clear5px">
    </div>
    <div class="home_conent_top">
        <div class="item">
            <asp:Repeater ID="rptContentTop" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="80" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),80,75) %>" />
                        </a>
                    </div>
                    <a class="link-title-item-top" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                    <p class="justify lineheight padding-right7px margin-left5px font14px">
                        <%# Eval("Content_Teaser")%></p>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear7px">
            </div>
            <div style="height: 1px; background-color: #b5b5b5">
            </div>
            <div class="clear2px"></div>
            <div class="other">
                <ul>
                    <asp:Repeater ID="rptContentTopList" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="clear10px">
    </div>

    <uc1:GiaiTri ID="GiaiTri1" runat="server" />

    <div class="clear10px">
    </div>
    <div class="home_conent_bottom">
        
        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("321"))) %>">
                        Chiến thắng nhà cái</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptNhaCai" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img width="60" alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("321")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>

                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptNhaCaiList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("321"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(375) %>">
                        Điểm Tin</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptDiemTin" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(375,ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptDiemTinList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(375,ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(375) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh"))) %>">
                        Bóng đá Anh</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptAnh" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img width="60" alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>

                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptAnhList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>
        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha"))) %>">
                        Bóng đá Tây Ban Nha</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptTayBanNha" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptTayBanNhaList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>
        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia"))) %>">
                        Bóng đá Italia</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptItalia" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptItaliaList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>
        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc"))) %>">
                        Bóng đá Đức</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptDuc" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptDucList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("352"))) %>">
                        Bóng đá Pháp</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptPhap" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("352")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptPhapList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("352")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("352"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau"))) %>">
                        Bóng đá 5 châu</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptNamChau" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptNamChauList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>
        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam"))) %>">
                        Bóng đá Việt Nam</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptVietNam" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptVietNamList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe"))) %>">
                        Thể thao quốc tế</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptTheThaoQuocTe" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptTheThaoQuocTeList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe"))) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

        <div class="item">
            <div class="item-top item-bg">
                <div class="red-separator margin-left2px">
                </div>
                <div class="floatleft padding-left5px padding-right5px background-white">
                    <a href="<%= UrlProcess.GetNewsCategoryLowUrl(138) %>">
                        Chuyện Sao</a></div>
                <div class="red-separator margin-right2px">
                </div>
            </div>
            <div class="clear5px">
            </div>
            <asp:Repeater ID="rptChuyenSao" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="image">
                        <a href="<%# UrlProcess.GetNewsDetailLowUrl(ConvertUtility.ToInt32(Eval("Distribution_ZoneID")),ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                            <img alt="" width="60" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar"),60,60) %>" />
                        </a>
                    </div>
                    <a class="link-title font14px" href="<%# UrlProcess.GetNewsDetailLowUrl(138,ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear0px">
            </div>
            <div class="other">
                <ul>
                    <asp:Repeater runat="server" ID="rptChuyenSaoList" EnableViewState="false">
                        <ItemTemplate>
                            <li><a href="<%# UrlProcess.GetNewsDetailLowUrl(138,ConvertUtility.ToInt32(Eval("Distribution_ID"))) %>">
                                <%# Eval("Content_Headline")%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="clear5px">
            </div>
            <div class="floatright">
                <a href="<%= UrlProcess.GetNewsCategoryLowUrl(ConvertUtility.ToInt32(138)) %>"
                    class="xemtiep">Xem tiếp >></a></div>
            <div class="clear5px">
            </div>
        </div>

    </div>
</div>
<div class="clear5px">
</div>

<div class="quangcao">
        <%--<a href="/DuLieu/DefaultLow.aspx?display=tuvan&w=320&id=4B4619C7-531B-4856-ABA5-A38593CBCFC9">
            <img alt="" width="100%" src="/layout/images/quangcao1.jpg" />
        </a>--%>

        <a href="#">
            <img alt="" width="100%" src="/layout/images/quangcao.gif" />
        </a>

    </div>

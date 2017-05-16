<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhacChuong.ascx.cs" Inherits="Wap_TheThaoSo.NhacChuong.UserControlLow.NhacChuong" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>

<%@ Register src="../../Wap/UserControlLow/GiaiTri.ascx" tagname="GiaiTri" tagprefix="uc1" %>

<%@ Register src="../../NhacChuong/UserControl/DownloadPagging.ascx" tagname="DownloadPagging" tagprefix="uc2" %>
<%@ Register src="../../NhacChuong/UserControl/NewPagging.ascx" tagname="NewPagging" tagprefix="uc3" %>
<%@ Register src="../../TinTuc/UserControlLow/BottomCategory.ascx" tagname="BottomCategory" tagprefix="uc4" %>

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
                                    <a href="javascript:void(0)">Nhạc chuông</a></div>
                                <div class="red-separator margin-right2px">
                                </div>
                            </div>
                            <div class="clear5px">
                            </div>
                        </div>
                    </div>
                   
                    <div class="background-xam-e0e0e0 height22px lineheight22">
                        <b class="padding-left5px">Mới nhất</b>
                    </div>
                    <div class="home_conent_bottom">
                        <div class="clear5px">
                        </div>
                        <div class="nhachuong">
                            
                            <asp:Repeater ID="rptMoiNhat" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <div class="item">
                                <div class="image">
                                    <img alt="" src="/layout/images/icon-nhacchuong.png" /></div>
                                <div class="text">
                                    <a href="<%# UrlProcess.GetNhacChuongDetailLowUrl(0,ConvertUtility.ToInt32(Eval("W_MItemId"))) %>"><%# Eval("SongNameUnicode") %></a> - <%# Eval("ArtistNameUnicode") %>
                                </div>

                                 <div class="text">
                                        <%--<img alt="" class="floatleft" src="/layout/images/icon-taive.png" />--%>
                                        <a href="<%# UrlProcess.GetRingToneDownloadUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_MItemId")), CatID.ToString()) %>" class="link_taive">Tải về (<%= Price %>/lượt)</a>
                                    </div>

                                <div class="clear2px">
                                </div>
                            </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <div class="clear5px">
                            </div>
                            
                            <uc3:NewPagging ID="NewPagging1" runat="server" />

                            <div class="clear5px">
                            </div>

                              <div align="right"><i>Giá tải nhạc: <%= Price %>/lượt</i></div>

                        </div>
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomCategory.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControl.BottomCategory" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>



<div id="othercategory">
                    <ul>
                        <li><a href="<%= UrlProcess.GetNewsCategoryUrl(375) %>" class="none">ĐIỂM TIN</a> </li>
                        <li><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaAnh"))) %>" class="none">Bóng đá Anh</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaTayBanNha"))) %>">Bóng đá TBN</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaItalia"))) %>">Bóng đá Italia</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongDaDuc"))) %>">Bóng đá Đức</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongNamChau"))) %>">Bóng đá 5 Châu</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("BongVietNam"))) %>">Bóng đá Việt Nam</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetNewsCategoryUrl(ConvertUtility.ToInt32(AppEnv.GetSetting("TheThaoQuocTe"))) %>">Thể thao quốc tế</a> </li>
                    </ul>
                </div>
<%@ Page Title="Cache Directory file names" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DirectoryCache.aspx.cs" Inherits="Caching.WebForms.DirectoryCache" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="hero-unit">
        <h1><%= Page.Title %></h1>
         <h2 style="background-color:aqua">Add or delete file in App_Data folder to test</h2>
        <h2>Value taken from cache: <span id="currentTimeSpan" runat="server"></span></h2>
        <p>File paths: <span id="filePathSpan" runat="server"></span></p>
    </div>
</asp:Content>

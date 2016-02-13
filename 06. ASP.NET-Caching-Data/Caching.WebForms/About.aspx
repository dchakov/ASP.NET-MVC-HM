<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Caching.WebForms.About" %>

<%@ Import Namespace="Caching" %>

<%@ OutputCache Duration="3600" VaryByParam="none" %>
<%--<%@ OutputCache CacheProfile="ShortLived" %>--%>
<%--<%@ OutputCache CacheProfile="LongLived" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Time last cached: <%= DateTime.Now %></h3>
    <h3>Page number: <%= GlobalCounter.Next() %></h3>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>

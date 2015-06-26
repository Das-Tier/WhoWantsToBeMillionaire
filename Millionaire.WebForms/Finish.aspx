<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="Millionaire.WebForms.Finish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<h1>Гра закінчена! Ваш виграш <asp:Label ID="lbl_result" runat="server">$</asp:Label></h1>
        <asp:Button ID="btn_gotostart" runat="server" onclick="btn_gotostart_Click" Text="На головну" CssClass="button_helpers"/> 
</asp:Content>

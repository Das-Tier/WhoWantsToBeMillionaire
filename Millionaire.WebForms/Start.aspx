<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Millionaire.WebForms.Start" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:TextBox ID="txbx_userName" runat="server"></asp:TextBox>
    <asp:Button ID="btn_startGame" Text="Почати гру !" runat="server" onclick="btn_startGame_Click"/>
    <asp:RequiredFieldValidator runat="server" ID="vld_nameValidate" ErrorMessage="Вкажіть ім'я!" ForeColor="White" ControlToValidate="txbx_userName"></asp:RequiredFieldValidator>
</asp:Content>

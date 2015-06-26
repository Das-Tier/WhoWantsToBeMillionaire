<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Millionaire.WebForms.Main" %>
<%@  PreviousPageType VirtualPath="~/Start.aspx"%>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="content">
        
        <div id="menu">
            <asp:Button ID="btn_newgame" runat="server" Text="Нова гра" OnClick="btn_newgame_Click"
                CssClass="button" />
            <asp:Button ID="btn_halfONhalf" runat="server" Text="50/50" CssClass="button_helpers"
                OnClick="btn_halfONhalf_Click" />
            <asp:Button ID="btn_friendHelp" runat="server" Text="E-Mail другу" CssClass="button_helpers"
                OnClick="btn_friendHelp_Click" />
            <asp:Button ID="btn_auditoryHelp" runat="server" Text="Допомога Google" CssClass="button_helpers"
                OnClick="btn_auditoryHelp_Click" />
        </div>
        <div id="div_question">
            <asp:Label ID="lbl_question" Text="" runat="server"></asp:Label>
        </div>
        <div id="div_answer">
            <asp:RadioButtonList ID="rdbl_answers" runat="server">
                <asp:ListItem Value="a" Text=""></asp:ListItem>
                <asp:ListItem Value="b" Text=""></asp:ListItem>
                <asp:ListItem Value="c" Text=""></asp:ListItem>
                <asp:ListItem Value="d" Text=""></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button ID="btn_check" Text="Відповісти" runat="server" OnClick="btn_check_Click"
            CssClass="button" />
        
    </div>
    <div>
        <asp:Label ID="lbl_score" runat="server" Text="0" CssClass="button_helpers"></asp:Label>
    </div>
</asp:Content>

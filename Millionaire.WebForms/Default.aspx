<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Millionaire.WebForms.Game" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Who wants to be a millionaire?</title>
    <script src="scripts/script.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <h1>
            Хто хоче стати міліонером?</h1>
    </div>
    <div class="content">
        <form id="frm_game" runat="server">
        <div id="menu">
            <asp:Button ID="btn_newgame" runat="server" Text="Нова гра" OnClick="btn_newgame_Click"
                CssClass="button" />
            <asp:Button ID="btn_halfONhalf" runat="server" Text="50/50" CssClass="button_helpers"
                OnClick="btn_halfONhalf_Click" />
            <asp:Button ID="btn_friendHelp" runat="server" Text="Дзвінок другу" CssClass="button_helpers"
                OnClick="btn_friendHelp_Click" />
            <asp:Button ID="btn_auditoryHelp" runat="server" Text="Допомога залу" CssClass="button_helpers"
                OnClientClick="aspnetForm.target ='_blank';" OnClick="btn_auditoryHelp_Click" />
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
        </form>
    </div>
    <div>
        <asp:Label ID="lbl_score" runat="server" Text="0" CssClass="button_helpers"></asp:Label>
    </div>
    <div class="footer">
        Copyrighted by Vitalii Mohola, EPAM IT Lab 2015
    </div>
</body>
</html>

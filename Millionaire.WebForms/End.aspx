<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="End.aspx.cs" Inherits="Millionaire.WebForms.End" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Who wants to be millionaire?</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frm_end" runat="server">
    <div>
        <h1>Гра закінчена! Ваш виграш <asp:Label ID="lbl_result" runat="server">$</asp:Label></h1>
        <asp:Button ID="btn_gotostart" runat="server" onclick="btn_gotostart_Click" Text="На головну" CssClass="button_helpers"/> 
    </div>
    </form>
</body>
</html>

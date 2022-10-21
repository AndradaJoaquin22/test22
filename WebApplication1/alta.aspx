<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alta.aspx.cs" Inherits="WebApplication1.alta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Style.css" type="text/css"/>
    <title></title>
</head>
<body class="bodyalta">
    <form id="form1" runat="server">

    <div class="grilla">
        <asp:GridView ID="GvDatos" runat="server" AutoGenerateColumns="true">

        </asp:GridView>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            Cantidad<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Genero:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            Precio:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Autor: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Guardar" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="estado"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Inserte id: "></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
            Text="eliminar" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="modificar" />
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="buscar" />
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ConsultaDatos.aspx.vb" Inherits="ConsultaDatos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#E0E0E0" Height="320px" Style="z-index: 100;
            left: 88px; position: absolute; top: 160px" Width="568px">
            <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" Height="264px" PageSize="4"
                Style="z-index: 100; left: 16px; position: absolute; top: 24px" Width="536px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="CORR_MOVI" HeaderText="Num. Orden" />
                    <asp:BoundField DataField="FECH_MOVI" HeaderText="Fecha Movimiento" />
                    <asp:BoundField DataField="CODI_CLIE" HeaderText="C&#243;digo Cliente" />
                    <asp:BoundField DataField="ESTA_ORDE" HeaderText="Estado de Orden" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Navy"
            Style="z-index: 101; left: 168px; position: absolute; top: 32px; text-align: center"
            Text="Consulta de Datos" Width="376px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 102; left: 88px;
            position: absolute; top: 128px; text-align: right" Text="Codigo Cliente:" Width="120px"></asp:Label>
        <asp:TextBox ID="txtCodClie" runat="server" Style="z-index: 103; left: 216px; position: absolute;
            top: 128px" Width="104px"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" Style="z-index: 104; left: 336px;
            position: absolute; top: 128px" Text="Buscar" Width="80px" /><asp:Button ID="btnReg" runat="server" Font-Bold="True" Style="z-index: 106; left: 424px;
            position: absolute; top: 128px" Text="Regresar" Width="80px" />
    
    </div>
    </form>
</body>
</html>

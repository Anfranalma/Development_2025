<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MttoClientes.ascx.vb" Inherits="Controles_MttoClientes" %>
<asp:Panel ID="Panel1" runat="server" BackColor="SkyBlue" Height="512px" Style="z-index: 100;
    left: 0px; position: absolute; top: 0px" Width="640px">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="z-index: 100; left: 48px;
        position: absolute; top: 24px; text-align: right" Text="Código:" Width="64px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 101; left: 48px;
        position: absolute; top: 56px; text-align: right" Text="Nombre:" Width="64px"></asp:Label>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 102; left: 40px;
        position: absolute; top: 88px; text-align: right" Text="Dirección:" Width="72px"></asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 103; left: 40px;
        position: absolute; top: 120px; text-align: right" Text="Telefono:" Width="72px"></asp:Label>
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 104; left: 400px;
        position: absolute; top: 120px; text-align: right" Text="Fax:" Width="72px"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 105; left: 40px;
        position: absolute; top: 152px; text-align: right" Text="Nit:" Width="72px"></asp:Label>
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 106; left: 392px;
        position: absolute; top: 152px; text-align: right" Text="Reg. Fiscal:" Width="80px"></asp:Label>
    <asp:TextBox ID="txtCodClie" runat="server" BackColor="Silver" Font-Bold="True" ForeColor="Navy"
        ReadOnly="True" Style="z-index: 107; left: 120px; position: absolute; top: 24px"
        Width="128px"></asp:TextBox>
    <asp:TextBox ID="txtNomClie" runat="server" Style="z-index: 108; left: 120px; position: absolute;
        top: 56px" Width="488px"></asp:TextBox>
    <asp:TextBox ID="txtDir" runat="server" Style="z-index: 109; left: 120px; position: absolute;
        top: 88px" Width="488px"></asp:TextBox>
    <asp:TextBox ID="txtTel" runat="server" Style="z-index: 110; left: 120px; position: absolute;
        top: 120px" Width="128px"></asp:TextBox>
    <asp:TextBox ID="txtFax" runat="server" Style="z-index: 111; left: 480px; position: absolute;
        top: 120px" Width="128px"></asp:TextBox>
    <asp:TextBox ID="txtNit" runat="server" Style="z-index: 112; left: 120px; position: absolute;
        top: 152px" Width="128px"></asp:TextBox>
    <asp:TextBox ID="txtRegFisc" runat="server" Style="z-index: 113; left: 480px; position: absolute;
        top: 152px" Width="128px"></asp:TextBox>
    &nbsp;
    <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="4" Style="z-index: 114;
        left: 16px; position: absolute; top: 304px" Width="600px" DataKeyNames="CODIGO">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo" />
            <asp:BoundField DataField="NOMB_CLIE" HeaderText="Nombre Cliente" />
            <asp:BoundField DataField="TELE_CLIE" HeaderText="Telefono" />
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Style="z-index: 115; left: 520px;
            position: absolute; top: 192px" Text="Adición" Width="80px" />
        <asp:Button ID="btnEditar" runat="server" Font-Bold="True" Style="z-index: 116; left: 520px;
            position: absolute; top: 224px" Text="Modificar" Width="80px" /><asp:Button ID="btnConsulta" runat="server" Font-Bold="True" Style="z-index: 118; left: 520px;
            position: absolute; top: 256px" Text="Consulta" Width="80px" />
</asp:Panel>

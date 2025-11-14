<%@ Control Language="VB" AutoEventWireup="false" CodeFile="InsertaDatos.ascx.vb" Inherits="Controles_InsertaDatos" %>
<asp:Panel ID="Panel1" runat="server" BackColor="LightBlue" Height="504px" Style="z-index: 100;
    left: 88px; position: absolute; top: 80px" Width="648px">
    <asp:Panel ID="Panel2" runat="server" Height="56px" Style="z-index: 100; left: 288px;
        position: absolute; top: 192px" Width="328px">
        &nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Style="z-index: 100; left: 18px;
            position: absolute; top: 15px" Text="Adición" />
    </asp:Panel>
    <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="Vertical" Style="z-index: 101; left: 8px; position: absolute;
        top: 272px" Width="632px" PageSize="4" Height="168px" AllowPaging="True" DataKeyNames="CODIGO">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo" />
            <asp:BoundField DataField="NOMB_CLIE" HeaderText="Nombre" />
            <asp:BoundField DataField="DIRE_CLIE" HeaderText="Direcci&#243;n" />
            <asp:BoundField DataField="TELE_CLIE" HeaderText="Telefono" />
            <asp:BoundField DataField="FAX_CLIE" HeaderText="Fax" />
            <asp:BoundField DataField="NIT_CLIE" HeaderText="Nit" />
            <asp:BoundField DataField="REGI_FISC_CLIE" HeaderText="Reg. Fiscal" />
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="z-index: 102; left: 16px;
        position: absolute; top: 16px; text-align: right" Text="Código:" Width="64px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 103; left: 16px;
        position: absolute; top: 48px; text-align: right" Text="Nombre:" Width="64px"></asp:Label>
    <asp:TextBox ID="txtCodigo" runat="server" Style="z-index: 104; left: 88px; position: absolute;
        top: 16px" Width="120px" BackColor="#E0E0E0" ReadOnly="True"></asp:TextBox>
    <asp:TextBox ID="txtNomClie" runat="server" Style="z-index: 105; left: 88px; position: absolute;
        top: 48px" Width="544px"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 106; left: 8px;
        position: absolute; top: 80px; text-align: right" Text="Dirección:" Width="64px"></asp:Label>
    <asp:TextBox ID="txtDirClie" runat="server" Style="z-index: 107; left: 88px; position: absolute;
        top: 80px" Width="544px"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 108; left: 16px;
        position: absolute; top: 112px; text-align: right" Text="Telefono:" Width="64px"></asp:Label>
    <asp:TextBox ID="txtTelClie" runat="server" Style="z-index: 109; left: 88px; position: absolute;
        top: 112px" Width="120px"></asp:TextBox>
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 110; left: 440px;
        position: absolute; top: 112px; text-align: right" Text="Fax:" Width="64px"></asp:Label>
    <asp:TextBox ID="txtFaxClie" runat="server" Style="z-index: 111; left: 512px; position: absolute;
        top: 112px" Width="120px"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 112; left: 16px;
        position: absolute; top: 144px; text-align: right" Text="Telefono:" Width="64px"></asp:Label>
    <asp:TextBox ID="txtNit" runat="server" Style="z-index: 113; left: 88px; position: absolute;
        top: 144px" Width="120px"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 114; left: 408px;
        position: absolute; top: 144px; text-align: right" Text="Reg. Fiscal:" Width="96px"></asp:Label>
    <asp:TextBox ID="txtRegFisc" runat="server" Style="z-index: 116; left: 512px; position: absolute;
        top: 144px" Width="120px"></asp:TextBox>
</asp:Panel>

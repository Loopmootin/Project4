<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project4.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <asp:GridView ID="GridViewCommercials" runat="server">
    </asp:GridView>

    <br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <br />

    <asp:textbox runat="server" ID="TextBoxName"></asp:textbox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Logo"></asp:Label>
    <br />
    <asp:textbox runat="server" ID="TextBoxLogo"></asp:textbox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
    <br />
    <asp:textbox runat="server" ID="TextBoxPhone"></asp:textbox>
    <br />
    <br />
    <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" />
</asp:Content>

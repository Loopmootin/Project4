<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="film.aspx.cs" Inherits="Project4.film" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <p>
        <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>
        <br />
    </p>
        <asp:Label ID="Labeltest" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    -----<br />
    <p>
        <asp:Label ID="LabelRating" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="LabelPlot" runat="server" Text="Plot"></asp:Label>
    </p>
    <p>
        <asp:Label ID="LabelChildRating" runat="server" Text="Child Rating"></asp:Label>
    </p>
    <p>
        <asp:Label ID="LabelActors" runat="server" Text="Actors"></asp:Label>
    </p>
    <p>
        <asp:Image ID="ImagePoster" runat="server" />
    </p>
    <p>
    </p>
</asp:Content>

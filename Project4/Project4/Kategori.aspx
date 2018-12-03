<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="Project4.Kategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Fucking Film - Kategori</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    
    <asp:Repeater ID="RepeaterMovies" runat="server">
         <HeaderTemplate>
            <table class="show-pest">
                <div class="container">  
                    <div class="row justify-content-md-center">
        </HeaderTemplate>
            <ItemTemplate>
                
                 <div class="top-movie col-3 split-container">
                    <%# Eval("movie_name") %>
                </div>
              
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                </div>
            </FooterTemplate>
    </asp:Repeater>

    <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>
    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="Project4.Kategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Fucking Film - Kategori</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <asp:Repeater ID="RepeaterMovies" runat="server">
         <HeaderTemplate>
            <table class="show-pest">
                <div class="container">  

                    <div class="category-selection">
                        <div class="category-selection-category">
                            <a class="category-selector" href="Kategori.aspx?id=1"">Animation</a>
                            <a class="category-selector" href="Kategori.aspx?id=3">Thriller</a>
                            <a class="category-selector" href="Kategori.aspx?id=4">Science Fiction</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">Action</a>
                        </div>
                        <hr />
                        <div class="category-selection-year">
                            <a class="category-selector" href="Kategori.aspx?id=1"">2010</a>
                            <a class="category-selector" href="Kategori.aspx?id=3">2011</a>
                            <a class="category-selector" href="Kategori.aspx?id=4">2012</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2013</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2014</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2015</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2016</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2017</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">2018</a>
                        </div>
                    </div>

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

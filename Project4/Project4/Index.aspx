<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project4.Index" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <title>Fucking Film - Forside</title>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="container">  

        <div class="justify-content-md-center">
            <h2>Top film</h2>
                <asp:Repeater ID="RepeaterTop" runat="server">
                    <HeaderTemplate>
                               <div class="top-movies-container col-12 justify-content-around row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="top-movie col-3 split-container">
                        <img src="<%# Eval("poster_url") %>" alt="movie poster" />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                
                       </div>
                    </FooterTemplate>
               </asp:Repeater>
            <h2>Nye film</h2>
            <div class="new-movies-container col-12 justify-content-around row">
                <div class="new-movie col-3 split-container">

                </div>
                <div class="new-movie col-3 split-container">

                </div>
                <div class="new-movie col-3 split-container">

                </div>
            </div>
            <h2>Artikler     <h2>Artikler</h2>
            <div class="articles-container col-12 justify-content-around row">
                <div class="movie-article col-3 split-container">

                </div>
                <div class="movie-article col-3 split-container">

                </div>
                <div class="movie-article col-3 split-container">

                </div>
            </div>
        </div>
    </div>
</asp:Content>




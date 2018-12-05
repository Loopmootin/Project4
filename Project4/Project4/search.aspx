<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Project4.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

        <asp:Repeater ID="RepeaterSearch" runat="server">
               <HeaderTemplate>
            <table class="show-pest">
                <div class="container">  
                    <div class="row justify-content-md-center">
        </HeaderTemplate>
            <ItemTemplate>
                
                 <div class="top-movie col-3 split-container">
                 <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>&movieyear=<%# Eval("movie_release") %>">Læs Mere</a>
                      <%# Eval("movie_name") %>
                      <%# Eval("movie_release") %>
                     <img src="<%# Eval("poster_url") %>" />
                </div>
              
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>
    </p>
        <p>
        </p>
    <p>
    </p>
       


    
</asp:Content>

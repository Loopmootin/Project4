<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Project4.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
               <HeaderTemplate>
            <table class="show-pest">
                <div class="container">  
                    <div class="row justify-content-md-center">
        </HeaderTemplate>
            <ItemTemplate>
                
                 <div class="top-movie col-3 split-container">
                 <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>">dope</a>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MoviesDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Movies] WHERE ([movie_name] LIKE '%' + @movie_name + '%')">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="movie_name" QueryStringField="searchresult" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
    </p>
       


    
</asp:Content>

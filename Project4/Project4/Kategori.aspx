<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="Project4.Kategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>FunKingFilm - Kategori</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
       <div class="category-selection">
           <div class="container">     
                        <div class="category-selection-category">
                            <a class="category-selector" href="Kategori.aspx?id=1"">Animation</a>
                            <a class="category-selector" href="Kategori.aspx?id=3">Thriller</a>
                            <a class="category-selector" href="Kategori.aspx?id=4">Science Fiction</a>
                            <a class="category-selector" href="Kategori.aspx?id=2">Action</a>
                        </div>
                        <hr />
                        <div class="category-selection-year">
                            <a class="category-selector" href="Kategori.aspx?movieyear=2010">2010</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2011">2011</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2012">2012</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2013">2013</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2014">2014</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2015">2015</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2016">2016</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2017">2017</a>
                            <a class="category-selector" href="Kategori.aspx?movieyear=2018">2018</a>
                        </div>
                    </div>
           </div>
    <asp:Repeater ID="RepeaterMovies" runat="server">
         <HeaderTemplate>
                <div class="container">                 
                    <div class="row justify-content-md-center">
        </HeaderTemplate>
            <ItemTemplate>
                
                 <div class="top-movie col-sm-12 col-md-3 split-container">
                  <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>&movieyear=<%# Eval("movie_release") %>">
                     <div class="title">
                      <span class="movielabel"><%# Eval("movie_name") %></span>
                      </div>
                      <div class="poster-image">
                     <img src="<%# Eval("poster_url") %>" alt="<%# Eval("poster_url") %>" /></a>
                     </div>
                </div>
              
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                </div>
            </FooterTemplate>
    </asp:Repeater>

    
    
</asp:Content>

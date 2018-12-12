<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project4.Index" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <title>Fucking Film - Forside</title>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="container">  

        <div class="commercialImage">
            <asp:Image ID="CommercialPoster" runat="server" />
        </div>

        <div class="justify-content-md-center">
            <h2 class="primary-header">Top film</h2>
                <asp:Repeater ID="RepeaterTop" runat="server">
                    <HeaderTemplate>
                               <div class="top-movies-container col-12 justify-content-around row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="top-movie col-sm-12 col-md-3 split-container">

                             <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>&movieyear=<%# Eval("movie_release") %>">
                      <div class="poster-image">
                     <img src="<%# Eval("poster_url") %>" alt="<%# Eval("poster_url") %>" /></a>
                     </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                
                       </div>
                    </FooterTemplate>
               </asp:Repeater>


            <h2>Artikler</h2>
            
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
              <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
              </ol>

              <div class="carousel-inner">
                  <div class="carousel-item active">
                      <img class="d-block w-100" src="..." alt="First slide">
                   </div>

                <asp:Repeater ID="RepeaterArticle" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="Pictures/avatar.jpg" alt="First slide">
                            <div class="carousel-caption d-none d-md-block">
                                <h5><%# Container.DataItem.ToString()  %></h5>
                                <p>...</p>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
               </asp:Repeater>

              </div>

              <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
              </a>
              <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
              </a>
            </div>
        </div>
    </div>
</asp:Content>




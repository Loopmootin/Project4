<%@ Page Title="FunKingFilm - Forside" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project4.Index" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="container">  
        <div class="justify-content-md-center">
            <div class="commercialImage">
                <asp:Image ID="CommercialPoster" AlternateText="Commerical Poster" runat="server" />
            </div>

            <h2 class="primary-header">Top film</h2>
                <asp:Repeater ID="RepeaterTop" runat="server">
                    <HeaderTemplate>
                               <div class="top-movies-container col-12 justify-content-around row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="top-movie col-sm-12 col-md-3 split-container">
                                
                             <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>&movieyear=<%# Eval("movie_release") %>">
                                 <span class="movielabel"><%# Eval("movie_name") %></span>
                      <div class="poster-image">

                     <img src="<%# Eval("poster_url") %>" alt="<%# Eval("poster_url") %>"/></a>
                     </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                
                       </div>
                    </FooterTemplate>
               </asp:Repeater>


            <h2 id="artikler" class="primary-header">Artikler</h2>
            
                <asp:Repeater ID="RepeaterArticle" runat="server">
                    <HeaderTemplate>
                        <div class="top-movies-container col-12 justify-content-around row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="top-movie col-sm-12 col-md-3 split-container">
                        <a  href="<%# DataBinder.Eval(Container.DataItem, "Url") %>" target="_blank">
                            <span class="articletitle"><%# DataBinder.Eval(Container.DataItem, "Title") %></span>
                            <img src="Pictures/NewYorkTimesReview.jpg" alt="" />                        
                        </a>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                         </div>
                    </FooterTemplate>
               </asp:Repeater>

            <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>

        </div>
    </div>
</asp:Content>




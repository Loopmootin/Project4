﻿<%@ Page Title="FunKingFilm - Søg" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Project4.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
        <asp:Label ID="LabelNoSearch" runat="server"></asp:Label>
        <asp:Repeater ID="RepeaterSearch" runat="server">
               <HeaderTemplate>
                <div class="container">  
                    
                    <div class="row justify-content-md-center">
        </HeaderTemplate>
            <ItemTemplate>
                
                 <div class="top-movie col-sm-12 col-md-3 split-container">
                 <a href="film.aspx?movie=<%# Eval("movie_name") %>&id=<%# Eval("movie_id") %>&movieyear=<%# Eval("movie_release") %>">
                      <span class="movielabel"><%# Eval("movie_name") %></span>
                     <img src="<%# Eval("poster_url") %>" alt="<%# Eval("poster_url") %>" />
                </a>
                </div>
              
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>       
</asp:Content>

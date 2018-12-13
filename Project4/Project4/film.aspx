<%@ Page Title="FunKingFilm - Film" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="film.aspx.cs" Inherits="Project4.film" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
 <div class="bg-wrapper">

    <div class="wrapper">
        <div class="container">
            <div class="film-container">
              <div class="row">
                <div class="col">
                   <h2><asp:Label ID="LabelMovieName" runat="server" Text="Label"></asp:Label></h2>
                    <span class="spanyear"><asp:Label ID="LabelYear" runat="server" Text="Label"></asp:Label></span>
                    <hr />
                    
                    <div class="infomation">
                       <span class="filminfo">Description</span>
                        <p><asp:Label Text="Description" ID="LabelPlot" runat="server" /></p>
                        <span class="filminfo">Actors</span>
                        <p><asp:Label Text="Actors" ID="LabelActors" runat="server" /></p>
                        <span class="filminfo">Rating</span>
                       <p><asp:Label Text="Rating" ID="LabelRatings" runat="server" /></p>
                        <span class="filminfo">Rated</span>
                       <p><asp:Label Text="Rated" ID="LabelPG" runat="server" /></p>

                    </div>
               </div>
                <div class="col">
                    <div class="film-image">
                    <asp:Image ID="ImagePoster" runat="server" alt="" />
                    </div>
                </div>
              </div>
            </div>
        </div>
    </div>

     </div>
</asp:Content>

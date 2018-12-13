using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Net;
using System.IO;

using System.Data;
using System.Data.SqlClient;
using Project4.Utilities;

namespace Project4
{
    public partial class film : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("index.aspx");
            }

            WebClient client = new WebClient();
            string movieresult = Request.QueryString["movie"];
            string movieyear = Request.QueryString["movieyear"];
            string movieid = Request.QueryString["id"];

            Utilities.MovieDetails newdetail = new MovieDetails(movieid, movieresult, movieyear);

            LabelMovieName.Text = movieresult;
            LabelYear.Text = movieyear;
              newdetail.Clicked(movieid);
              ImagePoster.ImageUrl = newdetail.image;
              LabelActors.Text = newdetail.actor;
              LabelPlot.Text = newdetail.plot;
              LabelRatings.Text = newdetail.rating;
              LabelPG.Text = newdetail.pgrated;
           
        }
    }
}
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
        private string[] mysplit;

        protected void Page_Load(object sender, EventArgs e)
        {
            // string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            // string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            WebClient client = new WebClient();
            string movieresult = Request.QueryString["movie"];
            string movieyear = Request.QueryString["movieyear"];
            string movieid = Request.QueryString["id"];

            Utilities.MovieDetails details = new MovieDetails();
            details.Clicked(movieid);

            Utilities.MovieDetails newdetail = new MovieDetails(movieid, movieresult, movieyear);



            ImagePoster.ImageUrl = newdetail.Imageposter(movieid);
            LabelActors.Text = newdetail.Actors();
            LabelPlot.Text = newdetail.ThePlot();
            LabelRatings.Text = newdetail.Ratings();
            LabelPG.Text = newdetail.PGrated();
        }
    }
}
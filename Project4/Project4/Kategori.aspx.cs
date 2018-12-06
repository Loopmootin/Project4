using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace Project4
{
    public partial class Kategori : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Utility AllVideos = new Utility();
                AllVideos.createCommand("SELECT TOP 80 * FROM Movie", CommandType.Text);
                RepeaterMovies.DataSource = AllVideos.executeCmd();
                RepeaterMovies.DataBind();
            }
                MovieYear();
                CategoryMovies();


            
       
   

        }

        public void CategoryMovies()
        {
            Utility connect = new Utility();

            try
            {
                connect.createCommand("CategorySelection", CommandType.StoredProcedure);
                connect.AddParameter("@genre_id", SqlDbType.Int).Value = Request.QueryString["id"];

                RepeaterMovies.DataSource = connect.executeCmd();
                RepeaterMovies.DataBind();
            }
            catch (Exception ex)
            {
               // LabelMessage.Text = ex.Message;
            }
        }

        public void MovieYear()
        {
            Utility connect = new Utility();

            try
            {
                connect.createCommand("SELECT Top 40 * FROM movie where movie_release = @movie_release", CommandType.Text);
                connect.AddParameter("@movie_release", SqlDbType.Int).Value = Request.QueryString["movieyear"];
                RepeaterMovies.DataSource = connect.executeCmd();
                RepeaterMovies.DataBind();

            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }


        }

    }
}
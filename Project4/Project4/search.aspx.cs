using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

using System.Data;
using System.Data.SqlClient;

namespace Project4
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SearchedMovies();
            if (Request.QueryString["searchresult"] == null)
            {
                Response.Redirect("Kategori.aspx");
            }
        }

        public void SearchedMovies()
        {
            Utility connection = new Utility();

            try
            {

                connection.createCommand("SELECT * FROM [Movie] WHERE ([movie_name] LIKE '%' + @movie_name + '%')", CommandType.Text);
                connection.AddParameter("@movie_name", SqlDbType.VarChar).Value = Request.QueryString["searchresult"];

                RepeaterSearch.DataSource = connection.executeCmd();
                if(RepeaterSearch.DataSource == null)
                {
                    LabelNoSearch.Text = "No Movie Found";
                }
                RepeaterSearch.DataBind();
            }
            catch (Exception ex)
            {
               // LabelMessage.Text = ex.Message;
            }
        }
    }
}
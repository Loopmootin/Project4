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
        }

        public void SearchedMovies()
        {
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = MoviesDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;


            try
            {
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT * FROM [Movies] WHERE ([movie_name] LIKE '%' + @movie_name + '%')";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@movie_name", SqlDbType.VarChar).Value = Request.QueryString["searchresult"];

                rdr = cmd.ExecuteReader();

                RepeaterSearch.DataSource = rdr;
                RepeaterSearch.DataBind();


            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
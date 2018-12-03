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

        CategoryMovies();

        }

        public void CategoryMovies()
        {
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = MoviesDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;


            try
            {
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MoviesDatabase";

                cmd.Parameters.Add("@genre_id", SqlDbType.Int).Value = Request.QueryString["id"];

                rdr = cmd.ExecuteReader();

                RepeaterMovies.DataSource = rdr;
                RepeaterMovies.DataBind();


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
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
                LabelMessage.Text = ex.Message;
            }

        }
    }
}
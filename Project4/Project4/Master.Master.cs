using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Project4
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnMovieSearch_Click(object sender, EventArgs e)
        {

            string searchinput = search.Text;

            Response.Redirect("search.aspx?searchresult=" + searchinput);

        }

        protected void search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
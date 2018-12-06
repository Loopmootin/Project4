using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Data;
using System.Net;

using System.Drawing;
using System.Data.SqlClient;
using Project4.Utilities;

namespace Project4
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if the XML uses a namespace, the XSLT must refer to this namespace
            string sourcefile = Server.MapPath("xml/Commercials.xml");
            string xslfile = Server.MapPath("xml/CommercialsXSLT.xslt");
            string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");

            FileStream fs = new FileStream(destinationfile, FileMode.Create);
            XslCompiledTransform xct = new XslCompiledTransform();

            xct.Load(xslfile);
            xct.Transform(sourcefile, null, fs);
            fs.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

            GridViewCommercials.DataSource = dt;
            GridViewCommercials.DataBind();



            //SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = MovieDatabase");
           /* SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            SqlDataAdapter da = null;
            DataSet dsnew = null;
            DataTable dtnew = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from Movie";
            string sqlupd = "update Movie set movie.poster_url = @poster_url Where movie.movie_id = @movie_id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MoviePoster");

                dt = ds.Tables["MoviePoster"];

                int requestid = Convert.ToInt32(Request.QueryString["id"]);

                dt.Rows[requestid]["movie_id"] = Request.QueryString["id"];
                dt.Rows[requestid]["poster_url"] = ImagePoster.ImageUrl;



                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id");
                cmd.Parameters.Add("@poster_url", SqlDbType.Text, 255, "poster_url");


                da.UpdateCommand = cmd;
                da.Update(ds, "MoviePoster");
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

    */
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
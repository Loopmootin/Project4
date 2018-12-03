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
    public partial class film : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";
            string movieresult = Request.QueryString["movie"];
            string movieid = Request.QueryString["id"];


            result = client.DownloadString("http://www.omdbapi.com/?s=" + movieresult + "&apikey=" + Token.token + "");

            string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);


            if (mysplit[1] != "False")
            {
                LabelMessage.Text = mysplit.Length.ToString();
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        ImagePoster.ImageUrl = mysplit[++i];

                        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-6CQP77U; integrated security = true; database = MoviesDatabase");
                        SqlDataAdapter da = null;
                        DataSet ds = null;
                        DataTable dt = null;
                        SqlCommand cmd = null;
                        string sqlsel = "select * from Movies";
                        string sqlupd = "update Movies set movies.poster_url = @poster_url Where movies.movie_id = @movie_id";

                        try
                        {
                            da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand(sqlsel, conn);

                            ds = new DataSet();
                            da.Fill(ds, "MoviePoster");

                            dt = ds.Tables["MoviePoster"];

                            Labeltest.Text = Request.QueryString["id"];

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
                        break;
                    }
                }
                LabelResult.Text = "Ratings ";
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Ratings")
                    {
                        while (mysplit[++i] == "Source")
                        {
                            if (mysplit[i - 1] != "Ratings") LabelResult.Text += "; ";
                            LabelResult.Text += mysplit[i + 3] + " From " + mysplit[i + 1];
                        }
                        i = i + 3;
                        break;
                    }

                }
            }
            else
            {
                LabelMessage.Text = "Movie Not Found";
                ImagePoster.ImageUrl = "~/MyFiles/gaurdiansofthegolaxsi.jpg";
                LabelResult.Text = "Empty";
            }
        }
    }
}
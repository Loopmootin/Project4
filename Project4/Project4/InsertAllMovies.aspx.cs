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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Det tager nogle minutter at kører igennem. 
            allmovies();
        }

        public void allmovies()
        {
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U;  integrated security = true; database = MovieDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                string sqlcheck = "SELECT * From movie";
                SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                using (rdr = cmd.ExecuteReader())
                {
                    
                    while (rdr.Read())
                    {
                        string result = "";
                        WebClient client = new WebClient();
                        result = client.DownloadString("http://www.omdbapi.com/?t=" + rdr.GetString(1) + "&y=" + rdr.GetInt32(2) + "&apikey=" + Token.token + "");
                            string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                            string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                            if (mysplit[1] != "False")
                            {
                                string imageposter = "";
                                for (int i = 0; i < mysplit.Length; i++)
                                {
                                    if (mysplit[i] == "Poster")
                                    {
                                        imageposter = mysplit[++i];
                                        Utilities.MovieDetails movie = new Utilities.MovieDetails();
                                        string movie_id = Convert.ToString(rdr.GetInt32(0));
                                        movie.SavePoster(imageposter, movie_id);
                                        break;
                                    }
                                }
                            }
                    }
                    testlabel.Text = rdr.GetInt32(0).ToString();
                }
            }
            catch (Exception ex)
            {
                 testlabel.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
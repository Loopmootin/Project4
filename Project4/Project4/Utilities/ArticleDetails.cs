using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

using System.Data;
using System.Data.SqlClient;

namespace Project4.Utilities
{
    public class ArticleDetails
    {

        public void TopArticles()
        {
            //Tobtob
            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U;  integrated security = true; database = MovieDatabase");

            //Chrischris
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = CHRISTOFFER-PC; integrated security = true; database = MovieDatabase");


            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                string sqlcheck = "SELECT TOP 8 * FROM movie, Clicks WHERE movie.movie_id = Clicks.movie_id ORDER BY click desc";
                SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                using (rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        string articleresult = rdr.GetString(1);
                        string result = "";
                        WebClient client = new WebClient();
                        result = client.DownloadString("https://api.nytimes.com/svc/movies/v2/reviews/search.json?api-key=" + ArticleToken.articletoken + "&query=" + articleresult);
                        string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                        string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                        if (mysplit[1] != "False")
                        {
                            string articleurl = "";
                            for (int i = 0; i < mysplit.Length; i++)
                            {
                                if (mysplit[i] == "url")
                                {
                                    articleurl = mysplit[++i];
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
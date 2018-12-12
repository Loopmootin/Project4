using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Data.SqlClient;
using Project4.Utilities;

namespace Project4
{
    public partial class Index : System.Web.UI.Page
    {
        private string[] articlesplit;

        protected void Page_Load(object sender, EventArgs e)
        {
            // if the XML uses a namespace, the XSLT must refer to this namespace
            string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];
                
            int viewcounter = 0;
            int randomCommercial = (new Random()).Next(0, dt.Rows.Count);

            viewcounter = viewcounter + Convert.ToInt32(ds.Tables[0].Rows[randomCommercial][3]) + 1;

            dt.Rows[randomCommercial][3] = viewcounter;

            CommercialPoster.ImageUrl = "pictures/" + Convert.ToString(dt.Rows[randomCommercial][1]);


            ds.WriteXml(Server.MapPath("xml/CommercialsTransformed.xml"));

            TopArticles();

            Utility connect = new Utility();

            try
            {
                connect.createCommand("SELECT TOP 8 * FROM movie, Clicks WHERE movie.movie_id = Clicks.movie_id ORDER BY click desc", CommandType.Text);
                RepeaterTop.DataSource = connect.executeCmd();
                RepeaterTop.DataBind();

            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }


            
        }
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
                    List<string> articleurl = new List<string>();
                    while (rdr.Read())
                    {
                        string articleresult = rdr.GetString(1);
                        
                        string result;
                        WebClient client = new WebClient();
                        result = client.DownloadString("https://api.nytimes.com/svc/movies/v2/reviews/search.json?api-key=" + ArticleToken.articletoken + "&query=" + articleresult);
                        string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                        string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                        if (mysplit[1] != "False")
                        {

                            for (int i = 0; i < mysplit.Length; i++)
                            {
                                if (mysplit[i] == "url")
                                {
                                    articleurl.Add(mysplit[++i]);

                                }

                            }
                        }

                    }
                    RepeaterArticle.DataSource = articleurl;
                    RepeaterArticle.DataBind();
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
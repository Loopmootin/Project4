using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Net;
using System.IO;

using System.Data;
using System.Data.SqlClient;
using Project4.Utilities;

namespace Project4
{
    public partial class film : System.Web.UI.Page
    {
        private string[] mysplit;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities.MovieDetails newdetail = new MovieDetails();
            WebClient client = new WebClient();
            string movieresult = Request.QueryString["movie"];
            string movieyear = Request.QueryString["movieyear"];
            string movieid = Request.QueryString["id"];

            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U;  integrated security = true; database = MovieDatabase");
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                string sqlcheck = "SELECT * FROM clicks WHERE movie_id = @movie_id AND date = @date";
                SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id").Value = Request.QueryString["id"];
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-dd-MM");
                int newvalue = 0;
                using (rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        newvalue = rdr.GetInt32(3);
                        newvalue += 1;
                        // Labeltestlabel2.Text = newvalue.ToString();
                        
                    }
                } 
                if(newvalue != 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Clicks set click = @click Where movie_id = @movie_ids AND date = @date;";
                    cmd.Parameters.Add("@movie_ids", SqlDbType.Int, 50, "movie_id").Value = Request.QueryString["id"];
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-dd-MM");
                    cmd.Parameters.Add("@click", SqlDbType.Int).Value = newvalue;
                    cmd.ExecuteNonQuery();
                    // Labeltestlabel2.Text = "Clicks opdateret";

                } else
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO clicks(movie_id, date, click) VALUES(@movie_id, @date, 1)";
                    cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id").Value = Request.QueryString["id"];
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-dd-MM");
                    cmd.ExecuteNonQuery();
                    // LabelDATE.Text = DateTime.Now.ToString("yyyy-dd-MM");
                }
            }
            catch (Exception ex)
            {
                LabelDATE.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            newdetail.GetDownloadString(movieresult, movieyear);
            mysplit = newdetail.thesplit();

           // string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
           // string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            if (mysplit[1] != "False")
            {
                LabelMessage.Text = mysplit.Length.ToString();
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        ImagePoster.ImageUrl = mysplit[++i];

                        // SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
                        SqlDataAdapter da = null;
                        DataSet ds = null;
                        DataTable dt = null;
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



                            SqlCommand cmd = new SqlCommand(sqlupd, conn);
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
                LabelRating.Text = "Ratings ";
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Ratings")
                    {
                        while (mysplit[++i] == "Source")
                        {
                            if (mysplit[i - 1] != "Ratings") LabelRating.Text += "; ";
                            LabelRating.Text += mysplit[i + 3] + " From " + mysplit[i + 1];
                        }
                        i = i + 3;
                        break;
                    }
                }
                LabelPlot.Text = "Plot : ";
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Plot")
                    {
                        LabelPlot.Text = mysplit[++i];
                        break;
                    }
                }

                //LabelChildRating.Text = "Rated : ";
                //newdetail.Detail(mysplit, "Rated", LabelChildRating.Text);


                LabelActors.Text = "Actors : ";
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Actors")
                    {
                        LabelActors.Text = mysplit[++i];
                        break;
                    }
                }
            }
            else
            {
                LabelMessage.Text = "Movie Not Found";
                ImagePoster.ImageUrl = "~/MyFiles/gaurdiansofthegolaxsi.jpg";
                LabelRating.Text = "Empty";
            }
        }
    }
}
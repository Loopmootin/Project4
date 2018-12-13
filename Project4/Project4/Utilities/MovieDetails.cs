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
using System.Reflection.Emit;

namespace Project4.Utilities
{
    public class MovieDetails : System.Web.UI.Page
    {
        public string movieresult;
        public string movieyear;
        public string movieid;
        public static string[] mysplit;

        public readonly string plot;
        public readonly string image;
        public readonly string actor;
        public readonly string rating;
        public readonly string pgrated;

        public string result = "";

        public string[] thesplit()
        {
            string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            return mysplit;
        }

        public MovieDetails()
        {

        }

        public void Clicked(string movie_id)
        {
            //Tobtob
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U;  integrated security = true; database = MovieDatabase");

            //Chrischris
            //SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = CHRISTOFFER-PC; integrated security = true; database = MovieDatabase");

            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                string sqlcheck = "SELECT * FROM Clicks WHERE movie_id = @movie_id AND date = @date";
                SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id").Value = movie_id;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                int newvalue = 0;
                using (rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        newvalue = rdr.GetInt32(3);
                        newvalue += 1;
                        //  LabelNewValue.Text = newvalue.ToString();

                    }
                }
                if (newvalue != 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Clicks set Click = @click Where movie_id = @movie_id AND date = @date;";
                    cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id").Value = movie_id;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                    cmd.Parameters.Add("@click", SqlDbType.Int).Value = newvalue;
                    cmd.ExecuteNonQuery();
                    // LabelUpdate.Text = "Clicks opdateret";

                }
                else
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Clicks(movie_id, date, click) VALUES(@movie_id, @date, 1)";
                    cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id").Value = movie_id;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                    cmd.ExecuteNonQuery();
                    // LabelInsert.Text = DateTime.Now.ToString("yyyy-dd-MM");
                }
            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void SavePoster(string ImagePoster, string movie_id)
        {

            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from Movie";
            string sqlupd = "update Movie set movie.poster_url = @poster_url Where movie.movie_id = @movie_id";
            //Tobtob
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-6CQP77U;  integrated security = true; database = MovieDatabase");

            //Chrischris
            //SqlConnection conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            // SqlConnection conn = new SqlConnection(@"data source = CHRISTOFFER-PC; integrated security = true; database = MovieDatabase");

            conn.Open();
            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MoviePoster");

                dt = ds.Tables["MoviePoster"];

                int requestid = Convert.ToInt32(movie_id);

                dt.Rows[requestid]["movie_id"] = movie_id;
                dt.Rows[requestid]["poster_url"] = ImagePoster;



                SqlCommand cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "movie_id");
                cmd.Parameters.Add("@poster_url", SqlDbType.Text, 255, "poster_url");


                da.UpdateCommand = cmd;
                da.Update(ds, "MoviePoster");
            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public MovieDetails(string movie_id, string movieresult, string movieyear)
        {
            WebClient client = new WebClient();
            result = client.DownloadString("http://www.omdbapi.com/?t=" + movieresult + "&y=" + movieyear + "&apikey=" + Token.token + "");
            plot = ThePlot();
            image = Imageposter(movie_id);
            actor = Actors();
            rating = Ratings();
            pgrated = PGrated();
        }


        private string Imageposter(string movieid)
        {
            string imageposter = "";
            mysplit = thesplit();
            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        imageposter = mysplit[++i];
                        SavePoster(imageposter, movieid);
                        break;
                    }
                }
            }
            return imageposter;
        }

        private string ThePlot()
        {
            string plot = "";
            mysplit = thesplit();
            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Plot")
                    {
                        plot = mysplit[++i];
                        break;
                    }
                }
            }
            return plot;
        }

        private string Actors()
        {
            string actor = "";
            mysplit = thesplit();
            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Actors")
                    {
                        actor = mysplit[++i];
                        break;
                    }
                }
            }
            return actor;
        }

        private string Ratings()
        {
            string rating = "";
            mysplit = thesplit();
            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Ratings")
                    {
                        while (mysplit[++i] == "Source")
                        {
                            if (mysplit[i - 1] != "Ratings") rating += "; ";
                            rating += mysplit[i + 3] + " From " + mysplit[i + 1];
                        }
                        i = i + 3;
                        break;
                    }
                }
            }
            return rating;
        }

        private string PGrated()
        {
            string rated = "";
            mysplit = thesplit();
            if (mysplit[1] != "False")
            {

                    for (int i = 0; i < mysplit.Length; i++)
                    {
                        if (mysplit[i] == "Rated")
                        {
                            rated = mysplit[++i];
                            break;
                        }
                    }
            }
            return rated;
        }

    }

}

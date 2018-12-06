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
    public class MovieDetails : System.Web.UI.Page
    {
        private string movie_name;
        private int movie_release;
        private string poster_url;
        private string description;
        private string child_rating;
        private string rating;

        public string movieresult;
        public string movieyear;
        public string movieid;
        public static string[] mysplit;

        WebClient client; 
        string result = "";

        public string GetDownloadString(string movieresult, string movieyear)
        {
            WebClient client = new WebClient();
            result = client.DownloadString("http://www.omdbapi.com/?t=" + movieresult + "&y=" + movieyear + "&apikey=" + Token.token + "");
            return result;
        }

        public string[] thesplit()
        {
            string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            return mysplit;
        }

     
    }
}

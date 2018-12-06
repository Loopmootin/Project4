using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;

namespace Project4.Utilities
{
    public class ArticleDetails
    {
        public string articleresult;
        public static string[] articlesplit;

        WebClient client;
        string result = "";

        public string GetDownloadArticleString(string articleresult)
        {
            WebClient client = new WebClient();
            result = client.DownloadString("https://api.nytimes.com/svc/movies/v2/reviews/search.json?api-key=" + ArticleToken.articletoken + "&query=" + articleresult);
            return result;
        }

        public string[] splitarticle()
        {
            string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] articlesplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            return articlesplit;
        }
    }
}
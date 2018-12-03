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

namespace Project4
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usersearch = Request.QueryString["searchresult"];






            WebClient client = new WebClient();
            string result = " ";

            

            result = client.DownloadString("http://www.omdbapi.com/?s=" + usersearch + "&apikey=" + Token.token + "");

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
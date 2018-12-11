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
<<<<<<< HEAD

            

            // if the XML uses a namespace, the XSLT must refer to this namespace
            string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

            int viewcounter = 0;
            int randomCommercial = (new Random()).Next(0, dt.Rows.Count);

            viewcounter = viewcounter + Convert.ToInt32(ds.Tables[0].Rows[0][3]) + 1;

            dt.Rows[randomCommercial][3] = viewcounter;

            GridView1.DataSource = dt.Rows;
            GridView1.DataBind();
=======
             //if the XML uses a namespace, the XSLT must refer to this namespace
             string sourcefile = Server.MapPath("Commercials.xml");
             string xslfile = Server.MapPath("CommercialsXSLT.xslt");
             string destinationfile = Server.MapPath("CommercialsTransformed.xml");

             FileStream fs = new FileStream(destinationfile, FileMode.Create);
             XslCompiledTransform xct = new XslCompiledTransform();

             xct.Load(xslfile);
             xct.Transform(sourcefile, null, fs);
             fs.Close();

                
             //DataSet ds = new DataSet();
             //ds.ReadXml(destinationfile);
             //DataTable dt = ds.Tables[0];
>>>>>>> 22c6e07c5017df7e1bd38ed206cce9f881159778

            ds.WriteXml(Server.MapPath("xml/CommercialsTransformed.xml"));



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

            
            string articleresult = "Avatar";


            Utilities.ArticleDetails newarticle = new ArticleDetails();

            newarticle.GetDownloadArticleString(articleresult);
            articlesplit = newarticle.splitarticle();

            LabelArticle.Text = articlesplit.Length.ToString();



  
            if (articlesplit[1] != null)
            {
                LabelArticle.Text = articlesplit.Length.ToString();
                for (int i = 0; i < articlesplit.Length; i++)
                {
                    if (articlesplit[i] == "url")
                    {
                        LabelArticle.Text = articlesplit[++i];
                    }
                }
            }






            /*Utility connectArticle = new Utility();

            try
            {
                connectArticle.createCommand("SELECT TOP 8 * FROM movie, Clicks WHERE movie.movie_id = Clicks.movie_id ORDER BY click desc", CommandType.Text);
                RepeaterArticles.DataSource = connectArticle.executeCmd();
                RepeaterArticles.DataBind();

            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }*/

        }
    }
}
﻿using System;
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
            //string sourcefile = Server.MapPath("xml/Commercials.xml");
            //string xslfile = Server.MapPath("xml/CommercialsXSLT.xslt");
            //string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");

            //FileStream fs = new FileStream(destinationfile, FileMode.Create);
            //XslCompiledTransform xct = new XslCompiledTransform();

            //xct.Load(xslfile);
            //xct.Transform(sourcefile, null, fs);
            //fs.Close();

            //DataSet ds = new DataSet();
            //ds.ReadXml(destinationfile);
            //DataTable dt = ds.Tables[0];




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
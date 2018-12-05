using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Data;
using System.Net;

namespace Project4
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if the XML uses a namespace, the XSLT must refer to this namespace
            string sourcefile = Server.MapPath("xml/Commercials.xml");
            string xslfile = Server.MapPath("xml/CommercialsXSLT.xslt");
            string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");

            FileStream fs = new FileStream(destinationfile, FileMode.Create);
            XslCompiledTransform xct = new XslCompiledTransform();

            xct.Load(xslfile);
            xct.Transform(sourcefile, null, fs);
            fs.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

            Random r = new Random();
            while (dt.Rows.Count > 1)
            {
                int j = r.Next(0, dt.Rows.Count);
                dt.Rows.RemoveAt(j);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}
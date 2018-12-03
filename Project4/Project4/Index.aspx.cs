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
            string xslhtmlfile = Server.MapPath("xml/CommercialToHTML.xslt");

            string destinationfile = Server.MapPath("xml/CommercialsTransformed.xml");
            string destinationhtmlfile = Server.MapPath("xml/CommercialsTransformed.html");

            FileStream fshtml = new FileStream(destinationhtmlfile, FileMode.Create);
            XslCompiledTransform xcthtml = new XslCompiledTransform();

            xcthtml.Load(xslhtmlfile);
            xcthtml.Transform(sourcefile, null, fshtml);
            fshtml.Close();

            WebClient cl = new WebClient();
            LiteralHTML.Text = cl.DownloadString(destinationhtmlfile);
        }
    }
}
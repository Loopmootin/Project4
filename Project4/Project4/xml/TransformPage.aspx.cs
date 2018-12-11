using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Xml.Xsl;
using System.Data;


namespace Project4.xml
{
    public partial class TransformPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if the XML uses a namespace, the XSLT must refer to this namespace
            string sourcefile = Server.MapPath("Commercials.xml");
            string xslfile = Server.MapPath("CommercialsXSLT.xslt");
            string destinationfile = Server.MapPath("CommercialsTransformed.xml");

            FileStream fs = new FileStream(destinationfile, FileMode.Create);
            XslCompiledTransform xct = new XslCompiledTransform();

            xct.Load(xslfile);
            xct.Transform(sourcefile, null, fs);
            fs.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

        }
    }
}
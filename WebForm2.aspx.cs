using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drumcenterworld
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                

                System.Text.StringBuilder sb = new StringBuilder();
                //Table start.
                sb.Append("asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"server\">");
                sb.Append("</ asp:Content >");
                sb.Append("< asp:Content ID = \"Content2\" ContentPlaceHolderID = \"ContentPlaceHolder1\" runat = \"server\">");
//sb.Append("< asp:FileUpload ID = \"FileUpload1\" runat = \"server\" /">");


  //  <

//</ asp:Content >';

            }
        }
    }
    }

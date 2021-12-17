using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace drumcenterworld
{
    
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Convert.ToInt32(System.Web.HttpContext.Current.Session["Role"]);
            if (role == 1)
            {
                add.Visible = false;
                btnUpload.Visible=false;
            }
            con.Open();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
             if (FileUpload1.HasFile)
            {
                string fileExtension=System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".JPG")
                {
                    lblMessage.Text = "Please select a .jpg file";
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Images/" + FileUpload1.FileName));

                    SqlCommand cmd = new SqlCommand("insert into Product(Category, Description, PhotoLink, AvailableQty, Price) values('" +
                DropDownCategory.SelectedValue + "','" +
                TextBoxDescription.Text + "','" +
                "~/Images/" + FileUpload1.FileName + "','" +
                Convert.ToInt16(TextBoxAvailableQty.Text) + "','" +
                Convert.ToDecimal(TextBoxPrice.Text) +

                "'" + ")", con);
                    int Rows = cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = "File Uploaded";
                }
            }
            else
            {
                lblMessage.Text = "Please Select a file";
            }
        }
    }
}
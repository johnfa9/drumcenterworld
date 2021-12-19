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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            int role = Convert.ToInt32(System.Web.HttpContext.Current.Session["Role"]);
            if (role != 2)
            {
                add.Visible = false;
                btnUpload.Visible = false;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            
            
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
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
                        Convert.ToDecimal(TextBoxPrice.Text) + "'" + ")", con);

                            con.Open();
                            int Rows = cmd.ExecuteNonQuery();
                            con.Close();

                            Response.Write("<script language='javascript'>alert('Product Added Successfully !!!!!');</script>");

                            lblMessage.Text = "File Uploaded";
                            lblMessage.DataBind();

                        }
                    }
                    else
                    {
                  
                            lblMessage.Text = "Please Select a file";

                        //Response.Redirect("~/Admin/AddProduct.aspx");
                    }
                }
                catch (Exception)
                { }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
               
            }
        }
    
}
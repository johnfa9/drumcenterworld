using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace drumcenterworld
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            con.Open();
        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Login User
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users left join role on Role.RoleId = Users.RoleId where " +
               "Email='" + TextBoxEmail.Text + "' and " +
               "UserPassword='" + TextBoxPassword.Text + "'", con); ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Login Successfull";
                //Save the role for a successful login
                int RoleId = dt.Rows[0]["RoleId"] != null ? Convert.ToInt32(dt.Rows[0]["RoleId"]) : -1;
                var menu = Page.Master.FindControl("Menu1") as Menu;
                if (RoleId == 1)
                {
                    //menu.Items.Add(new MenuItem("Tab1", "5"));
                    //MenuItem mnuItem = menu.FindItem("Add Product");
                  // menu.Items.RemoveAt(2);
                   // menu.Items.RemoveAt(1);
                    //menu.Items.Add(4);
                }
                
                System.Web.HttpContext.Current.Session["Role"] = dt.Rows[0]["RoleID"];
                Response.Redirect("~/Products.aspx");
            }
            else
            {
                Label1.Text = "Login Unsuccessfull";
            }
        }
    }
}
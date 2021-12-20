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
            string qry = string.Empty;

            if (RadioButton1.Checked == true)   //Admin
            {
                
                qry = "Select UserName,Password, AdminUsers.RoleID from AdminUsers " +
                    "left join role on Role.RoleId = AdminUsers.RoleId where " +
              "UserName='" + TextBoxEmail.Text + "' and " +
              "Password='" + TextBoxPassword.Text + "' and IsAcive=1";
            }
            else
            {
               
                qry = "Select UserID, Email , UserPassword, Role.RoleID from Users left " +
                    "join role on Role.RoleId = Users.RoleId where " +
              "Email='" + TextBoxEmail.Text + "' and " +
              "UserPassword='" + TextBoxPassword.Text + "'";

            }
                
            //Login User
            SqlDataAdapter da = new SqlDataAdapter(qry, con); ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Login Successfull";
                //Save the role for a successful login
                int RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                Session["UserInfo"] = TextBoxEmail.Text;
                System.Web.HttpContext.Current.Session["Role"] = dt.Rows[0]["RoleID"];
                Session["RoleID"] = dt.Rows[0]["RoleID"].ToString();
                var menu = Page.Master.FindControl("Menu1") as Menu;
                if (RoleId == 1)
                {
                    Session["UserID"] = dt.Rows[0]["UserID"];
                    Response.Redirect("~/Products.aspx");
                }
                else
                {
                    Response.Redirect("~/Admin/ModifyDeleteProduct.aspx");
                }
            }
            else
            {
                TextBoxEmail.Text = "";
                TextBoxPassword.Text = "";
                Label1.Text = "Login Unsuccessfull";
            }
        }
    }
}
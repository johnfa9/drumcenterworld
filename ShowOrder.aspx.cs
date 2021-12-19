using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drumcenterworld
{
    public partial class ShowOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("Login.aspx");
                }



                int custID = Convert.ToInt32(Session["UserID"]);
                if (!IsPostBack)
                {
                    SqlDataSource SqlDataSource1 = new SqlDataSource();
                    SqlDataSource1.ID = "SqlDataSource1";
                    this.Page.Controls.Add(SqlDataSource1);
                    SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString;
                    SqlDataSource1.SelectCommand = "SELECT users.LastName, customerorder.OrderID,items.ProductID, product.Description, items.OrderQty, product.Price, items.OrderQty* product.Price as Total From Users, customerorder, items, product where Users.UserID = customerorder.CustomerID and Users.UserID = " + custID + " and customerorder.OrderID = items.OrderID and items.ProductID = product.ProductID Order by customerorder.OrderID;";
                    GridView1.DataSource = SqlDataSource1;
                    GridView1.DataBind();
                    GridView1.ShowHeaderWhenEmpty = true;
                }
            }
        }
    }
}
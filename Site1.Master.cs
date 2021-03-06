using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drumcenterworld
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(System.Web.HttpContext.Current.Session["Role"]);
                if (role == 2)
                {
                    //Menu1.Items.RemoveAt(4);
                    // Menu1.Items.Add(new MenuItem)
                    {
                        //    TextAlign = Text = "Administer web site",
                        //NavigateUrl = "~/admin.aspx"
                        Menu1.Items.RemoveAt(2);
                        Menu1.Items.RemoveAt(1);
                        Menu1.Items.Add(new MenuItem("Add Product"));
                        Menu1.FindItem("Add Product").NavigateUrl = "~/Admin/AddProduct.aspx";
                        Menu1.Items.Add(new MenuItem("Modify Product"));
                        Menu1.FindItem("Modify Product").NavigateUrl = "~/Admin/ModifyDeleteProduct.aspx";
                        Menu1.Items.Add(new MenuItem("Logout"));
                        Menu1.FindItem("Logout").NavigateUrl = "~/Logout.aspx";
                      
                    }
                }
                else if (role == 1)
                {
                    Menu1.Items.RemoveAt(2);
                    Menu1.Items.RemoveAt(1);
                    Menu1.Items.Add(new MenuItem("View Products"));
                    Menu1.FindItem("View Products").NavigateUrl = "~/Products.aspx";

                    Menu1.Items.Add(new MenuItem("View Orders"));
                    Menu1.FindItem("View Orders").NavigateUrl = "~/ShowOrder.aspx";

                    Menu1.Items.Add(new MenuItem("Logout"));
                    Menu1.FindItem("Logout").NavigateUrl = "~/Logout.aspx";
                 
                }

                else 
                
                {
                    MenuItemCollection menuItems = Menu1.Items;
                    MenuItem menuItem = new MenuItem();

                    foreach (MenuItem item in menuItems)
                    {
                        if (item.Text!="Home")
                        menuItems.Remove(menuItem);
                    }
                    
                }
                   
            }
            
        }
    }
}
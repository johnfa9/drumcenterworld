using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using drumcenterworld.Models;

namespace drumcenterworld
{
    public partial class Products : System.Web.UI.Page
    {
        SortedList<int, string> lstItems = new SortedList<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("Login.aspx");
                }  
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Cart")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));

                //get row from SqlDataSource based on value in drop-down list
                DataView productsTable = (DataView)
                 SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                productsTable.RowFilter =
                    "ProductID = '" + e.CommandArgument + "'";
                DataRowView row = productsTable[0];

                //create a new product object and load with data from row

                Product p = new Product();
                p.ProductID = row["ProductID"].ToString();
                p.Category = row["Category"].ToString();
                p.Description = row["Description"].ToString();

                p.AvailableQty = (Int32)row["AvailableQty"];
                p.Price = (decimal)row["Price"];

                if (Page.IsValid)
                {
                    //get cart from session and selected item from cart
                    CartItemList cart = CartItemList.GetCart();
                    CartItem cartItem = cart[p.ProductID];

                    //if item isn’t in cart, add it; otherwise, increase its quantity
                    if (cartItem == null)
                    {
                        cart.AddItem(p,
                        Convert.ToInt32(list.SelectedItem.ToString()));
                    }
                    else
                    {
                        cartItem.AddQuantity(Convert.ToInt32(list.SelectedItem.ToString()));
                    }
                    lstItems.Add(Convert.ToInt32(p.ProductID),(Convert.ToInt32(list.SelectedItem.ToString()) * 
                        p.Price).ToString());
                    Response.Redirect("ShoppingCart.aspx", false);
                }


            }

        }

       
    }
}

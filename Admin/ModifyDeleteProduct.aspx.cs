using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drumcenterworld.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace drumcenterworld.Admin
{
    public partial class ModifyDeleteProduct : System.Web.UI.Page
    {
        SortedList<int, string> lstItems = new SortedList<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Session["addItem"] = "true";
            if (e.CommandName == "DelProduct")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));

                TextBox Cat = (TextBox)(e.Item.FindControl("TextBox1"));
                TextBox Desc= (TextBox) (e.Item.FindControl("TextBox4"));
                TextBox Price = (TextBox)(e.Item.FindControl("TextBox3"));



                //get row from SqlDataSource based on value in drop-down list
               // DataView productsTable = (DataView)


                // SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                //productsTable.RowFilter =
               //     "ProductID = '" + e.CommandArgument + "'";
                //DataRowView row = productsTable[0];

                //create a new product object and load with data from row

                //Product p = new Product();
                //p.ProductID = row["ProductID"].ToString();
                //p.Category = row["Category"].ToString();
                //p.Description = row["Description"].ToString();
                //p.AvailableQty = (Int32)row["AvailableQty"];
                //p.Price = (decimal)row["Price"];

                if (Page.IsValid)
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
                    cn.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand();
                    try

                    {
                        string qry = "DELETE FROM Product WHERE ProductID = @Product;";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cmd.CommandText = qry;
                        cmd.Parameters.AddWithValue("@Product", e.CommandArgument);
                       

                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Message : " + ex.Message);
                        Response.Write(ex.StackTrace);
                    }
                    finally
                    {

                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                        cmd.Dispose();
                    }



























                    //get cart from session and selected item from cart
                    //CartItemList cart = CartItemList.GetCart();
                    //CartItem cartItem = cart[p.ProductID];

                    //if item isn’t in cart, add it; otherwise, increase its quantity
                    //if (cartItem == null)
                    //{
                    //    cart.AddItem(p,
                    //                 Convert.ToInt32(list.SelectedItem.ToString()));
                    //}
                    //else
                    //{
                    //    cartItem.AddQuantity(Convert.ToInt32(list.SelectedItem.ToString()));
                    //}
                    //lstItems.Add(Convert.ToInt32(p.ProductID), (Convert.ToInt32(list.SelectedItem.ToString()) * p.Price).ToString());
                    //Response.Redirect("ShoppingCart.aspx", false);
                }


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AddProduct.aspx");
        }
    }
}
using drumcenterworld.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drumcenterworld
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private CartItemList cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            cart = CartItemList.GetCart();
            if (!IsPostBack)
                this.DisplayCart();
        }

        private void DisplayCart()
        {
            ListBox1.Items.Clear();
            CartItem item;
            for (int i = 0; i < cart.Count; i++)
            {
                item = cart[i];
                ListBox1.Items.Add(item.Display());
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                if (ListBox1.SelectedIndex > -1)
                {
                    cart.RemoveAt(ListBox1.SelectedIndex);
                    this.DisplayCart();
                }
                else
                {
                    lblMessage.Text = "Please select an item to remove.";
                }
            }
        }

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                cart.Clear();
                ListBox1.Items.Clear();
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            //lblMessage.Text = "Sorry, that function hasn't been "
            //                    + "implemented yet.";
           

        }

        protected void ButtonRemoveItem_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                if (ListBox1.SelectedIndex > -1)
                {
                    cart.RemoveAt(ListBox1.SelectedIndex);
                    this.DisplayCart();
                }
                else
                {
                    lblMessage.Text = "Please select an item you want to remove.";
                }
            }
        }



        protected void ButtonCheckOut_Click1(object sender, EventArgs e)
        {

            int customerid = Convert.ToInt32(Session["UserID"]);
            int? neworderid= this.insertOrder(customerid);

            double TotalCost = 0;

           // if (ListBox1.Items.Count > 0)
           // {
           //     for (int i=0;i<ListBox1.Items.Count;i++)
           //     {
           //         Product product = (Product)ListBox1.Items[i];
           //     }
            //}

            if (this.cart.Count > 0)
            {
                
                for (int i = 0; i < this.cart.Count; i++)
                {
                    CartItem cartItem = this.cart.cartItems[i];
                    this.insertOrderItem(cartItem,(int) neworderid);
                }
            }


            else
            {
                Response.Write("Cart Is Empty");
            }

            //lblMessage.Text = "Sorry, that function hasn't been "
            //               + "implemented yet.";
        }

        protected void ButtonEmptyCart_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                cart.Clear();
                ListBox1.Items.Clear();
            }
        }

        protected void ButtonContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected int? insertOrder(int customerorder)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand();
            try

            {
                string qry = "insert into CustomerOrder(CustomerID, LastUpdate) output inserted.OrderID values(@CustomerID, @LastUpdate)";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.CommandText = qry;
                cmd.Parameters.AddWithValue("@CustomerID", customerorder);
                cmd.Parameters.AddWithValue("@LastUpdate", DateTime.Now);
                

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                

                Int32? newOrderID = (Int32?)cmd.ExecuteScalar();
                return (int?) newOrderID;
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
            return 0;
        }

        protected void insertOrderItem(CartItem cartItem, int orderid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand();
            try

            {
                string qry = "insert into Items(OrderID, ProductID, OrderQty) values(@OrderID, @ProductID, @OrderQty)";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.CommandText = qry;
                cmd.Parameters.AddWithValue("@OrderID", orderid);
                cmd.Parameters.AddWithValue("@ProductID", cartItem.Product.ProductID);
                cmd.Parameters.AddWithValue("@OrderQty", cartItem.Quantity);


                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();


                cmd.ExecuteScalar();
               
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
          
        }

    }
}

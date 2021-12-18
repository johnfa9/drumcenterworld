using drumcenterworld.Models;
using System;
using System.Collections.Generic;
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
            lblMessage.Text = "Sorry, that function hasn't been "
                            + "implemented yet.";
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
            double TotalCost = 0;

            if (ListBox1.Items.Count > 0)
            {
                for (int i=0;i<ListBox1.Items.Count;i++)
                {

                }
            }
            else
            {
                Response.Write("Cart Is Empty");
            }

            lblMessage.Text = "Sorry, that function hasn't been "
                           + "implemented yet.";
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
            Response.Redirect("Prducts.aspx");
        }
    }
}

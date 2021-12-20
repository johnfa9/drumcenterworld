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

                else
                {
                    if (Session["RoleID"].ToString() == "2")
                    {
                        Button1.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;
                    }
                }
            }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Session["addItem"] = "true";
            if (Page.IsValid)
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
                cn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand();

                if (e.CommandName == "DelProduct")
                {
                    DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));

                 
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
                }
                else if (e.CommandName == "ModProduct")
                    {

                    TextBox Cat = (TextBox)(e.Item.FindControl("TextBox1"));
                    TextBox Desc = (TextBox)(e.Item.FindControl("TextBox4"));
                    TextBox Price = (TextBox)(e.Item.FindControl("TextBox3"));
                    TextBox Available = (TextBox)(e.Item.FindControl("TextBox2"));

                    try

                    {
                        string qry = "UPDATE Product " +
                            "SET Category = @Category," +
                            "Description = @Description," +
                            "AvailableQty = @Available," +
                            "Price = @Price" +
                            " WHERE ProductID = @Product;";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cmd.CommandText = qry;
                        cmd.Parameters.AddWithValue("@Product", e.CommandArgument);
                        cmd.Parameters.AddWithValue("@Category", Cat.Text);
                        cmd.Parameters.AddWithValue("@Description", Desc.Text);
                        cmd.Parameters.AddWithValue("@Available", Available.Text);
                        cmd.Parameters.AddWithValue("@Price", Price.Text);

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

                Response.Redirect("/Admin/ModifyDeleteProduct.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           Response.Redirect("/Admin/AddProduct.aspx");
       }
    }
}
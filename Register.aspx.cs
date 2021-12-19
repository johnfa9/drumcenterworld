using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace drumcenterworld
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            cn.Open();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                cmd = new SqlCommand();
                try

                {
                    string qry = "insert into Users(RoleID,FirstName,LastName,Email,Street,City," +
                        "StateAbbreviation,ZipCode,UserPassword) values(@RoleID, @FirstName, @LastName," +
                        " @Email, @Street, @City, @StateAbbreviation, @ZipCode, @UserPassword)";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cmd.CommandText = qry;
                    cmd.Parameters.AddWithValue("@RoleID", 1);
                    cmd.Parameters.AddWithValue("@FirstName", TextBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", TextBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Street", TextBoxStreet.Text);
                    cmd.Parameters.AddWithValue("@City", TextBoxCity.Text);
                    cmd.Parameters.AddWithValue("@StateAbbreviation", TextBoxState.Text);
                    cmd.Parameters.AddWithValue("@ZipCode", TextBoxZip.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", TextBoxPassword.Text);

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

               

               /* SqlCommand cmd = new SqlCommand("insert into Users(RoleID, FirstName, LastName, Email, Street, City, StateAbbreviation, ZipCode, UserPassword) values('" +
                1 + "','" +
                TextBoxFirstName.Text + "','" +
                TextBoxLastName.Text + "','" +
                TextBoxEmail.Text + "','" +
                TextBoxStreet.Text + "','" +
                TextBoxCity.Text + "','" +
                TextBoxState.Text + "','" +
                TextBoxZip.Text + "','" +
                TextBoxPassword.Text +

                "'" + ")", con);
                int Rows = cmd.ExecuteNonQuery(); */



                        //SqlCommand cmd = new SqlCommand("insert into Customer(CustomerID, JoinDate, BillingMethod) values('" +

                        //using (con)
                        //{
                        // Create a SqlDataAdapter based on a SELECT query.
                        //  SqlCommand adapter =
                        //         new SqlDataAdapter("SELECT CategoryID, CategoryName FROM dbo.Customer", con);

                        //Create the SqlCommand to execute the stored procedure.
                        //adapter.InsertCommand = new SqlCommand("dbo.InsertCustomer",
                        //  con);
                        //adapter.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add the parameter for the CategoryName. Specifying the
                        // ParameterDirection for an input parameter is not required.



                        //adapter.InsertCommand.Parameters.Add(
                        //   new SqlParameter("@JoinDate", SqlDbType.Date,
                        //   Now();
                        //adapter.InsertCommand.Parameters.Add(
                        //new SqlParameter("@BillingMethod", SqlDbType.NChar, 50,
                        //DropDownListBilling.SelectedValue));

                        //SqlParameter parameter =
                        //adapter.InsertCommand.Parameters.Add(
                        //"@Identity", SqlDbType.Int, 0, "UserID");
                        //parameter.Direction = ParameterDirection.Output;


                        //}


                    cn.Close();
            }
        }
    }
}
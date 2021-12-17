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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["drumcenterconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            con.Open();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                
                SqlCommand cmd = new SqlCommand("insert into Users(RoleID, FirstName, LastName, Email, Street, City, StateAbbreviation, ZipCode, UserPassword) values('" +
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
                int Rows = cmd.ExecuteNonQuery();

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


                    con.Close();
            }
        }
    }
}
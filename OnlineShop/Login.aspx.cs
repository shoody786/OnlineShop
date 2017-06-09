using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop
{
    public partial class _Default : Page
    {

        private object dr;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=sql2016.fse.network; Initial Catalog= db_1621656_onlineshop_em; User ID= user_db_1621656_onlineshop_em; Password =P@55word;";

                          //Int32 verify;
                          bool verify;
            //string query1 = "Select * from Accounts where Email='" + Email.Text + "' and Password='" + Password.Text + "' ";

            string query1 = "Select * from Accounts where Email=@Email and Password=@Password ";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            con.Open();
            //verify = Convert.ToInt32(cmd1.ExecuteScalar());


            cmd1.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Text;
            cmd1.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password.Text;

            SqlDataReader reader = cmd1.ExecuteReader();
            verify = reader.HasRows;
            if (verify)
            {
                ErrorMessage.Text = "";
                ErrorMessage.Text += "Logging in...";
                reader.Read();

                this.UserID.Text = reader["ID"].ToString();
                this.AccType.Text = reader["AccountType"].ToString();
                //read other data into other labels

                string query2 = @"INSERT INTO Accounts(Email, Password, ID, AccountType)VALUES(@Email, @Password, @ID, @AccountType)";

                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd2.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Text;
                cmd2.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password.Text;
                cmd2.Parameters.Add("@ID", SqlDbType.Int).Value = UserID.Text;
                cmd2.Parameters.Add("@AccountType", SqlDbType.Int).Value = AccType.Text;

                //reader.Close();
                con.Close();

                Label mpLabel = (Label)Page.Master.FindControl("UID");

                if (mpLabel != null)
                {
                    mpLabel.Text = UserID.Text;
                }

                Label mpLabel2 = (Label)Page.Master.FindControl("AType");

                if (mpLabel2 != null)
                {
                    mpLabel2.Text = AccType.Text;
                }


                // <--------------------------------------------|                Start Cookies                  |---------------------------------------------------------------------->
                HttpCookie myCookie = new HttpCookie("LoginCookie");
                DateTime now = DateTime.Now;

                // Set the cookie value.
                myCookie.Value = mpLabel.Text;
                // Set the cookie expiration date.
                myCookie.Expires = now.AddYears(1); // For a cookie to effectively never expire

                // Add the cookie.
                Response.Cookies.Add(myCookie);

                Response.Write("<p> The cookie has been written.");

                HttpCookie myCookie2 = new HttpCookie("LoginCookie2");

                // Set the cookie value.
                myCookie2.Value = mpLabel2.Text;
                // Set the cookie expiration date.
                myCookie2.Expires = now.AddYears(1); // For a cookie to effectively never expire

                // Add the cookie.
                Response.Cookies.Add(myCookie2);

                Response.Write("<p> The cookie has been written.");
                // <--------------------------------------------|                End Cookies               |---------------------------------------------------------------------->

            }
            else
            {
                //unsuccessful
                //Response.Redirect("unsuccesful.aspx", true);
                ErrorMessage.Text = "";
                ErrorMessage.Text += "Email or Password incorrect! Please try again.";
            }
        }
    }
}
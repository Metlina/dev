using System;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;

public partial class NewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/LandingPage.aspx");
        }
    }

    protected void AddNewUser_OnClick(object sender, EventArgs e)
    {
        var username = this.UserName.Text;
        var password = this.Password.Text;

        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query =
                    new OleDbCommand(
                        "INSERT into users ([username], [password]) VALUES (@username, @password)",
                        connection);

                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", password);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
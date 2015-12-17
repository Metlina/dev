using System;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void CreateUserWizard1_OnNextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        using ( var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString))
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("INSERT into users ([username], [password]) VALUES (@ime, @password)",
                    connection);

                query.Parameters.AddWithValue("@ime", CreateUserWizard1.UserName);
                query.Parameters.AddWithValue("@password", CreateUserWizard1.Password);

                int temp = query.ExecuteNonQuery();
                e.Cancel = temp == 1;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }
    }

    protected void CreateUserWizard1_OnCreatedUser(object sender, EventArgs e)
    {
        using (var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString))
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("INSERT into users ([username], [password]) VALUES (@ime, @password)",
                    connection);

                query.Parameters.AddWithValue("@ime", CreateUserWizard1.UserName);
                query.Parameters.AddWithValue("@password", CreateUserWizard1.Password);

                int temp = query.ExecuteNonQuery();
                //e.Cancel = temp == 1;
            }
            catch (Exception)
            {
                //e.Cancel = true;
            }
        }
    }
}
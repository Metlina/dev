using System;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Login1_OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("SELECT * FROM users WHERE username=@ime AND password=@lozinka", connection);

                query.Parameters.AddWithValue("@ime", Login1.UserName);
                query.Parameters.AddWithValue("@password", Login1.Password);

                var dataReader = query.ExecuteReader();

                while (dataReader.Read())
                {
                    if (dataReader.GetString(0) == Login1.UserName &&
                        dataReader.GetString(1) == Login1.Password)
                        e.Authenticated = true;
                }

                dataReader.Close();
            }
            catch (Exception) { }
        }
    }
}
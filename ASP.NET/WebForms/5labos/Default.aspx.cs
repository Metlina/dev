using System;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("Login.aspx");
        }

        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("SELECT * FROM [users]", connection);
                var dataReader = query.ExecuteReader();

                if (dataReader == null) return;

                while (dataReader.Read())
                {
                    var link1 = new HyperLink
                    {
                        Text = dataReader["username"] + "<br><br>",
                        NavigateUrl = "MyData.aspx?user=" + dataReader["username"]
                    };
                    containerUsers.Controls.Add(link1);

                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.Identity.Name != dataReader["username"].ToString()) continue;
                        var link2 = new HyperLink
                        {
                            Text = "My profle - " + dataReader["username"] + "<br><br>",
                            NavigateUrl = "MyData.aspx?user=" + dataReader["username"]
                        };
                        containerMy.Controls.Add(link2);
                    }
                }

                dataReader.Close();
            }
            catch (Exception) { }
        }
    }
}
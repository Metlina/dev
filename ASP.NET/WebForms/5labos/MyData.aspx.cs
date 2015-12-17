using System;
using System.Configuration;
using System.Data.OleDb;

public partial class MyData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (User.Identity.Name == Request.QueryString["user"])
            {
                BtnSave.Visible = true;
            }
        }

        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("SELECT * FROM users WHERE username=@name", connection);
                query.Parameters.AddWithValue("@name", Request.QueryString["user"]);
                var dataReader = query.ExecuteReader();

                if (dataReader == null) return;

                while (dataReader.Read())
                {
                    LabelName2.Text = dataReader["name"].ToString();
                    LabelSurname2.Text = dataReader["surname"].ToString();
                }

                dataReader.Close();
            }
            catch (Exception) { }
        }
    }

    protected void BtnSave_OnClick(object sender, EventArgs e)
    {
        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("UPDATE [users] SET ime=@newname AND prezime=@newsurname WHERE username=@usernameOld", connection);
                query.Parameters.AddWithValue("@newname", LabelName2.Text);
                query.Parameters.AddWithValue("@newsurname", LabelSurname2.Text);
                query.Parameters.AddWithValue("@usernameOld", User.Identity.Name);
                var dataReader = query.ExecuteReader();

                dataReader.Close();
            }
            catch (Exception) { }
        }
    }
}
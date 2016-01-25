using System;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;

public partial class NewStorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/LandingPage.aspx");
        }
    }

    protected void AddNewStorageData_OnClick(object sender, EventArgs e)
    {
        var paper = this.Paper.Text;
        var ink = this.Ink.Text;
        var parts = this.Parts.Text;
        var mark = this.Mark.Text;

        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query =
                    new OleDbCommand(
                        "INSERT into storage ([paper], [ink], [parts], [mark]) VALUES (@paper, @ink, @parts, @mark)",
                        connection);

                query.Parameters.AddWithValue("@paper", paper);
                query.Parameters.AddWithValue("@ink", ink);
                query.Parameters.AddWithValue("@parts", parts);
                query.Parameters.AddWithValue("@mark", mark);

                query.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Materials were added successfuly')", true);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
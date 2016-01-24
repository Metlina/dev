using System;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;

public partial class NewPrinter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/LandingPage.aspx");
        }
    }

    protected void AddNewPrinter_OnClick(object sender, EventArgs e)
    {
        var model = this.PrinterModel.Text;
        var type = this.PrinterType.Text;
        var material = this.PrinterMaterial.Text;
        var location = this.PrinterLocation.Text;
        var mark = this.PrinterMark.Text;
        var function = this.PrinterFunction.Text;
        var paper = this.PrinterPaper.Text;

        using (
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
            )
        {
            try
            {
                connection.Open();
                var query =
                    new OleDbCommand(
                        "INSERT into printers ([model], [type], [material], [location], [mark], [function], [paper]) VALUES (@model, @type, @material, @location, @mark, @function, @paper)",
                        connection);

                query.Parameters.AddWithValue("@model", model);
                query.Parameters.AddWithValue("@type", type);
                query.Parameters.AddWithValue("@material", material);
                query.Parameters.AddWithValue("@location", location);
                query.Parameters.AddWithValue("@mark", mark);
                query.Parameters.AddWithValue("@function", function);
                query.Parameters.AddWithValue("@paper", paper);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
    }
}
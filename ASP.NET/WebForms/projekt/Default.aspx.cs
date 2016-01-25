using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    public List<Printer> Printers { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Printers = new List<Printer>();

        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/LandingPage.aspx");
        }

        //using (
        //    var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString)
        //    )
        //{
        //    try
        //    {
        //        connection.Open();
        //        var query = new OleDbCommand("SELECT * FROM printers", connection);

        //        var dataReader = query.ExecuteReader();

        //        while (dataReader != null && dataReader.Read())
        //        {
        //            var printer = new Printer
        //            {
        //                Model = dataReader.GetString(1),
        //                Type = dataReader.GetString(2),
        //                Material = dataReader.GetString(3),
        //                Location = dataReader.GetString(4),
        //                Mark = dataReader.GetString(5),
        //                Function = dataReader.GetString(6),
        //                Paper = dataReader.GetString(7)
        //            };

        //            Printers.Add(printer);
        //        }

        //        dataReader.Close();
        //    }
        //    catch (Exception) { }
        //}
    }
}
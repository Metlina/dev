using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private int count;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            

            if (Request.QueryString["index"] == "0")
            {
                MultiViewMain.ActiveViewIndex = 0;
            }
            else if (Request.QueryString["index"] == "5")
            {
                MultiViewMain.ActiveViewIndex = 5;
            }
        }

        if (User.Identity.IsAuthenticated)
        {
            switch (Request.QueryString["index"])
            {
                //case "0":
                //    MultiViewMain.ActiveViewIndex = 0;
                //    break;
                case "1":
                    MultiViewMain.ActiveViewIndex = 1;
                    break;
                case "2":
                    MultiViewMain.ActiveViewIndex = 2;
                    break;
                case "3":
                    MultiViewMain.ActiveViewIndex = 3;
                    break;
                case "4":
                    MultiViewMain.ActiveViewIndex = 4;
                    break;
                //case "5":
                //    MultiViewMain.ActiveViewIndex = 5;
                //    break;
                case "6":
                    MultiViewMain.ActiveViewIndex = 6;
                    break;
                case "7":
                    MultiViewMain.ActiveViewIndex = 7;
                    break;
                case "8":
                    MultiViewMain.ActiveViewIndex = 8;
                    break;
                default:
                    MultiViewMain.ActiveViewIndex = 0;
                    break;
            }
        }

        for (var i = 1; i <= 10; i++)
        {
            var row = new TableRow();
            for (var j = 1; j <= 10; j++)
            {
                var cell = new TableCell
                {
                    BorderStyle = BorderStyle.Solid,
                    Text = (i*j).ToString()
                };
                row.Cells.Add(cell);
            }
            Table1.Rows.Add(row);
        }
        if (!IsPostBack)
        {
            BindGridview();
        }

    }

    protected void BindGridview()
    {
        string[] files_Path = Directory.GetFiles(Server.MapPath("~/files/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string path in files_Path)
        {
            files.Add(new ListItem(Path.GetFileName(path)));
        }
        gridview1.DataSource = files;
        gridview1.DataBind();
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        var button = sender as Button;

        var numberOne = double.Parse(firstNubmerTbox.Text);
        var numberTwo = double.Parse(secondNumberTbox.Text);

        double result = 0;

        if (button == null) return;

        if (button.Text.Contains("+"))
        {
            result = numberOne + numberTwo;
        }
        else if (button.Text.Contains("-"))
        {
            result = numberOne - numberTwo;
        }
        else if (button.Text.Contains("*"))
        {
            result = numberOne * numberTwo;
        }
        else if (button.Text.Contains("/"))
        {
            result = numberOne / numberTwo;
        }

        resultTbox.Text = result.ToString();
    }

    protected void TrigonometryBtn_Click(object sender, EventArgs e)
    {
        var button = sender as Button;

        double input = double.Parse(trigonometryNumberTbox.Text);

        double result = 0;

        if (button == null) return;

        if (button.Text.Contains("sin"))
        {
            result = Math.Sin(input);
        }
        else if (button.Text.Contains("cos"))
        {
            result = Math.Cos(input);
        }
        else if (button.Text.Contains("tan"))
        {
            result = Math.Tan(input);
        }
        else if (button.Text.Contains("ctn"))
        {
            result = 1 / Math.Tan(input);
        }

        trigonometryResultTbox.Text = result.ToString();
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

                if (dataReader == null) return;

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

        if (e.Authenticated)
        {
            //Response.Redirect("Default.aspx?index=1");
        }
    }

    protected void CreateUserWizard1_OnNextButtonClick(object sender, WizardNavigationEventArgs e)
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
                e.Cancel = temp == 1;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxCalendarUnos.Text = "";

        using (var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString))
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("SELECT * FROM kalendar WHERE korisnik=@korisnik AND datum=@datum",
                    connection);

                query.Parameters.AddWithValue("@korisnik", User.Identity.Name);
                query.Parameters.AddWithValue("@datum", Calendar1.SelectedDate);

                var reader = query.ExecuteReader();

                if (reader == null) return;

                while (reader.Read())
                {
                    TextBoxCalendarUnos.Text = reader["opis"].ToString();
                    return;
                }

                reader.Close();

            }
            catch (Exception)
            {
            }
        }
    }

    protected void ButtonCalendarSpremi_Click(object sender, EventArgs e)
    {
        using (var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString))
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("INSERT INTO kalendar (opis, datum, korisnik) VALUES (@opis, @datum, @korisnik)",
                    connection);

                query.Parameters.AddWithValue("@opis", TextBoxCalendarUnos.Text);
                query.Parameters.AddWithValue("@datum", Calendar1.SelectedDate);
                query.Parameters.AddWithValue("@korisnik", User.Identity.Name);

                var dataReader = query.ExecuteReader();

                if (dataReader == null) return;

                dataReader.Close();
            }
            catch (Exception)
            {
            }
        }
        
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/Datoteke/") + filename);
                StatusLabel.Text = "Upload status: File uploaded!";
                count++;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //dll for zip missing Ionic.Zip.dll 
        //using (ZipFile zip = new ZipFile())
        //{
        //    foreach (GridViewRow gr in gridview1.Rows)
        //    {
        //        CheckBox chk = (CheckBox)gr.FindControl("chkSelect");
        //        if (chk.Checked)
        //        {
        //            string fileName = gr.Cells[1].Text;
        //            string filePath = Server.MapPath("~/files/" + fileName);
        //            zip.AddFile(filePath, "files");
        //        }
        //    }
        //    Response.Clear();
        //    Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
        //    Response.ContentType = "application/zip";
        //    zip.Save(Response.OutputStream);
        //    Response.End();
        //}
    }
}
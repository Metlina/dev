using System;
using System.Configuration;
using System.Data.OleDb;

public partial class Tablica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string ime = ImeUnos.Text;
        string prezime = PrezimeUnos.Text;
        string jmbag = JmbagUnos.Text;
        string grupa = GrupaUnos.Text;
        string kontakt = KontaktUnos.Text;

        using (var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString))
        {
            try
            {
                connection.Open();
                var query = new OleDbCommand("INSERT into studenti ([jmbag], [ime], [prezime], [grupa], [kontakt]) VALUES (@jmbag, @ime, @prezime, @grupa, @kontakt)",
                    connection);

                query.Parameters.AddWithValue("@jmbag", jmbag);
                query.Parameters.AddWithValue("@ime", ime);
                query.Parameters.AddWithValue("@prezime", prezime);
                query.Parameters.AddWithValue("@grupa", grupa);
                query.Parameters.AddWithValue("@kontakt", kontakt);

                query.ExecuteNonQuery();

            }
            catch (Exception)
            {
            }
        }
    }

    protected void SubmitTrazi_Click(object sender, EventArgs e)
    {
        if (TraziIme.Text.Length > 0 && TraziPrezime.Text.Length > 0)
        {
            AccessDataSource1.SelectCommand = "SELECT * FROM studenti WHERE Ime LIKE '" + TraziIme.Text + "%' AND Prezime LIKE '" + TraziPrezime.Text + "%'";
        }
        else if (TraziIme.Text.Length > 0 && TraziPrezime.Text.Length == 0)
        {
            AccessDataSource1.SelectCommand = "SELECT * FROM studenti WHERE Ime LIKE '" + TraziIme.Text + "%'";
        }
        else if (TraziPrezime.Text.Length > 0 && TraziIme.Text.Length == 0)
        {
            AccessDataSource1.SelectCommand = "SELECT * FROM studenti WHERE Prezime LIKE '" + TraziPrezime.Text + "%'";
        }
        else if (TraziIme.Text.Length == 0 && TraziPrezime.Text.Length == 0)
        {
            AccessDataSource1.SelectCommand = "SELECT * FROM studenti WHERE Ime LIKE '" + TraziIme.Text + "%' AND Prezime LIKE '" + TraziPrezime.Text + "%'";
        }
    }
}
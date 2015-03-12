using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Session["Name"] = Name.Text;
            Application["Email"] = Email.Text;
            NameAndEmail.Text = Name.Text + " " + Email.Text;
        }

        protected void Retrieve_Click(object sender, EventArgs e)
        {
            string name = "";
            string email = "";

            if (Session["Name"] != null)
            {
                name = Session["Name"].ToString();
            }

            if (Application["Email"] != null)
            {
                email = Application["Email"].ToString();
            }

            RetrievedNameAndEmail.Text = "Retrieved : " + name + " " + email;
        }
    }
}
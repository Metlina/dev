using System;
using System.Configuration;
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
        if (Login1.Password == ConfigurationManager.AppSettings["Password"] &&
            Login1.UserName == ConfigurationManager.AppSettings["User"])
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }

    //protected void Login1_OnLoggedIn(object sender, EventArgs e)
    //{
    //    Response.Redirect("Default.aspx");
    //}
}
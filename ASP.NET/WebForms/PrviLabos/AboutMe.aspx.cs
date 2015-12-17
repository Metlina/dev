using System;

public partial class AboutMe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void logOutBtn_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
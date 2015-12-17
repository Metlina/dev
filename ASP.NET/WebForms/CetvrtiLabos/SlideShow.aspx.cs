using System;

public partial class SlideShow : System.Web.UI.Page
{
    private int picNumber = 8;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Timer1_OnTick(object sender, EventArgs e)
    {
        int count;
        if (ViewState["PicCounter"] == null)
        {
            count = 2;
        }
        else if (Convert.ToInt32(ViewState["PicCounter"]) > picNumber)
        {
            count = 1;
        }
        else
        {
            count = Convert.ToInt32(ViewState["PicCounter"]);
        }

        Image1.ImageUrl = "/Images/Image" + (count++) + ".jpg";
        ViewState["PicCounter"] = count;
    }
}
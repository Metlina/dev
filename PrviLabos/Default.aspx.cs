using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public List<string> inputList { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("Login.aspx");
        }
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
        dateTimeTbox.Text = DateTime.Now.ToString();
    }

    protected void TrigonometryBtn_Click(object sender, EventArgs e)
    {
        var button = sender as Button;

        inputList = new List<string> {firstNubmerTbox.Text, secondNumberTbox.Text, resultTbox.Text};

        //var firstNumber = double.Parse(firstNubmerTbox.Text);

        var selectedIndex = dropDownList.SelectedIndex;

        double input = 0;

        if (selectedIndex == 1)
        {
            input = double.Parse(firstNubmerTbox.Text);
        }
        else if (selectedIndex == 2)
        {
            input = double.Parse(secondNumberTbox.Text);
        }
        else if (selectedIndex == 3)
        {
            input = double.Parse(resultTbox.Text);
        }

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
        dateTimeTbox.Text = DateTime.Now.ToString();
    }

    protected void logOutBtn_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
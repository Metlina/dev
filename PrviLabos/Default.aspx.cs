using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void firstNubmerTbox_OnTextChanged(object sender, EventArgs e)
    {
        var tString = firstNubmerTbox.Text;

        if (tString.Trim() == "") return;

        for (int i = 0; i < tString.Length; i++)
        {
            if (!char.IsNumber(tString[i]))
            {
                firstNubmerTbox.Text = "";
                return;
            }
        }
    }
}
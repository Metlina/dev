using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.QueryString["index"])
        {
            case "0":
                MultiViewMain.ActiveViewIndex = 0;
                break;
            case "1":
                MultiViewMain.ActiveViewIndex = 1;
                break;
            case "2":
                MultiViewMain.ActiveViewIndex = 2;
                break;
            case "3":
                MultiViewMain.ActiveViewIndex = 3;
                break;
            default:
                MultiViewMain.ActiveViewIndex = -1;
                break;
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
}
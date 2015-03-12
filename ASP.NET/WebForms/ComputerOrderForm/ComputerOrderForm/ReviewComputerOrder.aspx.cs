using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerOrderForm.Models;

namespace ComputerOrderForm
{
    public partial class ReviewComputerOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComputerOrder order = Session["CurrentOrder"] as ComputerOrder;
            if (order != null)
            {
                OrderNumber.Text = order.OrderId.ToString();
                OrderName.Text = order.OrderName;
                CustomerName.Text = order.Customer;
                CustomerEmail.Text = order.CustomerEmail;
                DeliveryDate.Text = order.DeliveryDate.ToShortDateString();
                PartNumber.Text = order.PartNumber.ToString();
                RushOrder.Text = order.Rush == true ? "Yes" : "No";
            }
        }
    }
}
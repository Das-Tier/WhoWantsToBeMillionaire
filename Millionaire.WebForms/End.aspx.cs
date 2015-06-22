using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire.WebForms
{
    public partial class End : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_result.Text = String.Format(Global.Unburned.ToString() + "$");
        }

        protected void btn_gotostart_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}
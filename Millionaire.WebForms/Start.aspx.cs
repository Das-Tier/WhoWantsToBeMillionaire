using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.WebForms.Code;

namespace Millionaire.WebForms
{
    public partial class Start : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_startGame_Click(object sender, EventArgs e)
        {
            Game.Name = txbx_userName.Text.ToString();
            if (Game.Name != null)
            {
                Response.Redirect("Main.aspx");
            }
        }
    }
}
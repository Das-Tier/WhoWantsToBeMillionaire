using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.WebForms.Code;

namespace Millionaire.WebForms
{
    public partial class Finish : System.Web.UI.Page
    {
        private Game game;
        protected void Page_Load(object sender, EventArgs e)
        {
            game = (Game)Session["gameState"];
            lbl_Name.Text = Game.Name + "! ";
            lbl_result.Text = String.Format(game.Unburned.ToString() + "$");
        }

        protected void btn_gotostart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}
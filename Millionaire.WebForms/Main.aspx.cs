using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using Millionaire.WebForms.Code;

namespace Millionaire.WebForms
{
    public partial class Main : System.Web.UI.Page
    {
        public string name;
        public Game game;
        protected void Page_Load(object sender, EventArgs e)
        {
            game = new Game(Server.MapPath("/App_Data/Data.xml"));
            
            if (Session["gameState"] == null)
            {
                game = new Game(Server.MapPath("/App_Data/Data.xml"));
                lbl_score.Text = game.Score[game.Step].ToString();
                SetQuestion();
                btn_halfONhalf.Visible = true;
                btn_friendHelp.Visible = true;
                btn_auditoryHelp.Visible = true;
                Session["gameState"] = game;
            }
            else
            {
                game = (Game)Session["gameState"];
            }
            if (game.Step == 5 || game.Step == 10)
            {
                game.Unburned = game.Score[game.Step];
            }
        }

        protected void btn_check_Click(object sender, EventArgs e)
        {
            if (rdbl_answers.SelectedItem.Value == game.Questions[game.Step].Answer)
            {
                game.Step++;
                if (game.Step == 15)
                {
                    game.Unburned = 1000000;
                    Response.Redirect("Finish.aspx");
                }
                else
                {
                    lbl_score.Text = game.Score[game.Step].ToString();
                    SetQuestion();
                    SetAnswersTrue();
                }
            }
            else
            {                 
                string cleanMessage="Невірно! Правильна відповідь: " + rdbl_answers.Items.FindByValue(game.Questions[game.Step].Answer.ToString()).Text;
                string script = string.Format("alert('{0}'); window.location='"+Request.ApplicationPath+"Finish.aspx';", cleanMessage);
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script, true);
             
            }
        }

        protected void btn_newgame_Click(object sender, EventArgs e)
        {
            game = new Game(Server.MapPath("/App_Data/Data.xml"));            
            lbl_score.Text = game.Score[game.Step].ToString();
            SetQuestion();
            btn_halfONhalf.Visible = true;
            btn_friendHelp.Visible = true;
            btn_auditoryHelp.Visible = true;
        }

        protected void btn_halfONhalf_Click(object sender, EventArgs e)
        {
            HalfOnHalf();
            btn_halfONhalf.Visible = false;
        }

        protected void btn_friendHelp_Click(object sender, EventArgs e)
        {
            FriendHelp();
            btn_friendHelp.Visible = false;
        }

        protected void btn_auditoryHelp_Click(object sender, EventArgs e)
        {
            btn_auditoryHelp.Visible = false;
            string requestQuery = String.Format("http://www.google.com/search?q=" + game.Questions[game.Step].Ask.Replace(" ", "+"));
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('" +requestQuery +"')", true);
        }

        #region Helpers
        private void SetQuestion()
        {
            lbl_question.Text = game.Questions[game.Step].Ask;
            rdbl_answers.Items.FindByValue("a").Text = game.Questions[game.Step].A;
            rdbl_answers.Items.FindByValue("b").Text = game.Questions[game.Step].B;
            rdbl_answers.Items.FindByValue("c").Text = game.Questions[game.Step].C;
            rdbl_answers.Items.FindByValue("d").Text = game.Questions[game.Step].D;
        }

        private void SetAnswersTrue()
        {
            for (int i = 0; i < 4; i++)
            {
                rdbl_answers.Items[i].Enabled = true;
            }
        }

        private void FriendHelp()
        {
            MailMessage Message = new MailMessage();
            Message.Subject = "Millionaire";
            Message.Body = lbl_question.Text.ToString();
            Message.BodyEncoding = Encoding.GetEncoding("Windows-1254"); 
            Message.From = new System.Net.Mail.MailAddress("vitalijmogola@gmail.com");
            Message.To.Add(new MailAddress("some@gmail.com"));
            System.Net.Mail.SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 574);
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;
            Smtp.Credentials = new System.Net.NetworkCredential("vitalijmogola@gmail.com", "password");
            Smtp.Send(Message);
        }

        private void HalfOnHalf()
        {
            if (rdbl_answers.Items.FindByValue("a").Value == game.Questions[game.Step].Answer)
            {
                rdbl_answers.Items.FindByValue("b").Enabled = false;
                rdbl_answers.Items.FindByValue("c").Enabled = false;
            }
            else if (rdbl_answers.Items.FindByValue("b").Value == game.Questions[game.Step].Answer)
            {
                rdbl_answers.Items.FindByValue("a").Enabled = false;
                rdbl_answers.Items.FindByValue("c").Enabled = false;
            }
            else if (rdbl_answers.Items.FindByValue("c").Value == game.Questions[game.Step].Answer)
            {
                rdbl_answers.Items.FindByValue("a").Enabled = false;
                rdbl_answers.Items.FindByValue("d").Enabled = false;
            }
            else
            {
                rdbl_answers.Items.FindByValue("a").Enabled = false;
                rdbl_answers.Items.FindByValue("c").Enabled = false;
            }
        }
        #endregion
    }
}


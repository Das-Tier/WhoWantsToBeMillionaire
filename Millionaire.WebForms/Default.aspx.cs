using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net.Mail;
using System.Text;

namespace Millionaire.WebForms
{
    public partial class Game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.Step == 5 || Global.Step == 10)
            {
                Global.Unburned = Global.Score[Global.Step];
            }
        }

        #region Click-Handlers
        protected void btn_check_Click(object sender, EventArgs e)
        {
            if (rdbl_answers.SelectedItem.Value == Global.questions[Global.Step].Answer)
            {
                Global.Step++;
                if (Global.Step == 15)
                {
                    Global.Unburned = 1000000;
                    Response.Redirect("end.aspx");
                }
                else
                {
                    lbl_score.Text = Global.Score[Global.Step].ToString();
                    SetQuestion();
                    SetAnswersTrue();
                }
            }
            else
            {
                rdbl_answers.Items.FindByValue(Global.questions[Global.Step].Answer).Text += "--- Правильна відповідь!";
                Response.Redirect("End.aspx");
            }
        }

        protected void btn_newgame_Click(object sender, EventArgs e)
        {
            Global.Step = 0;
            Global.Unburned = 0;
            lbl_score.Text = Global.Score[Global.Step].ToString();
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
            string question = Global.questions[Global.Step].Ask.Replace(" ", "+");
            string request = String.Format("http://www.google.com/search?q=" + question);
            Response.Redirect(request);
        }
        #endregion

        #region Helpers
        private void SetQuestion()
        {
            lbl_question.Text = Global.questions[Global.Step].Ask;
            rdbl_answers.Items.FindByValue("a").Text = Global.questions[Global.Step].A;
            rdbl_answers.Items.FindByValue("b").Text = Global.questions[Global.Step].B;
            rdbl_answers.Items.FindByValue("c").Text = Global.questions[Global.Step].C;
            rdbl_answers.Items.FindByValue("d").Text = Global.questions[Global.Step].D;
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
            Message.Body =  lbl_question.Text.ToString();
            Message.BodyEncoding = Encoding.GetEncoding("Windows-1254"); // Turkish Character Encoding// кодировка эсли нужно!
            Message.From = new System.Net.Mail.MailAddress("vitalijmogola@gmail.com");
            Message.To.Add(new MailAddress( "some@gmail.com"));
            System.Net.Mail.SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 1001);//эсли здесь заполнено то строчка ниже не нужна!!!!
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true; 
            Smtp.Credentials = new System.Net.NetworkCredential("vitalijmogola@gmail.com", "rk12espd8");
            Smtp.Send(Message);
                       
        }

        private void HalfOnHalf()
        {
            if (rdbl_answers.Items.FindByValue("a").Value == Global.questions[Global.Step].Answer)
            {
                rdbl_answers.Items.FindByValue("b").Enabled = false;
                rdbl_answers.Items.FindByValue("c").Enabled = false;
            }
            else if (rdbl_answers.Items.FindByValue("b").Value == Global.questions[Global.Step].Answer)
            {
                rdbl_answers.Items.FindByValue("a").Enabled = false;
                rdbl_answers.Items.FindByValue("c").Enabled = false;
            }
            else if (rdbl_answers.Items.FindByValue("c").Value == Global.questions[Global.Step].Answer)
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
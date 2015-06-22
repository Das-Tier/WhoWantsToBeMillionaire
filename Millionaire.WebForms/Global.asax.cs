using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;

namespace Millionaire.WebForms
{
    public class Global : System.Web.HttpApplication
    {
        public static int Step;
        public static int Unburned;
        public static int[] Score = { 0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
        public static List<Question> questions;
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Step = 0;
            Unburned = 0;
            questions = new List<Question>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("/App_Data/Data.xml"));
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Question quiz = new Question();
                XmlNode attr = xnode.Attributes.GetNamedItem("id");
                if (attr != null)
                {
                    quiz.ID = Int32.Parse(attr.Value);
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "text")
                        quiz.Ask = childnode.InnerText;

                    if (childnode.Name == "a")
                        quiz.A = childnode.InnerText;

                    if (childnode.Name == "b")
                        quiz.B = childnode.InnerText;

                    if (childnode.Name == "c")
                        quiz.C = childnode.InnerText;

                    if (childnode.Name == "d")
                        quiz.D = childnode.InnerText;

                    if (childnode.Name == "answer")
                        quiz.Answer = childnode.InnerText;
                }
                questions.Add(quiz);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Step = 0;
            Unburned = 0;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
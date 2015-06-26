using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


namespace Millionaire.WebForms.Code
{
    public class Game
    {
        
        public static string Name { get; set; }
        public int Step { get; set; }
        public int [] Score { get;  set; }
        public int Unburned { get; set; }
        public List<Question> Questions { get; set; }
        public Game(string path)
        {
            Score = new int []{ 0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
            Step = 0;
            Unburned = 0;           
            Questions = new List<Question>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
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
                Questions.Add(quiz);
            }
        }
    }
}
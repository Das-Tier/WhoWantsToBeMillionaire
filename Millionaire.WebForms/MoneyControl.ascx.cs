using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire.WebForms
{
    public partial class MoneyControl : System.Web.UI.UserControl
    {
        public int Money { get; set; }
        public int UnburnedMoney { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
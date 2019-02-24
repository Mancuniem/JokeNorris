using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JokeNorris
{
    public partial class JokeUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRandomJoke_Click(object sender, EventArgs e)
        {
            var bob = HttpClientHandler.HttpClientHandlerAsync("https://api.icndb.com?callback=");
            var fred = bob.Status;
            var msg = $"alert(' {fred.ToString()} ');";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", msg, true);
        }
    }
}
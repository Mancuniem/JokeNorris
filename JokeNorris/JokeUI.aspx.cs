using System;
using System.Threading.Tasks;
using System.Web.UI;
using JokeNorris.Api;


namespace JokeNorris
{
    public partial class JokeUI : Page
    {
        private readonly JokeFetcher _jokeFetcher = new JokeFetcher();

        protected void btnRandomJoke_Click(object Sender, EventArgs Args)
        {
            this.RegisterAsyncTask(new PageAsyncTask(RandomJokeHandlerAsync));
        }

        private async Task RandomJokeHandlerAsync()
        {
            try
            {
                var joke = await this._jokeFetcher.GetRandomJokeAsync();

                var displayJoke = $"alert(\"{joke.joke}\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", displayJoke, true);
            }
            catch (Exception)
            {
                throw new NotImplementedException(); // todo: handle exceptions!
            }
        }

        protected void btnNeverEndingJokes_Click(object sender, EventArgs e)
        {

        }
    }
}
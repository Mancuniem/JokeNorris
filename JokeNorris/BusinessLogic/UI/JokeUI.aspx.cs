using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using JokeNorris.Api;


namespace JokeNorris
{
    public partial class JokeUI : Page
    {
        private readonly JokeFetcher _jokeFetcher = new JokeFetcher();

        private void DisplayJoke(Joke Joke)
        {
            var displayJoke = $"alert(\"{Joke.joke}\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", displayJoke, true);
        }

        private async Task RandomJokeHandlerAsync()
        {
            try
            {
                var joke = await this._jokeFetcher.GetRandomJokeAsync();

                DisplayJoke(joke);
            }
            catch (Exception)
            {
                throw new NotImplementedException(); // todo: handle exceptions!
            }
        }

        private async Task CharacterSearchHandlerAsync()
        {
            try
            {
                var joke = await this._jokeFetcher.GetCharacterJokeAsync();

                DisplayJoke(joke);
            }
            catch (Exception)
            {
                throw new NotImplementedException(); // todo: handle exceptions!
            }
        }

        private async Task NeverEndingJokesHandlerAsync()
        {
            try
            {
                //todo
            }
            catch (Exception)
            {
                throw new NotImplementedException(); // todo: handle exceptions!
            }
        }

        protected void btnRandomJoke_Click(object Sender, EventArgs Args)
        {
            var firstName = txtCharacterEntry.Text;

            this.RegisterAsyncTask(new PageAsyncTask(async () => {
                try
                {
                    var joke = await this._jokeFetcher.GetRandomJokeAsync();

                    DisplayJoke(joke);
                }
                catch (Exception)
                {
                    throw new NotImplementedException(); // todo: handle exceptions!
                }
            }));
        }

        protected void btnCharacterSearch_Click(object Sender, EventArgs e)
        {
            var rawText = txtCharacterEntry.Text.Trim();
            var nameParts = Regex.Split(rawText, @"\s+");

            if (nameParts.Length < 2)
            {
                throw new NotImplementedException();
            }

            var lastName = nameParts[nameParts.Length - 1];
            var firstName = string.Join(" ", nameParts, 0, (nameParts.Length - 1));
            
            

            this.RegisterAsyncTask(new PageAsyncTask(async () => {
                try
                {
                    var joke = await this._jokeFetcher.GetCharacterJokeAsync(firstName, lastName);

                    DisplayJoke(joke);
                }
                catch (Exception)
                {
                    throw new NotImplementedException(); // todo: handle exceptions!
                }
            }));
        }

        protected void btnNeverEndingJokes_Click(object Sender, EventArgs e)
        {
            this.RegisterAsyncTask(new PageAsyncTask(NeverEndingJokesHandlerAsync));
        }


    }
}
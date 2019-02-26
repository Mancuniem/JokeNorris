using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using JokeNorris.BusinessLogic;
using JokeNorris.BusinessLogic.Api;


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

        protected void btnRandomJoke_Click(object Sender, EventArgs Args)
        {
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

        /// <summary>
        /// On clicking the Search button, read in the text entered in the text box.
        /// Format, split and sanitize it and send to the ICNDB to retrieve a random joke with the name customized to the text entered.
        /// As this is a name field, there is minimal validation, because names can be so very varied.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void btnCharacterSearch_Click(object Sender, EventArgs e)
        {
            // Get text from text box and trim leading and trailing white space         
            var rawText = txtCharacterEntry.Text.Trim();

            // Split the text entered into strings using white space as delimiter
            var nameParts = Regex.Split(rawText, @"\s+");

            //// Enforce two string entities. i.e. Insist on values for first name and last name
            //// This is purely a design choice.  There are many other options for validating what is entered.
            //if (nameParts.Length < 2)
            //{
            //    throw new NotImplementedException();
            //}

            // Also an arbitrary design choice for splitting first and last names.  
            // Here we are assuming the last string entered is the last name and all previous strings form the first name.
            var lastName = nameParts[nameParts.Length - 1];
            var firstName = string.Join(" ", nameParts, 0, (nameParts.Length - 1));
            var sanitizedFirstName = TextSanitizer.Sanitize(firstName);
            var sanitizedLastName = TextSanitizer.Sanitize(lastName);

            this.RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                try
                {
                    var joke = await this._jokeFetcher.GetCharacterJokeAsync(sanitizedFirstName, sanitizedLastName);

                    DisplayJoke(joke);
                }
                catch (Exception)
                {
                    throw new NotImplementedException(); // todo: handle exceptions!
                }
            }));
        }

    }
}
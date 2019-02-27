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

        private void DisplayErrorMessage(string ErrorMessage)
        {
            var message = $"alert(\"{ErrorMessage}\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", message, true);
        }

        /// <summary>
        /// Fires on the click of the Random Joke button
        /// Registers the asynchronous task as an event handler cannot be asynchronous
        /// Attempts to call JokeFetcher, which attempts to consume the ICNDB web service.
        /// Displays joke or error message, dependent on success.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Args"></param>
        protected void btnRandomJoke_Click(object Sender, EventArgs Args)
        {
            this.RegisterAsyncTask(new PageAsyncTask(async () => {
                try
                {
                    var joke = await this._jokeFetcher.GetRandomJokeAsync();

                    DisplayJoke(joke);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex.Message);
                }
            }));
        }

        /// <summary>
        /// On clicking the Search button, read in the text entered in the text box.
        /// Format, split the text (it will be escaped later) and send to the ICNDB to retrieve a random joke with the name customized to the text entered.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void btnCharacterSearch_Click(object Sender, EventArgs e)
        {
            // Get text from text box and trim leading and trailing white space         
            var rawText = txtCharacterEntry.Text.Trim();

            // Split the text entered into strings using white space as delimiter
            var nameParts = Regex.Split(rawText, @"\s+");

            // Also an arbitrary design choice for splitting first and last names.  
            // Here we are assuming the last string entered is the last name and all/any previous strings form the first name.
            var lastName = nameParts[nameParts.Length - 1];
            var firstName = string.Join(" ", nameParts, 0, (nameParts.Length - 1));

            this.RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                try
                {
                    var joke = await this._jokeFetcher.GetCharacterJokeAsync(firstName, lastName);

                    DisplayJoke(joke);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex.Message);
                }
            }));
        }
    }
}
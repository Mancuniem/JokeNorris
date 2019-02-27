using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JokeNorris.BusinessLogic.Api
{
    public class JokeFetcher
    {
        public const string DefaultBaseUri = "https://api.icndb.com";

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initialise a JokeFetcher with an HttpClient with a base URI defined
        /// </summary>
        public JokeFetcher(HttpClient HttpClient)
        {
            this._httpClient = HttpClient;

            this._httpClient.DefaultRequestHeaders.Accept.Clear();
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Initialise a JokeFetcher and specify a base URI
        /// </summary>
        public JokeFetcher(Uri Uri) : this(new HttpClient { BaseAddress = Uri }) { }

        /// <summary>
        /// Initialise a JokeFetcher and specify a base URI
        /// </summary>
        public JokeFetcher(string Uri) : this(new Uri(Uri)) { }

        /// <summary>
        /// Initialise a JokeFetcher with the default base URI
        /// </summary>
        public JokeFetcher() : this(DefaultBaseUri) { }

        //private static T Sample<T>(T Arg)
        //{
        //    return Arg;
        //}

        private static TValue EnsureSuccessResult<TValue>(Result<TValue> Result)
        {
            if (!Result.type.Equals("success", StringComparison.InvariantCulture))
            {
                throw new Exception($"Result did not indicate success. Type = {Result.type} Value = {Result.value}");
            }

            return Result.value;
        }

        /// <summary>
        /// Retrieve a random joke from the API
        /// </summary>
        /// <returns>The retrieved joke</returns>
        public async Task<Joke> GetRandomJokeAsync()
        {
            var response = await this._httpClient.GetAsync("/jokes/random");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Result<Joke>>();

            return EnsureSuccessResult(result);
        }

        /// <summary>
        /// Retrieve a random joke from the API with a different character name
        /// </summary>
        /// <returns>The retrieved joke</returns>
        public async Task<Joke> GetCharacterJokeAsync(string FirstName, string LastName)
        {
            var escapedFirstName = Uri.EscapeDataString(FirstName);
            var escapedLastName = Uri.EscapeDataString(LastName);

            var uri = $"/jokes/random?firstName={escapedFirstName}&lastName={escapedLastName}";
            var response = await this._httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Result<Joke>>();

            return EnsureSuccessResult(result);
        }
    }
}

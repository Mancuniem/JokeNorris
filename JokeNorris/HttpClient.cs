using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeNorris
{
    public class HttpClientHandler
    {
        public static HttpClient HttpClient { get; set; }

        public static async Task<bool> HttpClientHandlerAsync(string URI)
        {
            HttpClient.BaseAddress = new Uri(URI);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await HttpClient.GetAsync(URI);

            //if (response.IsSuccessStatusCode)
            //{

            //    //Product product = await response.Content.ReadAsAsync > Product > ();
            //    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
            //}
            return response.IsSuccessStatusCode;  //change
        }

    }
}
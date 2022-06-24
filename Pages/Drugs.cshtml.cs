using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppTekaClient.Models;
using System.Net.Http.Json;

namespace AppTekaClient.Pages
{
    public class DrugsModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<Drug> Drugs;

        public DrugsModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task OnGet()
        {
          Drugs=  await GetMyObjectAsync();
        }

        public async Task<List<Drug>> GetMyObjectAsync(CancellationToken cts = default)
        {
            var _httpClient = _httpClientFactory.CreateClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<Drug>>("https://localhost:5001/api/drug", cts);

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");
            return myObject;
        }
    }
}
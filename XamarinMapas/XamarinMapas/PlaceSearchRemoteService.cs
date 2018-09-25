using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMapas
{
    public class PlaceSearchRemoteService
    {
        private string APIKEY = "pegar no zap";
        public static String CreateSessionToken()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public async Task<String> Lookup(String searchString, String mapsSessionToken)
        {


            var client = new RestClient("https://maps.googleapis.com");
            //essa url funciona no postman mas no meu sistema de mobile dá resultado vazio. pq?
            String requestString = $"maps/api/place/autocomplete/json?input={searchString}&key={APIKEY}&session_token={mapsSessionToken}";
            var request = new RestRequest(requestString, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.ExecuteAsync(request, (resp) =>
            {
                Debug.WriteLine(resp.ToString());
            });
            Debug.WriteLine(response.ToString());
            return response.ToString();
        }
    }
}

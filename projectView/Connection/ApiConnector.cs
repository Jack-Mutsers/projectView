using Newtonsoft.Json;
using projectView.entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectView.Connection
{
    class ApiConnector
    {
        public List<Categories> Get_categories()
        {
            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", "08d77c8e-5706-82f3-09c9-129653f3f744");
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            List<Categories> jsonResponse = JsonConvert.DeserializeObject<List<Categories>>(responseContent);

            return jsonResponse;
        }

        public Guid Login(string username, string password)
        {
            var client = new RestClient("https://localhost:5001/api/user/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"username\": \"" + username + "\",\n \"password\": \"" + password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            Guid jsonResponse = JsonConvert.DeserializeObject<Guid>(responseContent);

            return jsonResponse;
        }

    }
}

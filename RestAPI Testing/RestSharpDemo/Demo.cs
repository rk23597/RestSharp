using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDemo
{
    public class Demo
    {
        //Create a Rest Client
        //Create a Request
        //Return response
        public Users GetUsers()
        {
            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("/api/users?page=2", Method.GET);

            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            Users users = JsonConvert.DeserializeObject<Users>(content);
            return users;
        }
    }
}

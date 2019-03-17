using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsiteAPI_Deno
{
    public class RestApiHelper
    {

        public RestClient _restClient;
        public RestRequest _restRequest;
        public string _baseUrl = "http://localhost:53074/ProcurementCentre/";


        public RestClient SetUrl(string resourceUrl)
        {
            var url = Path.Combine(_baseUrl, resourceUrl);
            var _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deseiralizeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deseiralizeObject;
        }

    }
}


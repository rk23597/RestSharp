using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class SendWebServiceURL
    {
        public EndpointAddress webServiceAddress;

        public EndpointAddress GetEndpointAddress(string webServiceUrl)
        {
            webServiceAddress = new EndpointAddress(new Uri(webServiceUrl));
            return webServiceAddress;
        }
    }
}

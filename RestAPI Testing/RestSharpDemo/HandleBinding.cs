using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
   public class HandleBinding
    {
        public BasicHttpBinding basicHttpBinding;

        public BasicHttpBinding GetHttpBinding()
        {
            basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            //basicHttpBinding.
            return basicHttpBinding;
        }

    }
}

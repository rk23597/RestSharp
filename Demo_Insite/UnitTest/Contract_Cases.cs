using InsiteAPI_Deno;
using InsiteAPI_Deno.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
   [TestClass]
   public class Contract_Cases
    {

        [TestMethod]
        public void GetContract_Status()
        {

            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetContractList");
            var restRequest = restApi.CreateGetRequest();

            var response = restApi.GetResponse(restUrl, restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public void GetContract_ALL()
        {

            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetContractList");
            var restRequest = restApi.CreateGetRequest();

            var response = restApi.GetResponse(restUrl, restRequest);

            var contracts = restApi.GetContent<List<ContractListDto>>(response);
            

            Assert.IsTrue(contracts.Count()>1);

        }


        [TestMethod]
        public void GetContact_SearchParamters_singleValue()
        {
            //for single search for array add dirctly into add parameters
            string criteria_contractIds = "contractIds";
            string criteria_CustomerWebVisible = "customerWebVisible";
            string criteria_ContractWebVisible = "contractWebVisible";

            
            string value = "3687";


            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetContractList");
            var restRequest = restApi.CreateGetRequest();
            restRequest.AddQueryParameter(criteria_contractIds, value);
            restRequest.AddQueryParameter(criteria_ContractWebVisible, true.ToString());
            restRequest.AddQueryParameter(criteria_CustomerWebVisible, true.ToString());


            var response = restApi.GetResponse(restUrl, restRequest);

            var contracts = restApi.GetContent<List<ContractListDto>>(response);

            var id = contracts.Exists(c => c.ContractId == Int64.Parse(value));


            Assert.IsTrue(id);
        }
    }
}

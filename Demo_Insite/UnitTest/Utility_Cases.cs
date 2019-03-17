using InsiteAPI_Deno;
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
   public class Utility_Cases
    {
        

        [TestMethod]
        public void GetUtility_Status()
        {
            
            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetUtilityList");
            var restRequest = restApi.CreateGetRequest();

            var response = restApi.GetResponse(restUrl, restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
          
        }


        [TestMethod]
        public void GetUtility_SearchParamters_singleValue()
        {
            //for single search for array add dirctly into add parameters
            string criteria = "utilityIds";
            string value="1";


            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetUtilityList");
            var restRequest = restApi.CreateGetRequest();
            restRequest.AddQueryParameter(criteria, value);
        
            var response = restApi.GetResponse(restUrl, restRequest);
            var utility = restApi.GetContent<List<UtilityListDto>>(response);

            
            var id = utility.Exists(s => s.UtilityId == Int64.Parse(value));


            Assert.IsTrue(id);
        }

        // Not Implemented
        [TestMethod]
        public void GetUtility_SearchParamters_MultipleValue()
        {
            //for single search for array add dirctly into add parameters
            string criteria = "utilityIds";
            string value = "1";


            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetUtilityList");
            var restRequest = restApi.CreateGetRequest();
            restRequest.AddQueryParameter(criteria, value);
            restRequest.AddQueryParameter(criteria, "2");

            var response = restApi.GetResponse(restUrl, restRequest);

            var content = response.Content;

            var utility = JsonConvert.DeserializeObject<List<UtilityListDto>>(content);

         
        }


        [TestMethod]
        public void GetUtility_FindParamters()
        {
            //for single search for array add dirctly into add parameters
            string criteria = "utilityIds";
            string value = "1";


            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("GetUtilityList");
            var restRequest = restApi.CreateGetRequest();

            var response = restApi.GetResponse(restUrl, restRequest);
            var utility = restApi.GetContent<List<UtilityListDto>>(response);

            var id = utility.Find(s => s.UtilityId == Int64.Parse(value));

            Assert.AreEqual(id.UtilityId,1);
        }


    }
}

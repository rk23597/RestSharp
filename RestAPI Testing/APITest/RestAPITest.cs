using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.CalculateService;

namespace APITest
{
    [TestClass]
    public class RestAPITest
    {
        public static ExtentReports extentReport;
        public static ExtentTest extentTest;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            var htmlReporter = new ExtentHtmlReporter(dir + ".html");
            htmlReporter.LoadConfig(@"extent-config.xml");

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);

        }

        [TestInitialize]
        public void SetupTest()
        {
            extentTest = extentReport.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;

            switch(testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    break;
                case UnitTestOutcome.Aborted:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Pass;
                    break; 
            }

            extentTest.Log(logStatus, "Test ended with status: " + logStatus);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            extentReport.Flush();
        }

        [TestMethod]
        public void GetResponseUsers()
        {
            Demo demo = new Demo();
            var response  = demo.GetUsers();
            Assert.AreEqual(2, response.page);
        }

        [DeploymentItem("Test Data\\CreateUser.csv"),
         DataSource("Microsoft.VisualStudio")]
        [TestMethod]
        public void CreateUsers()
        {
            string jsonString = @"{
                                    ""name"": ""morpheus"",
                                    ""job"": ""leader""
                                }";
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            extentTest.Log(Status.Info, "Create a cleint");
            var restUrl = restApi.SetUrl("api/users");
            extentTest.Log(Status.Info, "Send a request");
            var restRequest = restApi.CreatePostRequest(jsonString);
            extentTest.Log(Status.Info, "Response received");
            var response = restApi.GetResponse(restUrl, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);

            Assert.AreEqual(content.name, "morpheus");
            Assert.AreEqual(content.job, "leader");
        }

        [TestMethod]
        public void AddNumbers()
        {
            HandleBinding handlebinding = new HandleBinding();
            var binding = handlebinding.GetHttpBinding();

            SendWebServiceURL serviceUrl = new SendWebServiceURL();
            var endpoint = serviceUrl.GetEndpointAddress("http://www.dneonline.com/calculator.asmx");

            CalculatorSoapClient soapClient = new CalculatorSoapClient(binding, endpoint);
            var resultAdd = soapClient.Add(12, 23);
            //Console.WriteLine(resultAdd);;
            Assert.AreEqual(35, resultAdd);

            var resultMulti = soapClient.Multiply(12, 23);
            Assert.AreEqual(234, resultMulti);
            //Console.WriteLine(resultMulti);
            // Get binding
            //Get Endpoint
            //CalculateService soapClient = new CalculateService(binding, endpoint);
            // Get binding
            //Get Endpoint
            // soapClinet(binding, endpoint)
            //soapClient....Domain = 
            //soapClient....UserName = 
            //soapClient....Password =

            //result = soapClient.Add(2, 4)
            //Assert

        }
    }
}

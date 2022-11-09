using GmailTA.API;
using GmailTA.Test;
using MongoDB.Bson.IO;
using RestSharp;
using System.Net;

namespace GmailTA.Tests
{
    [TestFixture]
    public class RestTest
    {
        static HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/users");
        readonly HttpWebResponse responce = ApiUtilities.MakeRequest(request);

        [Test]
        public void VerifyOkStatusCode()
        {
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void VerifyHeader()
        {
            Assert.That(responce.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            Assert.IsNotEmpty(responce.Headers);

        }
        [Test]
        public void VerfiyBody()
        {
            List<Root> rootObject = ApiUtilities.DeserializeRootObject(ApiUtilities.GetBody(responce));

            Assert.That(rootObject.Count, Is.EqualTo(10));


        }

    }
}

using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.Testing;

namespace shop.web.test
{
    [TestClass]
    public class WebTest
    {
        [TestMethod]
        public async Task DefaultRoute()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(stringResult);

            var title = htmlDocument.DocumentNode.SelectSingleNode("//html/head/title").InnerText;

            Assert.AreEqual("Home Page", title);
        }
    }
}